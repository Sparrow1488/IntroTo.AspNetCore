using System;
using System.ComponentModel.DataAnnotations;

namespace _2.DbWork.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public string Mark { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
