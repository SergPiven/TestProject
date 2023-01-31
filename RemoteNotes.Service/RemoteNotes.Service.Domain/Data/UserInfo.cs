using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Service.Domain.Data
{
    public class UserInfo
    {
        private string login;
        public string Login
        {
            get { return login; }
            set { this.login = value; }
        }
        public UserInfo(string login)
        {
            this.login = login;
        }
    }
}
