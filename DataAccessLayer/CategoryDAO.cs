using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                categories = stock.Categories.ToList();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }

        public static void AddNewCategory(Category category)
        {
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                stock.Categories.Add(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCategory(Category category)
        {
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                var cate = stock.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
                stock.Categories.Remove(cate);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateCategory(Category category)
        {
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                stock.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                stock.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Category GetCategoryId(int id)
        {
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                return stock.Categories.FirstOrDefault(c => c.CategoryId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
