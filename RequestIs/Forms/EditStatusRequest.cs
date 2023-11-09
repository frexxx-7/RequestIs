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
    public partial class EditStatusRequest : Form
    {
        private string idRequest;
        public EditStatusRequest(string idRequest)
        {
            InitializeComponent();

            loadInfoStatusRequest();
            this.idRequest = idRequest;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddStatusButton_Click(object sender, EventArgs e)
        {
            new AddStatusRequest(idRequest).Show();
            this.Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"INSERT into history (idRequest, idStatusRequest) values(@idRequest, @idStatusRequest)", db.getConnection());
            command.Parameters.AddWithValue("@idRequest",idRequest);
            command.Parameters.AddWithValue("@idStatusRequest", (StatusComboBox.SelectedItem as ComboBoxItem).Value);
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Статус изменен");
                this.Close();

            }
            catch (Exception epx)
            {
                MessageBox.Show("Ошибка" + epx.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
        }
        private void loadInfoStatusRequest()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name FROM statusrequest";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                StatusComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }

        private void EditStatusRequest_Load(object sender, EventArgs e)
        {

        }
    }
}
