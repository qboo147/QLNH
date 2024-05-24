using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class ProductBUS

    {
        public string err;
        ProductDAO productDAO;
        
        public ProductBUS(string role)
        {
            this.productDAO = new ProductDAO(role);
        }
        public DataTable getAllProduct_Product()
        {
            return productDAO.getAllProduct_Product();
        }
        public DataTable getAllProduct_POS()
        {
            return productDAO.getAllProduct_POS();
        }
        public DataTable FindProduct(string name)
        {
            return productDAO.FindProduct(name);
        }
        public DataTable getAllCategory() {
            return productDAO.GetAllCategory();
        }
        public bool addProduct(ProductDTO productDTO)
        {
            return productDAO.AddProduct(productDTO, ref err);
        }
        public bool removeProduct(string id)
        {
            return productDAO.RemoveProduct(id,ref err);
        }
        public bool updateProduct(ProductDTO productDTO)
        {
            return productDAO.UpdateProduct(productDTO,ref err);
        }
        public List<byte[]> getProductImg(string id)
        {
            return productDAO.GetProductImg(id);
        }
    }
}
