namespace JuraganAR
{
    class LoginData
    {
        static string name;
        static string email;
        static bool isLogin = false;

        public void setLogin(string names, string emails)
        {
            name = names;
            email = emails;
            isLogin = true;
        }

        public void Logout()
        {
            name = null;
            email = null;
            isLogin = false;
        }

        public string getName()
        {
            return name;
        }

        public string getEmail()
        {
            return email;
        }

        public bool has_Login()
        {
            return isLogin;
        }

    }
}
