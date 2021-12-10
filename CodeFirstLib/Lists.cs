using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstLib
{
    public class Lists
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string NameLists { get; set; }
        
        public string Description { get; set; }

        public string Img { get; set; }
    }
}
