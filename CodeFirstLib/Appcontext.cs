using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstLib
{
    public class Appcontext : DbContext
    {
        public DbSet<Does> Does { get; set; }
        public DbSet<Lists> Lists { get; set; }
    }
}
