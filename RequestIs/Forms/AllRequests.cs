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

namespace RequestIs.Forms
{
    public partial class AllRequests : Form
    {
        public AllRequests()
        {
            InitializeComponent();
        }
        private void loadInfoRequest()
        {
            DB db = new DB();

            RequestsDataGridView.Rows.Clear();

            string query = "select requests.id, requests.header, requests.content, category.name, users.login, statusrequest.name from requests " +
                 "left join history on history.idRequest = requests.id " +
                 "left join statusrequest on history.idStatusRequest = statusrequest.id " +
                 "left join category on category.id = requests.idCategory " +
                 "join users on requests.idUser = users.id " +
                 "GROUP by requests.id ";


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
                    RequestsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Main(Main.idUser).Show();
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from requests where id = {RequestsDataGridView[0, RequestsDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Заявка удалена");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            loadInfoRequest();
        }

        private void AllRequests_Load(object sender, EventArgs e)
        {
            loadInfoRequest();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoRequest();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            RequestsDataGridView.Rows.Clear();

            string searchString = "select requests.id, requests.header, requests.content, category.name, users.login, statusrequest.name from requests " +
                 "left join history on history.idRequest = requests.id " +
                 "left join statusrequest on history.idStatusRequest = statusrequest.id " +
                 "left join category on category.id = requests.idCategory " +
                 "join users on requests.idUser = users.id " +
                  $"where concat (requests.header, requests.content, category.name, users.login, statusrequest.name)  like '%{SearchTextBox.Text}% '" +
                 "GROUP by requests.id ";

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
                    RequestsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void EditStatus_Click(object sender, EventArgs e)
        {
            new EditStatusRequest(RequestsDataGridView[0, RequestsDataGridView.SelectedCells[0].RowIndex].Value.ToString()).Show();
        }

        private void AllRequests_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            new ShowRequest(RequestsDataGridView[0, RequestsDataGridView.SelectedCells[0].RowIndex].Value.ToString(), this).Show();
            this.Hide();
        }
    }
}
