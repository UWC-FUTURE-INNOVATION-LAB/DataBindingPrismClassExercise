using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBinding.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string ImgSrc { get; set; }
    }
}
