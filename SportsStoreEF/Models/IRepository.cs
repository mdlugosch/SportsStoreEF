using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreEF.Models
{
    /*
     * Durch Dependency Injection wird später eine Datenquelle im Programm übergeben
     * die das interface IRepository implementiert hat. Dadurch kann die Datenquelle
     * ausgewechselt werden. Im Beispiel ist dies eine Liste die nur im Speicher existiert
     * die mit einer echten Datenbank als Datenquelle ersetzt wird.
     */
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        Product GetProduct(long key);

        void AddProduct(Product product);

        void UpdateProduct(Product product);
    }
}
