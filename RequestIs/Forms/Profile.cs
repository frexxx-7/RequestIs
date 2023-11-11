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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Main(Main.idUser).Show();
            this.Hide();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            loadInfoUser();
        }
        private void loadInfoUser()
        {
            DB db = new DB();
            string queryInfo = $"SELECT users.*, userInfo.*, concat(address.house, address.street, address.city, address.country) as addressInfo FROM users " +
                $"left join userInfo on users.idUserInfo = userInfo.id " +
                $"left join address on userInfo.idAddress = address.id " +
                $"WHERE users.id = '{Main.idUser}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                LoginLabel.Text = reader["login"].ToString();
                PasswordLabel.Text = reader["password"].ToString();
                NameLabel.Text = reader["name"].ToString() !="" ? reader["name"].ToString() : "Не указано";
                SurnameLabel.Text = reader["surname"].ToString() !="" ? reader["surname"].ToString() : "Не указано";
                PatronymicLabel.Text = reader["patronymic"].ToString() !="" ? reader["patronymic"].ToString() : "Не указано";
                NumberPhoneLabel.Text = reader["numberPhone"].ToString() !="" ? reader["numberPhone"].ToString() : "Не указано";
                NumberPassportLabel.Text = reader["numberPassport"].ToString() !="" ? reader["numberPassport"].ToString() : "Не указано";
                AddressLabel.Text = reader["addressInfo"].ToString() !="" ? reader["addressInfo"].ToString() : "Не указано";
            }
            reader.Close();

            db.closeConnection();
        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
