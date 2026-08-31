using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTOs
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double? UnitPrice { get; set; }
        public int? QuantityInStock { get; set; }
    }
}
