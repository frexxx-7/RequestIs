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
    public partial class Main : Form
    {
        public static string idUser;
        public static string login;
        public Main(string idUser)
        {
            InitializeComponent();
            Main.idUser = idUser;
        }

        private void SubmitRequestButton_Click(object sender, EventArgs e)
        {
            new SubmitRequest(idUser, null).Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MyRequests(idUser).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            new Users().Show();
            this.Hide();
        }

        private void RequestsButton_Click(object sender, EventArgs e)
        {
            new AllRequests().Show();
            this.Hide();
        }
    }
}
