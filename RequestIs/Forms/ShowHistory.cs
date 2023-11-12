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
using Excel = Microsoft.Office.Interop.Excel;

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

            HistoryDataGridView.Rows.Clear();

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
                    HistoryDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void OtputButton_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            for (int j = 0; j < HistoryDataGridView.Columns.Count; j++)
            {
                if (HistoryDataGridView.Columns[j].Visible)
                {
                    worksheet.Cells[1, j] = HistoryDataGridView.Columns[j].HeaderText;
                }
            }
            for (int i = 0; i < HistoryDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < HistoryDataGridView.Columns.Count; j++)
                {
                    if (HistoryDataGridView.Columns[j].Visible)
                    {
                        worksheet.Cells[i + 2, j] = HistoryDataGridView.Rows[i].Cells[j].Value;
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

        private void ShowHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
