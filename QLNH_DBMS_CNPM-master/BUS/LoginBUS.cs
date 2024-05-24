using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class LoginBUS
    {
        LoginDAO loginDAO;
        public string err;
        string role;
        public LoginBUS(string role)
        {
           
            loginDAO = new LoginDAO(role);
            
        }
        public Tuple<bool, string> CheckLogin(LoginDTO loginDTO)
        {
            return loginDAO.Check_login(loginDTO);
        }
        public DataTable LayTaiKhoan() { return loginDAO.LayTaiKhoan();}
        public bool UpdateAccount(LoginDTO loginDTO) { return loginDAO.UpdateAccount(loginDTO, ref err); }
        public bool AddAccount(LoginDTO loginDTO) { return loginDAO.AddAccount(loginDTO, ref err); }
        public DataTable FindAccountByEmployeeID(string manv) {  return loginDAO.FindAccountByEmployeeID(manv); }
        public bool DeleteAccount(string manv) { return loginDAO.DeleteAccount(manv,ref err); }
    }
}
