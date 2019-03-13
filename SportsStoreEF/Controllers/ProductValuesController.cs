using Microsoft.AspNetCore.Mvc;
using SportsStoreEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreEF.Controllers
{
    [Route("api/products")]
    public class ProductValuesController : Controller
    {
        private IWebServiceRepository repository;

        public ProductValuesController(IWebServiceRepository repo) => repository = repo;

        [HttpGet("{id}")]
        public object GetProduct(long id)
        {
            return repository.GetProduct(id) ?? NotFound();
        }
    }
}
