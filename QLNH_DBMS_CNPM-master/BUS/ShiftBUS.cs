using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    
    public class ShiftBUS
    {
        public string err;
        ShiftDAO shiftDAO;
        public ShiftBUS(string role)
        {
            shiftDAO = new ShiftDAO(role);
        }

        public DataTable GetShiftsByDate(string dateTime)
        {
            return shiftDAO.GetShiftsByDate(dateTime);
        }
        public DataTable GetAllShift()
        {
            return shiftDAO.GetAllShift();
        }
        public bool createShift(ShiftDTO shiftDTO)
        {
            return shiftDAO.createShift(shiftDTO, ref err);
        }
        public bool deleteShift(ShiftDTO shiftDTO) {
            return shiftDAO.removeShift(shiftDTO, ref err);
        }
        public bool updateShift(ShiftDTO shiftDTO)
        {
            return shiftDAO.updateShift(shiftDTO, ref err);
        }
       /* public bool createAssignment(AssignmentDTO assignmentDTO)
        {
            return shiftDAO.createAssigment(assignmentDTO, ref err  );
        }*/
    }
}
