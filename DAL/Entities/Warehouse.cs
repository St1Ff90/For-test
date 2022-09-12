using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Warehouse
    {
        [Key]
        public Guid Id { get; set; }
        public string Address { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
