using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginDTO
    {
        private string username;
        private string password;
        private string manv;

        public string Password { get { return password; } set { password = value; } }

        public string Manv { get => manv; set => manv = value; }
        public string Username { get => username; set => username = value; }

        public LoginDTO(string username, string password, string manv)
        {
            this.Username = username;
            this.Password = password;
            this.Manv = manv;
        }
    }
}
