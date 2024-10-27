﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        void AddNewProduct (Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
