using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreEF.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext context;

        public CategoryRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Category> Categories => context.Categories;

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            //Category query = context.Categories.Find(category.Id);
            //Category query = (from c in Categories where c.Id == category.Id select c).FirstOrDefault();
            //query.Name = category.Name;
            //query.Description = category.Description;

            (context.Categories.Find(category.Id)).Name=category.Name;
            (context.Categories.Find(category.Id)).Description = category.Description;
            //context.Categories.Update(category);
            context.SaveChanges();
        }
    }
}
