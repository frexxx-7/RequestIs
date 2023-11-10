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
    public partial class ShowHistory : Form
    {
        public ShowHistory()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Main(Main.idUser).Show();
            this.Hide();
        }

        private void ShowHistory_Load(object sender, EventArgs e)
        {
            DB db = new DB();

            DoctorsDataGridView.Rows.Clear();

            string searchString = $"select requests.id, requests.header, requests.content, statusrequest.name from history " +
                $"join requests on requests.id = history.idRequest " +
                $"join statusrequest on statusrequest.id = history.idStatusRequest ";

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
                    DoctorsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }
    }
}
