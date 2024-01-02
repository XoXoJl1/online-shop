using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class Cart : Form
    {
        DataBase dataBase = new DataBase();
        string login;
        public Cart(string login)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.login = login;
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            dataGridView1.Columns[0].Visible = false;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ID_Shoes", "Код товара");
            dataGridView1.Columns.Add("CompanyName", "Компания");
            dataGridView1.Columns.Add("ShoesName", "Название");
            dataGridView1.Columns.Add("Price", "Цена");
            dataGridView1.Columns.Add("Size", "Размер");
            dataGridView1.Columns.Add("Quantity", "Кол-во");
            dataGridView1.Columns["Price"].CellTemplate.Style.Format = "N2";
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetDouble(3), record.GetInt32(4), record.GetInt32(5));
        }

        private int GetIdAccount()
        {
            SqlCommand sqlCommand = new SqlCommand($"SELECT ID_Account FROM Account WHERE Login = '{login}';", dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
        }

        private void RefreshDataGrid(DataGridView dgv)
        {
            int id_account = GetIdAccount();

            dgv.Rows.Clear();

            string queryString = $"SELECT DISTINCT Shoes.ID_Shoes, CompanyName, ShoesName, Price, CartContent.Size, Quantity FROM Shoes INNER JOIN Company ON Shoes.ID_Company = Company.ID_Company INNER JOIN Shoes_size ON Shoes.ID_Shoes = Shoes_size.ID_Shoes INNER JOIN CartContent ON Shoes_size.ID_Shoes = CartContent.ID_Shoes INNER JOIN Cart ON CartContent.ID_Cart = Cart.ID_Cart WHERE ID_Account = '{id_account}'";

            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
            dataGridView1.Rows[selectedRowIndex].Visible = false;
            int id_shoes = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            int size = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[4].Value);
            int quantity = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[5].Value);
            SqlCommand sqlCommand = new SqlCommand($"SELECT Amount FROM Shoes_size WHERE ID_Shoes = '{id_shoes}' AND Size = '{size}'", dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            int amount = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
            sqlCommand = new SqlCommand($"UPDATE Shoes_size SET Amount = '{amount + quantity}' WHERE ID_Shoes = '{id_shoes}' AND Size = '{size}'", dataBase.getConnection());
            if(sqlCommand.ExecuteNonQuery() == 1)
            {
                sqlCommand = new SqlCommand($"DELETE FROM CartContent WHERE ID_Shoes = '{id_shoes}' AND Size = '{size}'", dataBase.getConnection());
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Товар успешно удален из корзины!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Товар не удалось удалить из корзины!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteOneItemButton_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
            int quantity = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[5].Value);
            int id_shoes = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            int size = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[4].Value);
            if (quantity > 0)
            { 
                dataGridView1.Rows[selectedRowIndex].Visible = false;
                SqlCommand sqlCommand = new SqlCommand($"SELECT Amount FROM Shoes_size WHERE ID_Shoes = '{id_shoes}' AND Size = '{size}'", dataBase.getConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                int amount = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
                sqlCommand = new SqlCommand($"UPDATE Shoes_size SET Amount = '{amount + 1}' WHERE ID_Shoes = '{id_shoes}' AND Size = '{size}'", dataBase.getConnection());
                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    sqlCommand = new SqlCommand($"UPDATE CartContent SET Quantity = '{quantity - 1}' WHERE ID_Shoes = '{id_shoes}' AND Size = '{size}'", dataBase.getConnection());
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Товар не удалось удалить из корзины!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dataGridView1.Rows[selectedRowIndex].Visible = false;
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM CartContent WHERE ID_Shoes = '{id_shoes}' AND Size = '{size}'", dataBase.getConnection());
                sqlCommand.ExecuteNonQuery();
            }
            RefreshDataGrid(dataGridView1);
        }

        private double CalculateToPay()
        {
            double toPay = 0;
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                SqlCommand sqlCommand = new SqlCommand($"SELECT Price*{Convert.ToInt32(dataGridView1.Rows[index].Cells[5].Value)} FROM Shoes WHERE ID_Shoes = '{Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value)}'", dataBase.getConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                toPay += Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
            }
            return toPay;
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand($"SELECT CName, CSurname, CPhone, CAddress FROM Customer INNER JOIN Account ON Customer.ID_Customer = Account.ID_Customer WHERE Login = '{login}'", dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            sqlCommand = new SqlCommand($"SELECT ID_Cart FROM Cart WHERE ID_Account = '{GetIdAccount()}'", dataBase.getConnection());
            adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable2 = new DataTable();
            adapter.Fill(dataTable2);
            int id_cart = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]);

            double toPay = CalculateToPay();
            if (dataTable.Rows[0].ItemArray[0].ToString() == string.Empty || dataTable.Rows[0].ItemArray[1].ToString() == string.Empty || dataTable.Rows[0].ItemArray[2].ToString() == string.Empty || dataTable.Rows[0].ItemArray[3].ToString() == string.Empty)
            {
                Account account = new Account(login);
                account.ShowDialog();
                sqlCommand = new SqlCommand($"INSERT INTO Ordering (ID_Cart, DateOrdering, ToPay, OStatusName) VALUES ({id_cart}, @data, @toPay, 'In process')", dataBase.getConnection());
                sqlCommand.Parameters.AddWithValue("@data", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@toPay", toPay);
                if (sqlCommand.ExecuteNonQuery() == 1) 
                {
                    MessageBox.Show("Заказ успешно оформлен! Ожидайте пока с вами свяжится наш продавец.", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Заказ не удалось оформить!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                sqlCommand = new SqlCommand($"INSERT INTO Ordering (ID_Cart, DateOrdering, ToPay, OStatusName) VALUES ({id_cart}, @data, @toPay, 'In process')", dataBase.getConnection());
                sqlCommand.Parameters.AddWithValue("@data", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@toPay", toPay);
                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Заказ успешно оформлен! Ожидайте пока с вами свяжится наш продавец.", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Заказ не удалось оформить!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool MinusAmount()
        {
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            int id_shoes = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            int size = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[4].Value);

            SqlCommand sqlCommand = new SqlCommand($"SELECT Amount FROM Shoes_size WHERE ID_Shoes = '{id_shoes}' AND Size = '{size}'", dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            int amount = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
            if (amount > 0)
            {
                sqlCommand = new SqlCommand($"UPDATE Shoes_size SET Amount = {amount - 1} WHERE ID_Shoes = '{id_shoes}' AND Size = '{size}'", dataBase.getConnection());
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            else
            {
                MessageBox.Show("Товара нет в наличии!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void AddOneItemButton_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            int quantity = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[5].Value);
            int size = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[4].Value);
            int id_shoes = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            if (MinusAmount() == true)
            {
                int id_account = GetIdAccount();
                SqlCommand sqlCommand = new SqlCommand($"SELECT ID_Cart FROM Cart WHERE ID_Account = '{id_account}'", dataBase.getConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                int id_cart = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
                sqlCommand = new SqlCommand($"UPDATE CartContent SET Quantity = '{quantity + 1}' WHERE ID_Cart = '{id_cart}' AND ID_Shoes = '{id_shoes}' AND Size = '{size}';", dataBase.getConnection());
                sqlCommand.ExecuteNonQuery();
                RefreshDataGrid(dataGridView1);
            }
        }
    }
}
