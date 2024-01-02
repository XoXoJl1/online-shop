using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class Statistics : Form
    {
        DataBase dataBase = new DataBase();
        string condition;
        public Statistics(string condition)
        {
            InitializeComponent();
            this.condition = condition;
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            dataBase.openConnection();
            if (condition == "companies")
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT CompanyName, SUM(Amount) FROM Company INNER JOIN Shoes ON Company.ID_Company = Shoes.ID_Company INNER JOIN Shoes_size ON Shoes.ID_Shoes = Shoes_size.ID_Shoes GROUP BY CompanyName", dataBase.getConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                for (int index = 0; index < dataTable.Rows.Count; index++)
                {
                    chart1.Series[0].Points.AddXY(dataTable.Rows[index].ItemArray[0], dataTable.Rows[index].ItemArray[1]);
                }
            }
            if(condition == "sizes")
            {
                StatsLabel.Text = "Кол-во размеров";
                chart1.Series[0].LegendText = "Размеры";
                SqlCommand sqlCommand = new SqlCommand("SELECT Size, SUM(Amount) FROM Shoes_size GROUP BY Size", dataBase.getConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                for (int index = 0; index < dataTable.Rows.Count; index++)
                {
                    chart1.Series[0].Points.AddXY(dataTable.Rows[index].ItemArray[0], dataTable.Rows[index].ItemArray[1]);
                }
            }
            if(condition == "avgCompanyPrice")
            {
                StatsLabel.Text = "Средняя цена товаров определенного производителя";
                SqlCommand sqlCommand = new SqlCommand("SELECT CompanyName, AVG(Price) FROM Company INNER JOIN Shoes ON Company.ID_Company = Shoes.ID_Company GROUP BY CompanyName", dataBase.getConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                for (int index = 0; index < dataTable.Rows.Count; index++)
                {
                    chart1.Series[0].Points.AddXY(dataTable.Rows[index].ItemArray[0], dataTable.Rows[index].ItemArray[1]);
                }
            }

            dataBase.closeConnection();
        }
    }
}
