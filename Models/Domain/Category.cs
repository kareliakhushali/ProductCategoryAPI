using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Mini.Models.Domain
{
    public class Category
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
