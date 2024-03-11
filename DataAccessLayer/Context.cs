using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class Context : DbContext
    {
        public Context() : base("DbConnection") { }
        public DbSet<Student> Students { get; set; }
    }
}
