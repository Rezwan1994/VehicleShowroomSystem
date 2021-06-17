using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class Vehicle : Entity
    {
  
        public string ModelNo { get; set; }
        public string VehicleType { get; set; }
        public string EngineType { get; set; }
        public string EnginePower { get; set; }
        public string TireSize { get; set; }
        public string Tarbo { get; set; }
        public string Weight { get; set; }
        public int VisitorCount { get; set; }
    }
}
