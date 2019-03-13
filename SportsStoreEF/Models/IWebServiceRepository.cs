using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreEF.Models
{
    public interface IWebServiceRepository
    {
        object GetProduct(long id);
    }
}
