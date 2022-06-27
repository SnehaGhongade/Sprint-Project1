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
    public class ProductController : ControllerBase
    {
        EcommerceContext db;
        public ProductController(EcommerceContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<ProductDetail> GetProducts()
        {
            return db.ProductDetails;
        }
    }
}
