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
    public partial class SubmitRequest : Form
    {
        private string idUser;
        private string idRequest;
        public SubmitRequest(string idUser, string idRequest)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.idRequest = idRequest;
            loadInfoCategory();

            if (idRequest != null)
            {
                label2.Text = "Изменить заявку";
                AddButton.Text = "Изменить";
                loadInfoForRequest();
            }
        }
        private void loadInfoCategory()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM category";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                CategoryComboBox.Items.Add(item);
            }
            reader.Close();

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
                HeaderTextBox.Text = reader[1].ToString();
                ContentTextBox.Text = reader[2].ToString();

                for (int i = 0; i < CategoryComboBox.Items.Count; i++)
                {
                    if (reader["idCategory"].ToString() != "")
                    {
                        if (Convert.ToInt32((CategoryComboBox.Items[i] as ComboBoxItem).Value) == Convert.ToInt32(reader["idCategory"]))
                        {
                            CategoryComboBox.SelectedIndex = i;
                        }
                    }
                }
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
            if (idRequest == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into requests (header, content, idUser, idCategory) values(@header, @content, @idUser, @idCategory)", db.getConnection());
                command.Parameters.AddWithValue("@header", HeaderTextBox.Text);
                command.Parameters.AddWithValue("@content", ContentTextBox.Text);
                command.Parameters.AddWithValue("@idUser", idUser);
                command.Parameters.AddWithValue("@idCategory", (CategoryComboBox.SelectedItem as ComboBoxItem).Value);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Заявка оставлена");
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
                MySqlCommand command = new MySqlCommand($"update requests set header = @header, content = @content, idCategory = @idCategory where id = {idRequest}", db.getConnection());
                command.Parameters.AddWithValue("@header", HeaderTextBox.Text);
                command.Parameters.AddWithValue("@content", ContentTextBox.Text);
                command.Parameters.AddWithValue("@idCategory", (CategoryComboBox.SelectedItem as ComboBoxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Заявка изменена");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            new AddCategory().Show();
        }
    }
}
