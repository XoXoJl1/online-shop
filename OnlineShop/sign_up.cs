using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class sign_up : Form
    {
        readonly DataBase dataBase = new DataBase();
        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
            HidePassword.Visible = false;
            LoginTextBox.MaxLength = 20;
            PasswordTextBox.MaxLength = 20;
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (checkUser())
            {
                return;
            }
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            SqlCommand sqlCommand1 = new SqlCommand($"INSERT INTO Customer (Birthday) VALUES(@data);", dataBase.getConnection());
            sqlCommand1.Parameters.AddWithValue("@data", DateTime.Now);
            adapter.SelectCommand = sqlCommand1;
            adapter.Fill(dataTable);
            dataTable.Clear();

            sqlCommand1 = new SqlCommand($"SELECT ID_Customer FROM Customer ORDER BY ID_Customer DESC", dataBase.getConnection());
            adapter.SelectCommand = sqlCommand1;
            adapter.Fill(dataTable);
            DataRow dataRow = dataTable.Rows[0];

            string querystring = $"INSERT INTO Account (Login, Password, CreateDate, AStatusName, ID_Customer) VALUES('{login}', '{password}', @data, 'User', {Convert.ToInt32(dataRow[0].ToString())});";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
            sqlCommand.Parameters.AddWithValue("@data", DateTime.Now);

            dataBase.openConnection();

            if(sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private bool checkUser()
        {
            string loginUser = LoginTextBox.Text;
            string passwordUser = PasswordTextBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            string querystring = $"SELECT ID_Account, Login, Password, AStatusName FROM Account WHERE Login = '{loginUser}' AND Password = '{passwordUser}';";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
            
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);

            if(dataTable.Rows.Count > 0 )
            {
                MessageBox.Show("Пользователь уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ShowPassword_Click(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = false;
            ShowPassword.Visible = false;
            HidePassword.Visible = true;
        }

        private void HidePassword_Click(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
            ShowPassword.Visible = true;
            HidePassword.Visible = false;
        }
    }
}
