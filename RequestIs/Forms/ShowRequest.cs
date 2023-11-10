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
    public partial class ShowRequest : Form
    {
        private string idRequest;
        private Form lastForm;
        private string idUserInRequest;
        public ShowRequest(string idRequest, Form lastForm)
        {
            InitializeComponent();
            this.idRequest = idRequest;
            this.lastForm = lastForm;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            lastForm.Show();
            this.Hide();
        }

        private void EditStatus_Click(object sender, EventArgs e)
        {
            new EditStatusRequest(idRequest).Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from requests where id = {idRequest}", db.getConnection());
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
        }
        private void loadInfoForRequest()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM requests WHERE id = '{idRequest}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                HeaderLabel.Text = reader[1].ToString();
                ContentLabel.Text = reader[2].ToString();
            }
            reader.Close();

            db.closeConnection();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SubmitRequest sr = new SubmitRequest(idUserInRequest, idRequest);
            sr.Show();
        }

        private void ShowRequest_Load(object sender, EventArgs e)
        {
            loadInfoForRequest();
            if (Main.login == "admin" || Main.login == "Admin")
            {
                EditStatus.Visible = true;
            }
        }
    }
}
