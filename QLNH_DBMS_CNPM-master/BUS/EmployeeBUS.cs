using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class EmployeeBUS
    {
        public string err;
        EmployeeDAO employeeDAO;

        public EmployeeBUS(string role)
        {
            this.employeeDAO = new EmployeeDAO(role);
        }
        public DataTable getAllEmployee()
        {
            return employeeDAO.getAllEmployee();
        }

        public DataTable searchEmployee(EmployeeDTO employeeDTO, string type)
        {
            return employeeDAO.searchEmployee(employeeDTO, type);
        }

        public DataTable CalWageEmployee()
        {
            return employeeDAO.CalWageEmployee();
        }
        public DataTable getAllWaiter()
        {
            return employeeDAO.getAllWaiter();
        }
        public DataTable getAllManager() { return employeeDAO.getAllManager(); }
        public DataTable getAllPartTime() { return employeeDAO.getAllPartTime(); }
        public bool addEmployee(EmployeeDTO employeeDTO)
        {
            return employeeDAO.Add_Employee(employeeDTO, ref err);
        }

        public bool editEmployee(EmployeeDTO employeeDTO)
        {
            return employeeDAO.Edit_Employee(employeeDTO, ref err);
        }

        public bool deleteEmployee(EmployeeDTO employeeDTO)
        {
            return employeeDAO.Delete_Employee(employeeDTO, ref err);
        }
        public bool deleteEmployee(string id)
        {
            return employeeDAO.Delete_Employee(id, ref err);
        }

    }
}
