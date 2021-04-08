using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CrudAPI.Model
{
    public class DbClass:DbContext
    {
        public DbClass(DbContextOptions<DbClass> options):base(options)
        {

        }
        public DbSet<Emploee> Emploees { get; set; }
    }
}
