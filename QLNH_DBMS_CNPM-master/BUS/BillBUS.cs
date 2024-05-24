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
    public class BillBUS
    {
        public string err;
        BillDAO billDAO;
        public BillBUS(string role = null)
        {
            billDAO = new BillDAO(role);
        }
        public DataTable GetAllBill(){  return billDAO.GetAllBill();}
        public DataTable GetBillJoinDetail(int maHD) {  return billDAO.GetBillJoinDetail(maHD);}
        public DataTable FindBill(int maHD) { return  billDAO.FindBill(maHD);}
        public int AddBill(BillDTO billDTO) { return billDAO.AddBill(billDTO, ref err); }
        public bool RemoveBill(int  id) { return billDAO.RemoveBill(id, ref err); }
        public bool UpdateBill(BillDTO billDTO) { return billDAO.UpdateBill(billDTO, ref err); }
    }
}
