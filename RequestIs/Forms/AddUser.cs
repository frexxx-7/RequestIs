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
    public partial class AddUser : Form
    {
        private string idUserForEdit;
        public AddUser(string idUserForEdit)
        {
            InitializeComponent();
            this.idUserForEdit = idUserForEdit;
            loadInfoPosition();

            if (idUserForEdit != null)
            {
                label1.Text = "Изменить пользователя";
                AddButton.Text = "Изменить";
                loadInfoUser();
            }
        }

        private void loadInfoUser()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM users WHERE id = '{idUserForEdit}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                LoginTextBox.Text = reader[1].ToString();
                PasswordTextBox.Text = reader[2].ToString();

                for (int i = 0; i < PositionComboBox.Items.Count; i++)
                {
                    if (reader["position"].ToString() != "")
                    {
                        if (Convert.ToInt32((PositionComboBox.Items[i] as ComboBoxItem).Value) == Convert.ToInt32(reader["position"]))
                        {
                            PositionComboBox.SelectedIndex = i;
                        }
                    }
                }
            }
            reader.Close();

            db.closeConnection();
        }

        private void loadInfoPosition()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM positions";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                PositionComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idUserForEdit == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into users (login, password, position) values(@login, @password, @position)", db.getConnection());
                command.Parameters.AddWithValue("@login", LoginTextBox.Text);
                command.Parameters.AddWithValue("@password", PasswordTextBox.Text);
                command.Parameters.AddWithValue("@position", (PositionComboBox.SelectedItem as ComboBoxItem).Value);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пользователь добавлен");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            else
            {
                MySqlCommand command = new MySqlCommand($"update users set login=@login, password=@password, position=@position where id = {idUserForEdit}", db.getConnection());
                command.Parameters.AddWithValue("@login", LoginTextBox.Text);
                command.Parameters.AddWithValue("@password", PasswordTextBox.Text);
                command.Parameters.AddWithValue("@position", (PositionComboBox.SelectedItem as ComboBoxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пользователь изменен");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }

        private void AddPosition_Click(object sender, EventArgs e)
        {
            new AddPosition().Show();
        }
    }
}
