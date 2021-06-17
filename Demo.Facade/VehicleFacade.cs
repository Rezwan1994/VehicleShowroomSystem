using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Facade
{
    public class VehicleFacade : Facade<Entity.Vehicle>
    {
        VehicleRepository vehicleRepository = null;
        public VehicleFacade(DataContext dataContext) : base(dataContext)
        {
            vehicleRepository = new VehicleRepository(dataContext);
        }
    }
}
