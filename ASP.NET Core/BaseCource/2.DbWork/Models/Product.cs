using System;
using System.ComponentModel.DataAnnotations;

namespace _2.DbWork.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime ReleseDate { get; set; }
    }
}
