using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreEF.Models
{
    public class WebServiceRepository : IWebServiceRepository
    {
        private DataContext context;

        public WebServiceRepository(DataContext ctx) => context = ctx;

        public object GetProduct(long id)
        {
            /*
             * EF nutzt ein fixit-feature das NavigationProgertys automatisch mit
             * Daten füllt. Dies führt bei Verwendung von Jason zu einer endlos
             * Schleife. Um das Problem zu lösen, wird im Untergeordneten Objekt
             * die Navigationproperty nicht im neuen Okjekt übernommen und blaibt
             * null, so tritt der Fehler nicht mehr auf.
             */
            return context.Products.Include(p => p.Category).Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                PurchasePrice = p.PurchasePrice,
                Description = p.Description,
                RetailPrice = p.RetailPrice,
                CategoryId = p.CategoryId,
                Category = new
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name,
                    Description = p.Category.Description
                }
            }).FirstOrDefault(p => p.Id == id);
        }

        public object GetProducts(int skip, int take)
        {
            return context.Products.Include(p => p.Category)
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take)
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PurchasePrice = p.PurchasePrice,
                    Description = p.Description,
                    RetailPrice = p.RetailPrice,
                    CategoryId = p.CategoryId,
                    Category = new
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name,
                        Description = p.Category.Description
                    }
                });
        }

        public long StoreProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product.Id;
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
    
        public void DeleteProduct(long id)
        {
            context.Products.Remove(new Product { Id = id });
            context.SaveChanges();
        }
    }
}
