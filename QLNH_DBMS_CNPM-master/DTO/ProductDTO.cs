using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace DTO
{
    public class ProductDTO
    {
        private string id;
        private string name;
        private string category;
        private string state;
        private float price;
        private Image img;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        // Tạo getter và setter tự động cho trường name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Tạo getter và setter tự động cho trường category
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        // Tạo getter và setter tự động cho trường state
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        // Tạo getter và setter tự động cho trường price
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public Image Img
        {
            get { return img; }
            set { img = value; }
        }
        public ProductDTO()
        {

        }
        public ProductDTO(string id, string name, string category, string state, float price, Image img)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.State = state;
            this.Price = price;
            this.Img = img;
        }

        

    }
}
