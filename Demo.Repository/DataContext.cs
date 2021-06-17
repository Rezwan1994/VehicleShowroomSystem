using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class DataContext:DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        private DataContext() { }

        public static DataContext context = null;

        public static DataContext getInstance() {
            if(context == null)
            {
                context = new DataContext();
                return context;
            }
            return context;
        } 
    }
}
