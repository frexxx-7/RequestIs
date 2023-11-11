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
using System.Xml;

namespace RequestIs.Forms
{
    public partial class PersonalInformation : Form
    {
        private string idUserInfo;
        public PersonalInformation()
        {
            InitializeComponent();
            loadInfoAddress();

            loadAllInfoUser();
        }

        private void loadAllInfoUser()
        {
            DB db = new DB();
            string queryInfo = $"SELECT users.*, userInfo.* FROM users " +
                $"left join userInfo on users.idUserInfo = userInfo.id " +
                $"WHERE users.id = '{Main.idUser}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                LoginTextBox.Text = reader["login"].ToString();
                PasswordTextBox.Text = reader["password"].ToString();
                NameTextBox.Text = reader["name"].ToString() != "" ? reader["name"].ToString() : "Не указано";
                PatronymicTextBox.Text = reader["patronymic"].ToString() != "" ? reader["patronymic"].ToString() : "Не указано";
                SurnameTextBox.Text = reader["surname"].ToString() != "" ? reader["surname"].ToString() : "Не указано";
                NumberPhoneTextBox.Text = reader["numberPhone"].ToString() != "" ? reader["numberPhone"].ToString() : "Не указано";
                NumberPassportTextBox.Text = reader["numberPassport"].ToString() != "" ? reader["numberPassport"].ToString() : "Не указано";
                idUserInfo = reader["idUserInfo"].ToString() != "" ? reader["idUserInfo"].ToString() : null;

                for (int i = 0; i < AddressComboBox.Items.Count; i++)
                {
                    if (reader["idAddress"].ToString() != "")
                    {
                        if (Convert.ToInt32((AddressComboBox.Items[i] as ComboBoxItem).Value) == Convert.ToInt32(reader["idAddress"]))
                        {
                            AddressComboBox.SelectedIndex = i;
                        }
                    }
                }
            }
            reader.Close();

            db.closeConnection();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            new Main(Main.idUser).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddAddress().Show();
        }

        private void PersonalInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void loadInfoAddress()
        {
            DB db = new DB();
            string queryInfo = $"SELECT address.id, concat(address.house, address.street, address.city, address.country) FROM address";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                AddressComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idUserInfo == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into userInfo (name, surname, patronymic, numberPhone, numberPassport, idAddress) values(@name, @surname, @patronymic, @numberPhone, @numberPassport, @idAddress);" +
                $"Update users set idUserInfo = (Select LAST_INSERT_ID()) " +
                $"where users.id = {Main.idUser} ", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                command.Parameters.AddWithValue("@patronymic", PatronymicTextBox.Text);
                command.Parameters.AddWithValue("@numberPhone", NumberPhoneTextBox.Text);
                command.Parameters.AddWithValue("@numberPassport", NumberPassportTextBox.Text);
                command.Parameters.AddWithValue("@idAddress", (AddressComboBox.SelectedItem as ComboBoxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteScalar();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                db.closeConnection();
            }
            else
            {
                MySqlCommand command = new MySqlCommand($"update userInfo set name = @name, surname = @surname, patronymic = @patronymic, numberPhone = @numberPhone, numberPassport = @numberPassport, idAddress = @idAddress " +
                $"where userInfo.id = {idUserInfo} ", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                command.Parameters.AddWithValue("@patronymic", PatronymicTextBox.Text);
                command.Parameters.AddWithValue("@numberPhone", NumberPhoneTextBox.Text);
                command.Parameters.AddWithValue("@numberPassport", NumberPassportTextBox.Text);
                command.Parameters.AddWithValue("@idAddress", (AddressComboBox.SelectedItem as ComboBoxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteScalar();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                db.closeConnection();
            }

            MySqlCommand commandUser = new MySqlCommand($"update users set login = @login, password = @password where id = {Main.idUser}", db.getConnection());
            commandUser.Parameters.AddWithValue("@login", LoginTextBox.Text);
            commandUser.Parameters.AddWithValue("@password", PasswordTextBox.Text);

            db.openConnection();

            try
            {
                commandUser.ExecuteNonQuery();
                MessageBox.Show("Информация обновлена");
            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
        }
    }
}
