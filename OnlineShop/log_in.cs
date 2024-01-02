using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class log_in : Form
    {
        readonly DataBase dataBase = new DataBase();
        private Action<checkUser> action;
        public log_in(Action<checkUser> action)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.action = action;
        }

        private void log_in_Load(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
            HidePassword.Visible = false;
            LoginTextBox.MaxLength = 20;
            PasswordTextBox.MaxLength = 20;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string loginUser = LoginTextBox.Text;
            string passwordUser = PasswordTextBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"SELECT ID_Account, Login, Password, AStatusName FROM Account WHERE Login = '{loginUser}' AND Password = '{passwordUser}';";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);

            if(dataTable.Rows.Count == 1) 
            {
                checkUser user = new checkUser(dataTable.Rows[0].ItemArray[1].ToString(), dataTable.Rows[0].ItemArray[3].ToString());
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                action(user);
                Close();
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CreateAccountLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sign_up signupForm = new sign_up();
            signupForm.ShowDialog();
        }
    }
}
