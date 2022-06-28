using System;
using System.Collections.Generic;

#nullable disable

namespace E_Commerce_Api.Models
{
    public partial class ProductDetail
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? CatId { get; set; }
        public string ProductImage { get; set; }
        public decimal? ProductMrp { get; set; }
        public decimal? ProductDiscount { get; set; }
        public decimal? ProductFinal { get; set; }
        public string ProductQuantity { get; set; }
    }
}
