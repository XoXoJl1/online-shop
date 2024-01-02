using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class Orders : Form
    {
        DataBase dataBase = new DataBase();
        public Orders()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid();
            dataGridView1.Columns[4].Visible = false;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ID_Order", "Номер заказа");
            dataGridView1.Columns.Add("ToPay", "К оплате");
            dataGridView1.Columns.Add("DateOrdering", "Дата заказа");
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.Items.AddRange(new string[] { "In process", "Accepted", "Cancelled", "Received" });
            dataGridView1.Columns.Add(col);
            dataGridView1.Columns.Add("ID_Cart", "Номер корзины");
            dataGridView1.Columns["ToPay"].CellTemplate.Style.Format = "N2";
        }

        private void ReadSingleRow(IDataRecord record)
        {
            dataGridView1.Rows.Add(record.GetInt32(0), record.GetDouble(1), record.GetDateTime(2), record.GetString(3), record.GetInt32(4));
        }

        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();

            string querystring = "SELECT ID_Order, ToPay, DateOrdering, OStatusName, ID_Cart FROM Ordering;";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(reader);
            }

            reader.Close();

            dataBase.closeConnection();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                string orderStatus = dataGridView1.Rows[index].Cells[3].Value.ToString();

                string changeQuery = $"UPDATE Ordering SET OStatusName = '{orderStatus}' WHERE ID_Order = '{id}'";

                SqlCommand sqlCommand = new SqlCommand(changeQuery, dataBase.getConnection());
                sqlCommand.ExecuteNonQuery();
            }
            dataBase.closeConnection();
            RefreshDataGrid();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            int id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            string deleteQuery = $"DELETE FROM Ordering WHERE ID_Order = '{id}'";

            SqlCommand sqlCommand = new SqlCommand(deleteQuery, dataBase.getConnection());
            sqlCommand.ExecuteNonQuery();

            dataBase.closeConnection();
            RefreshDataGrid();
        }

        private void Orders_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                if (dataGridView1.Rows[index].Cells[3].Value.ToString() == "Received") 
                {
                    SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Ordering WHERE ID_Order = '{Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value)}'", dataBase.getConnection());
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand = new SqlCommand($"DELETE FROM Cart WHERE ID_Cart = '{Convert.ToInt32(dataGridView1.Rows[index].Cells[4].Value)}'", dataBase.getConnection());
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    break;
                }
            }
            dataBase.closeConnection();
        }
    }
}
