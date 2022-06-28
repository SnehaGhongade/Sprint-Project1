using E_Commerce_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        EcommerceContext db;
        public ProductCategoryController(EcommerceContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<ProductCategory> GetCategory()
        {
            return db.ProductCategories;
        }
        [HttpPost]
        public string post([FromBody] ProductCategory category)
        {
            db.ProductCategories.Add(category);
            db.SaveChanges();
            return "Success";
        }
    }
}
