using Andy.Mes.Web.Models;
using System;

namespace Andy.Mes.Web
{
    public class LoginDto : ViewModelBase
    {
        public string Username { get; set; }

        public string Pwd { get; set; }

        public bool isAdmin { get; set; }
    }
}
