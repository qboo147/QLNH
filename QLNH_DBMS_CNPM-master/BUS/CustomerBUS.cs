using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class CustomerBUS
    {
        public string err;
        CustomerDAO customerDAO;

        public CustomerBUS(string role)
        {
            customerDAO = new CustomerDAO(role);
        }
        public DataTable getAllCustomer()
        {
            return  customerDAO.getAllCustomer();
        }
        public bool updateCustomer(CustomerDTO customerDTO)
        {
            return customerDAO.UpdateCustomer(customerDTO, ref err);
        }
        public bool addCustomer(CustomerDTO customerDTO)
        {
            return customerDAO.AddCustomer(customerDTO, ref err);
        }
        public bool removeCustomer(string id)
        {
            return customerDAO.RemoveCustomer(id, ref err);
        }
        public DataTable FindCustomerByPhone(string phone)
        {
            return customerDAO.FindCustomerByPhone(phone);
        }
        public DataTable FindCustomerByID(string ID)
        {
            return customerDAO.FindCustomerByID(ID);
        }
    }
}
