using System;
using System.ComponentModel.DataAnnotations;

namespace _2.DbWork.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime ReleseDate { get; set; }
    }
}
