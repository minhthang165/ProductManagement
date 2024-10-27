﻿using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void AddNewProduct(Product product) => ProductDAO.AddNewProduct(product);

        public void DeleteProduct(Product product) => ProductDAO.DeleteProduct(product);


        public Product GetProductById(int id) => ProductDAO.GetProductById(id);

        public List<Product> GetProducts() => ProductDAO.GetProducts();

        public void UpdateProduct(Product product) => ProductDAO.UpdateProduct(product);
    }
}
