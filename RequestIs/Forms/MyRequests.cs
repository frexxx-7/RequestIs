﻿using MySql.Data.MySqlClient;
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
    public partial class MyRequests : Form
    {
        private string idUser;
        public MyRequests(string idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Main main = new Main(idUser);
            main.Show();
            this.Hide();
        }

        private void MyRequests_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SubmitRequest sr = new SubmitRequest(idUser, RequestsDataGridView[0, RequestsDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            sr.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            RequestsDataGridView.Rows.Clear();

            string searchString = $"selectselect requests.id, requests.header, requests.content, requests.idUser, category.name from requests " +
                                $"join category on category.id = request.idCatgory " +
                                $"where concat (header, content)  like '%{SearchTextBox.Text}%' and idUser = {idUser}";

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

        private void loadInfoRequests()
        {
            DB db = new DB();

            RequestsDataGridView.Rows.Clear();

            string query = $"select requests.id, requests.header, requests.content, requests.idUser, category.name from requests " +
                $"left join category on category.id = requests.idCategory " +
                $"where idUser = {idUser}";

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

        private void MyRequests_Load(object sender, EventArgs e)
        {
            loadInfoRequests();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoRequests();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from requests where id = {RequestsDataGridView[0, RequestsDataGridView.SelectedCells[0].RowIndex].Value} and idUser = {idUser}", db.getConnection());
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
            loadInfoRequests();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            new ShowRequest(RequestsDataGridView[0, RequestsDataGridView.SelectedCells[0].RowIndex].Value.ToString(), this).Show();
            this.Hide();
        }

        private void OtputButton_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            for (int j = 0; j < RequestsDataGridView.Columns.Count; j++)
            {
                if (RequestsDataGridView.Columns[j].Visible)
                {
                    worksheet.Cells[1, j] = RequestsDataGridView.Columns[j].HeaderText;
                }
            }
            for (int i = 0; i < RequestsDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < RequestsDataGridView.Columns.Count; j++)
                {
                    if (RequestsDataGridView.Columns[j].Visible)
                    {
                        worksheet.Cells[i+2, j] = RequestsDataGridView.Rows[i].Cells[j].Value;
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
