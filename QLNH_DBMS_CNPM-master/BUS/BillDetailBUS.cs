using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BillDetailBUS
    {
        public string err;
        BillDetailDAO billdetailDAO;
        public BillDetailBUS(string role = null)
        {
            billdetailDAO = new BillDetailDAO(role);
        }
        public bool AddBillDetail(BillDetailDTO billdetailDTO) { return billdetailDAO.AddBillDetail(billdetailDTO, ref err); }
        public bool UpdateBillDetail(BillDetailDTO billdetailDTO) { return billdetailDAO.AddBillDetail(billdetailDTO, ref err); }
    }
}
