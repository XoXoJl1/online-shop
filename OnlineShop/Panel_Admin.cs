using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class Panel_Admin : Form
    {
        readonly DataBase dataBase = new DataBase();
        public Panel_Admin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ID_Account", "ID");
            dataGridView1.Columns.Add("Login", "Логин");
            dataGridView1.Columns.Add("Password", "Пароль");
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.Items.AddRange(new string[] { "Admin", "Manager", "User" });
            dataGridView1.Columns.Add(col);
        }

        private void ReadSingleRow(IDataRecord record)
        {
            dataGridView1.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(5));
        }

        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();

            string querystring = "SELECT * FROM Account;";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while(reader.Read()) 
            {
                ReadSingleRow(reader);
            }

            reader.Close();

            dataBase.closeConnection();
        }

        private void Panel_Admin_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            for(int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                string userStatus = dataGridView1.Rows[index].Cells[3].Value.ToString();

                string changeQuery = $"UPDATE Account SET AStatusName = '{userStatus}' WHERE ID_Account = '{id}'";

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
            string deleteQuery = $"DELETE FROM Account WHERE ID_Account = '{id}'";

            SqlCommand sqlCommand = new SqlCommand(deleteQuery, dataBase.getConnection());
            sqlCommand.ExecuteNonQuery();

            dataBase.closeConnection();
            RefreshDataGrid();
        }
    }
}
