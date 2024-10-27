using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                products = stock.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static void AddNewProduct(Product product)
        {
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                stock.Products.Add(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateProduct(Product product)
        {
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                stock.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProduct(Product product)
        {
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                var prod = stock.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                stock.Products.Remove(prod);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Product GetProductById(int id)
        {
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                return stock.Products.FirstOrDefault(p => p.ProductId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
