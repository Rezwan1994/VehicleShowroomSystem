using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class VehicleRepository : Repository<Vehicle>
    {
        DataContext context = null;
        public VehicleRepository(DataContext dataContext) : base(dataContext)
        {
            this.context = dataContext;
        }
    }
}
