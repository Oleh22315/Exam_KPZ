using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Clothing
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public int Price_with_discount { get; set; }
        public string Brend { get; set; }
        public int Release_year { get; set; }
        public int Size { get; set; }
        public string Model { get; set; }
        public int Delivery_day { get; set; }
        public int Delivery_mounth { get; set; }
        public int Delivery_year { get; set; }

    }
}
