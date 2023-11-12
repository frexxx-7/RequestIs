using MySql.Data.MySqlClient;
using RequestIs.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace RequestIs.Forms
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        private void loadInfoUsers()
        {
            DB db = new DB();

            UsersDataGridView.Rows.Clear();

            string query = $"select users.id, login, password, positions.name from users " +
                $"join positions on positions.id = users.position";

            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    dataDB.Add(new string[reader.FieldCount]);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataDB[dataDB.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
                foreach (string[] s in dataDB)
                    UsersDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            new AddUser(null).Show();
        }

        private void Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Main(Main.idUser).Show();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            loadInfoUsers();

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoUsers();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            AddUser au = new AddUser(UsersDataGridView[0, UsersDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            au.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from users where id = {UsersDataGridView[0, UsersDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Пользователь удален");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            loadInfoUsers();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            UsersDataGridView.Rows.Clear();

            string searchString = $"select users.id, login, password, positions.name from users " +
                $"join positions on positions.id = users.position " +
                $"where concat (login, password, positions.name) like '%" + SearchTextBox.Text + "%'";

            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(searchString, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    dataDB.Add(new string[reader.FieldCount]);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataDB[dataDB.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
                foreach (string[] s in dataDB)
                    UsersDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void OtputButton_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            for (int j = 0; j < UsersDataGridView.Columns.Count; j++)
            {
                if (UsersDataGridView.Columns[j].Visible)
                {
                    worksheet.Cells[1, j] = UsersDataGridView.Columns[j].HeaderText;
                }
            }
            for (int i = 0; i < UsersDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < UsersDataGridView.Columns.Count; j++)
                {
                    if (UsersDataGridView.Columns[j].Visible)
                    {
                        worksheet.Cells[i + 2, j] = UsersDataGridView.Rows[i].Cells[j].Value;
                    }
                }
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel File|*.xlsx";
            saveFileDialog1.Title = "Сохранить Excel файл";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                workbook.SaveAs(saveFileDialog1.FileName);
            }
            workbook.Close();
            excelApp.Quit();
        }
    }
}
