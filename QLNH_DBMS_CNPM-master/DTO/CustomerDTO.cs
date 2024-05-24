using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        private string id;
        private string name;
        private string phone;
        private int loyalreward;

        public CustomerDTO()
        {

        }

        public CustomerDTO(string id, string name, string phone, int loyalreward)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Loyalreward = loyalreward;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public int Loyalreward { get => loyalreward; set => loyalreward = value; }
    }
}
