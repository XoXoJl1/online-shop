namespace OnlineShop
{
    public class checkUser
    {
        public string Login { get; set; }

        public string StatusName { get; set; }

        public checkUser(string login, string statusName) 
        {
            Login = login.Trim();
            StatusName = statusName;
        }
    }
}
