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
    public class TableBUS
    {
        TableDAO tableDAO;
        public string err;
        public TableBUS(string role)
        {
            tableDAO = new TableDAO(role);
        }
        public DataTable GetAllTables()
        {
            return tableDAO.GetAllTables();
        }
        /*public bool UpdateTrangThaiBan(string maBan, string trangThai)
        {
            return tableDAO.UpdateTrangThaiBan(maBan, trangThai, ref err);
        }*/
        public bool UpdateTrangThaiBan(TableDTO tableDTO)
        {
            return tableDAO.UpdateTrangThaiBan(tableDTO, ref err);
        }
        public bool AddTable(TableDTO tableDTO)
        {
            return tableDAO.AddTable(tableDTO, ref err);
        }
        public DataTable FindTableByID(string id)
        {
            return tableDAO.FindTableByID(id);
        }
        public bool DeleteTableByID(string id)
        {
            return tableDAO.RemoveTable(id,ref err);
        }
        public DataTable FindReservedTableByCusID(string state, string cusID) {  return tableDAO.FindReservedTableByCusID(state,cusID); }
    }
}
