using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(Category category) => CategoryDAO.AddNewCategory(category);

        public void DeleteCategory(Category category) => CategoryDAO.DeleteCategory(category);

        public List<Category> GetCategories() => CategoryDAO.GetCategories();

        public Category GetCategoryById(int id) => CategoryDAO.GetCategoryId(id);

        public void UpdateCategory(Category category) => CategoryDAO.UpdateCategory(category);
    }
}
