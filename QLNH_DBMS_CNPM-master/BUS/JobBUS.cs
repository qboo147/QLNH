using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class JobBUS
    {
        public string err;
        JobDAO jobDAO;
        
        public JobBUS(string role=null)
        {
            this.jobDAO = new JobDAO(role);
        }
        public DataTable MaTenCongViec()
        {
            return jobDAO.MaTenCongViec();
        }
       
    }
}
