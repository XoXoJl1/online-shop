using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class Account : Form
    {
        DataBase dataBase = new DataBase();
        private string login;
        public Account(string login)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.login = login;
        }

        private void Account_Load(object sender, EventArgs e)
        {
            string fillQuery = $"SELECT CName, CSurname, CEmail, CPhone, CAddress, Birthday FROM Customer INNER JOIN Account ON Customer.ID_Customer = Account.ID_Customer WHERE Login = '{login}'";
            SqlCommand sqlCommand = new SqlCommand(fillQuery, dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            textBox_name.Text = dataTable.Rows[0].ItemArray[0].ToString();
            textBox_surname.Text = dataTable.Rows[0].ItemArray[1].ToString();
            textBox_email.Text = dataTable.Rows[0].ItemArray[2].ToString();
            textBox_phone.Text = dataTable.Rows[0].ItemArray[3].ToString();
            textBox_address.Text = dataTable.Rows[0].ItemArray[4].ToString();
            dateTimePicker1.Value = (DateTime)dataTable.Rows[0].ItemArray[5];
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            string getIdCustomer = $"SELECT Customer.ID_Customer FROM Customer INNER JOIN Account ON Customer.ID_Customer = Account.ID_Customer WHERE Login = '{login}'";
            SqlCommand sqlCommand = new SqlCommand(getIdCustomer, dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            int id_customer = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());
            string name = textBox_name.Text;
            string surname = textBox_surname.Text;
            string email = textBox_email.Text;
            string phone = textBox_phone.Text;
            string address = textBox_address.Text;
            string changeQuery = $"UPDATE Customer SET CName = '{name}', CSurname = '{surname}', CEmail = '{email}', CPhone = '{phone}', CAddress = '{address}', Birthday = @data WHERE ID_Customer = '{id_customer}'";
            dataBase.openConnection();
            sqlCommand = new SqlCommand(changeQuery, dataBase.getConnection());
            sqlCommand.Parameters.AddWithValue("@data", dateTimePicker1.Value);
            if(sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Информация успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Информацию не удалось изменить!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }
    }
}
