using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstLib
{
    public class Does
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(150)]
        public string Doe { get; set; }
        public string Description { get; set; }
        [Key]
        public int ListsID { get; set; }
        public string Date { get; set; }
    }
}
