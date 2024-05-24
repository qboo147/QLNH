using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AssignmentDTO
    {
        private string employeeId;
        private string shiftId;
        private DateTime workingDate;
        private string hoNV;
        private string tenNV;

        public AssignmentDTO(string employeeId, string shiftId, DateTime workingDate, string honv, string tennv)
        {
            this.EmployeeId = employeeId;
            this.ShiftId = shiftId;
            this.WorkingDate = workingDate;
            this.HoNV = honv;
            this.TenNV = tennv;

        }

        public string EmployeeId { get { return employeeId; } set { employeeId = value; } }
        public string ShiftId { get { return shiftId; } set { shiftId = value; } }
        public DateTime WorkingDate { get { return workingDate; } set { workingDate = value; } }

        public string HoNV { get => hoNV; set => hoNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
    }
}
