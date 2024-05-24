using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TableDTO
    {
        private string id;
        private string status;
        private int? deposit;
        private string customerId;
        public TableDTO() { }
        

        public string Id { get { return id; } set { id = value; } }
        public string Status { get { return status; } set { status = value; } }
        public int? Deposit { get { return deposit; } set { deposit = value; } }
        public string CustomerId { get { return customerId; } set { customerId = value; } }

        public TableDTO(string id, string status)
        {
            Id = id;
            Status = status;
        }

        public TableDTO(string id, string status, int? deposit, string customerId) : this(id, status)
        {
            Deposit = deposit;

            CustomerId = string.IsNullOrEmpty(customerId) ? null : customerId;
        }
        public TableDTO(string id, string status, int deposit , string customerId) : this(id, status)
        {
            Deposit = deposit;

            CustomerId = customerId;
        }
    }
}
