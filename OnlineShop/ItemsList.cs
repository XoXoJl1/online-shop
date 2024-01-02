using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class ItemsList : Form
    {
        DataBase dataBase = new DataBase();
        public ItemsList()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns ()
        {
            dataGridView1.Columns.Add("ID_Shoes", "Код товара");
            dataGridView1.Columns.Add("CompanyName", "Компания");
            dataGridView1.Columns.Add("ShoesName", "Название");
            dataGridView1.Columns.Add("Price", "Цена");
            dataGridView1.Columns.Add("Description", "Описание");
            dataGridView1.Columns["Price"].CellTemplate.Style.Format = "N2";
        }
        private void ReadSingleRow(IDataRecord record)
        {
            dataGridView1.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetDouble(3), record.GetString(4));
        }
        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();

            string querystring = "SELECT ID_Shoes, CompanyName, ShoesName, Price, Description FROM Shoes INNER JOIN Company ON Shoes.ID_Company = Company.ID_Company;";

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
        private void FillCompanies()
        {
            dataBase.openConnection();

            SqlCommand addCompanies = new SqlCommand("SELECT CompanyName FROM Company", dataBase.getConnection());

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            adapter.SelectCommand = addCompanies;
            adapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox_companies.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }

            dataBase.closeConnection();
        }
        private void ItemsList_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid();
            FillCompanies();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            SqlCommand sqlCommand = new SqlCommand($"SELECT ID_Company FROM Company WHERE CompanyName = '{comboBox_companies.Text}';", dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);

            int id_company = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());

            int id;
            int size;
            int amount;
            string company = comboBox_companies.Text;
            string itemName = textBox_itemname.Text;
            string description = textBox_description.Text;
            float price;


            if (int.TryParse(textBox_id.Text, out id) && float.TryParse(textBox_price.Text, out price))
            {

                string addQuery = $"INSERT INTO Shoes (ID_Shoes, ShoesName, Price, Description, ID_Company) VALUES ('{id}', '{itemName}', @price, '{description}', '{id_company}');";

                sqlCommand = new SqlCommand(addQuery, dataBase.getConnection());
                sqlCommand.Parameters.AddWithValue("@price", price);
                sqlCommand.ExecuteNonQuery();

                if (int.TryParse(textBox_size.Text, out size) && int.TryParse(textBox_amount.Text, out amount))
                {
                    addQuery = $"INSERT INTO Shoes_size (Size, ID_Shoes, Amount) VALUES ('{size}', '{id}', '{amount}')";
                    sqlCommand = new SqlCommand(addQuery, dataBase.getConnection());
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Проблемы с добавлением размера!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Товар успешно добавлен!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Товар не удалось добавить!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
            RefreshDataGrid();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            if (int.TryParse(dataGridView1.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Shoes WHERE ID_Shoes = {id};", dataBase.getConnection());
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Товар успешно удален!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Товар не получилось удалить!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
            RefreshDataGrid();
        }
    }
}
