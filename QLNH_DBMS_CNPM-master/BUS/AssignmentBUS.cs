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
    public class AssignmentBUS
    {
        public string err;
        AssignmentDAO AssignmentDAO;
        public AssignmentBUS(string role)
        {
            AssignmentDAO = new AssignmentDAO(role);
        }
        public bool createShift(AssignmentDTO assignmentDTO) { return AssignmentDAO.createShift(assignmentDTO, ref err); }
        public bool removeShift(AssignmentDTO assignmentDTO) { return AssignmentDAO.removeShift(assignmentDTO, ref err); }
        public bool updateShift(AssignmentDTO assignmentDTO) { return AssignmentDAO.updateShift(assignmentDTO, ref err); }
        public DataTable getAllAssignmentShift() { return AssignmentDAO.GetAllShiftAssignment(); }
    }
}
