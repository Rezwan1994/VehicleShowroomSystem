using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Entity;
using Demo.Facade;
using Demo.Repository;

namespace VehicleShowroomSystem
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Service service = new Service();
            Console.WriteLine("*******************WELLCOME TO REZWAN'S SHOWROOM*********************");
            service.TakeUserChoice();
        }
    }
}
