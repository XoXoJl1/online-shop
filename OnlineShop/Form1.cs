using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Form1 : Form
    {
        private checkUser user = new checkUser("default", "default");
        readonly DataBase dataBase = new DataBase();
        int selectedRow;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ID_Shoes", "Код товара");
            dataGridView1.Columns.Add("CompanyName", "Компания");
            dataGridView1.Columns.Add("ShoesName", "Название");
            dataGridView1.Columns.Add("Price", "Цена");
            dataGridView1.Columns.Add("Size", "Размер");
            dataGridView1.Columns.Add("Amount", "Кол-во");
            dataGridView1.Columns.Add("IsNew", string.Empty);
            dataGridView1.Columns["Price"].CellTemplate.Style.Format = "N2";
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetDouble(3), record.GetInt32(4), record.GetInt32(5), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string queryString = "SELECT Shoes.ID_Shoes, CompanyName, ShoesName, Price, Size, Amount FROM (Shoes INNER JOIN Company ON Shoes.ID_Company = Company.ID_Company) INNER JOIN Shoes_size ON Shoes.ID_Shoes = Shoes_size.ID_Shoes";

            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
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
                CompanyComboBox.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }

            dataBase.closeConnection();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            FillCompanies();
            dataGridView1.Columns[6].Visible = false;
        }
        public void UserStatus()
        {
            if (user.StatusName == "Admin")
            {
                OrdersButton.Visible = true;
                CompanyLabel.Visible = true;
                CompanyComboBox.Visible = true;
                ItemsButton.Visible = true;
                NameLabel.Visible = true;
                NameTextBox.Visible = true;
                PriceLabel.Visible = true;
                PriceTextBox.Visible = true;
                IDTextBox.Visible = true;
                IDLabel.Visible = true;
                SizeLabel.Visible = true;
                AmountLabel.Visible = true;
                SizeTextBox.Visible = true;
                AmountTextBox.Visible = true;
                EditButton.Visible = true;
                DeleteSizeButton.Visible = true;
                RefreshButton.Visible = true;
                SaveButton.Visible = true;
                AddSizeButton.Visible = true;
                LoginButton.Visible = false;
                AdminButton.Visible = true;
            }
            else if (user.StatusName == "Manager")
            {
                OrdersButton.Visible = true;
                CompanyLabel.Visible = true;
                CompanyComboBox.Visible = true;
                ItemsButton.Visible = true;
                NameLabel.Visible = true;
                NameTextBox.Visible = true;
                PriceLabel.Visible = true;
                PriceTextBox.Visible = true;
                IDTextBox.Visible = true;
                IDLabel.Visible = true;
                SizeLabel.Visible = true;
                AmountLabel.Visible = true;
                SizeTextBox.Visible = true;
                AmountTextBox.Visible = true;
                EditButton.Visible = true;
                DeleteSizeButton.Visible = true;
                RefreshButton.Visible = true;
                SaveButton.Visible = true;
                AddSizeButton.Visible = true;
                LoginButton.Visible = false;
            }
            else if (user.StatusName == "User")
            {
                Cart.Visible = true;
                AddtoCartButton.Visible = true;
                LoginButton.Visible = false;
                AccountButton.Visible = true;
            }
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            log_in loginForm = new log_in((action) => { user = action; });
            loginForm.ShowDialog();
            UserStatus();
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            Panel_Admin panel_Admin = new Panel_Admin();
            panel_Admin.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                IDTextBox.Text = row.Cells[0].Value.ToString();
                CompanyComboBox.Text = row.Cells[1].Value.ToString();
                NameTextBox.Text = row.Cells[2].Value.ToString();
                PriceTextBox.Text = row.Cells[3].Value.ToString();
                SizeTextBox.Text = row.Cells[4].Value.ToString();
                AmountTextBox.Text = row.Cells[5].Value.ToString();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }

        private void SearchItems(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string querySearch = $"SELECT Shoes.ID_Shoes, CompanyName, ShoesName, Price, Size, Amount FROM (Shoes INNER JOIN Company ON Shoes.ID_Company = Company.ID_Company) INNER JOIN Shoes_size ON Shoes.ID_Shoes = Shoes_size.ID_Shoes WHERE CONCAT(Shoes.ID_Shoes, CompanyName, ShoesName, Price, Size, Amount) LIKE '%" + SearchTextBox.Text + "%'";

            SqlCommand sqlCommand = new SqlCommand(querySearch, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }

        private void DeleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[6].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[6].Value = RowState.Deleted;
        }

        private void ClearFields()
        {
            IDTextBox.Text = "";
            NameTextBox.Text = "";
            CompanyComboBox.Text = "";
            PriceTextBox.Text = "";
            SizeTextBox.Text = "";
            AmountTextBox.Text = "";
        }

        private void UpdateDataGrid()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                RowState rowState = (RowState)dataGridView1.Rows[index].Cells[6].Value;
                int size = Convert.ToInt32(dataGridView1.Rows[index].Cells[4].Value);

                if (rowState == RowState.Existed) continue;
                if (rowState == RowState.Deleted)
                {
                    string deleteQuery = $"DELETE FROM Shoes_size WHERE Size = {size}";
                    SqlCommand sqlCommand = new SqlCommand(deleteQuery, dataBase.getConnection());
                    sqlCommand.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value.ToString());
                    string companyName = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    string shoesName = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    double price = Convert.ToDouble(dataGridView1.Rows[index].Cells[3].Value.ToString());
                    int amount = Convert.ToInt32(dataGridView1.Rows[index].Cells[5].Value.ToString());

                    SqlCommand sqlCommand = new SqlCommand($"SELECT ID_Company FROM Company WHERE CompanyName = '{companyName}';", dataBase.getConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = sqlCommand;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    int id_company = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());

                    string changeQuery = $"UPDATE Shoes SET ShoesName = '{shoesName}', Price = @price, ID_Company = '{id_company}' WHERE Shoes.ID_Shoes = '{id}'";
                    sqlCommand = new SqlCommand(changeQuery, dataBase.getConnection());
                    sqlCommand.Parameters.AddWithValue("@price", price);
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand = new SqlCommand($"UPDATE Shoes_size SET Amount = '{amount}' WHERE ID_Shoes = '{id}' AND Size = '{size}'", dataBase.getConnection());
                    sqlCommand.ExecuteNonQuery();
                }
            }

            dataBase.closeConnection();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchItems(dataGridView1);
        }

        private void DeleteSizeButton_Click(object sender, EventArgs e)
        {
            DeleteRow();
            ClearFields();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }

        private void AddSizeButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            int size;
            int amount;
            if (int.TryParse(SizeTextBox.Text, out size) && int.TryParse(AmountTextBox.Text, out amount))
            {
                string addQuery = $"INSERT INTO Shoes_size (Size, ID_Shoes, Amount) VALUES ('{size}', '{id}', '{amount}');";
                SqlCommand sqlCommand = new SqlCommand(addQuery, dataBase.getConnection());
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch 
                {
                    MessageBox.Show("Такой размер уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Размер обуви добавлен!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Размер не удалось добавить!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void Change()
        {
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            string id = IDTextBox.Text;
            string companyName = CompanyComboBox.Text;
            string shoesName = NameTextBox.Text;
            float price;
            string size = SizeTextBox.Text;
            string amount = AmountTextBox.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (float.TryParse(PriceTextBox.Text, out price))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, companyName, shoesName, price, size, amount);
                    dataGridView1.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Неправильный формат введённых данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        }

        private void ItemsButton_Click(object sender, EventArgs e)
        {
            ItemsList itemsList = new ItemsList();
            itemsList.ShowDialog();
        }

        private void AccountButton_Click(object sender, EventArgs e)
        {
            Account account = new Account(user.Login);
            account.ShowDialog();
        }

        private bool MinusAmount()
        {
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            int size = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[4].Value);
            int amount = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[5].Value);
            if (amount > 0)
            {
                SqlCommand sqlCommand = new SqlCommand($"UPDATE Shoes_size SET Amount = {amount - 1} WHERE ID_Shoes = '{id}' AND Size = '{size}'", dataBase.getConnection());
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            else
            {
                MessageBox.Show("Товара нет в наличии!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void AddtoCartButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            int size = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[4].Value);
            SqlCommand sqlCommand = new SqlCommand($"SELECT ID_Cart FROM Cart INNER JOIN Account ON Cart.ID_Account = Account.ID_Account WHERE Login = '{user.Login}'", dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (MinusAmount() == true)
            {
                if (dataTable.Rows.Count == 1)
                {
                    int id_cart = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());
                    sqlCommand = new SqlCommand($"SELECT Size, ID_Shoes, Quantity FROM CartContent WHERE ID_Shoes = '{id}' AND Size = '{size}'", dataBase.getConnection());
                    adapter = new SqlDataAdapter(sqlCommand);
                    dataTable.Clear();
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0 && dataTable.Rows[0].ItemArray[1].ToString() == size.ToString())
                    {
                        int quantity = Convert.ToInt32(dataTable.Rows[0].ItemArray[3].ToString());
                        sqlCommand = new SqlCommand($"UPDATE CartContent SET Quantity = '{quantity + 1}' WHERE ID_Cart = '{id_cart}' AND ID_Shoes = '{id}' AND Size = '{size}';", dataBase.getConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        string addQuery = $"INSERT INTO CartContent (Size, ID_Cart, ID_Shoes, Quantity) VALUES ('{size}', '{id_cart}', '{id}', '1');";
                        sqlCommand = new SqlCommand(addQuery, dataBase.getConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    sqlCommand = new SqlCommand($"SELECT ID_Account FROM Account WHERE Login = '{user.Login}';", dataBase.getConnection());
                    adapter = new SqlDataAdapter(sqlCommand);
                    dataTable.Clear();
                    adapter.Fill(dataTable);
                    int id_account = Convert.ToInt32(dataTable.Rows[0].ItemArray[1].ToString());
                    sqlCommand = new SqlCommand($"INSERT INTO Cart (ID_Account, DateCart) VALUES ('{id_account}', @data)", dataBase.getConnection());
                    sqlCommand.Parameters.AddWithValue("@data", DateTime.Now);
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand = new SqlCommand($"SELECT ID_Cart FROM Cart WHERE ID_Account = '{id_account}'", dataBase.getConnection());
                    adapter = new SqlDataAdapter(sqlCommand);
                    dataTable.Clear();
                    adapter.Fill(dataTable);
                    int id_cart = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());

                    sqlCommand = new SqlCommand($"INSERT INTO CartContent (Size, ID_Shoes, Quantity, ID_Cart) VALUES ('{size}', '{id}', 1, '{id_cart}');", dataBase.getConnection());
                    sqlCommand.ExecuteNonQuery();
                }
            }
            RefreshDataGrid(dataGridView1);
            dataBase.closeConnection();
        }

        private void Cart_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart(user.Login);
            cart.ShowDialog();
            RefreshDataGrid(dataGridView1);
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            orders.ShowDialog();
        }

        private void companiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics("companies");
            statistics.ShowDialog();
        }

        private void sizesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics("sizes");
            statistics.ShowDialog();
        }

        private void avgCompanyPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics("avgCompanyPrice");
            statistics.ShowDialog();
        }
    }
}