using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace ToDoList.CodeFirst
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
