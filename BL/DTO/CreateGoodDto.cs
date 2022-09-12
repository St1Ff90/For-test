using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class CreateGoodDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
