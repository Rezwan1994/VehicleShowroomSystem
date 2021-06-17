using Demo.Entity;
using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleShowroomSystem
{
    public class Service
    {
        Demo.Facade.VehicleFacade vehicleFacade = null;
        public Service()
        {
            DataContext Context = DataContext.getInstance();

            vehicleFacade = new Demo.Facade.VehicleFacade(Context);
        }

        public void TakeUserChoice()
        {
            Console.WriteLine("Please Select an Option Bellow:");
            char ch;
            Console.WriteLine("Enter an alphabet");

            Console.WriteLine("a. Add any type of vehicle in showroom.");
            Console.WriteLine("b. Remove any of the vehicles from showroom.");
            Console.WriteLine("c. Show the vehicle lists with details currently have in showroom.");
            Console.WriteLine("d. Show the list of vehicles with current expected visitor count");
            ch = Convert.ToChar(Console.ReadLine());
            Service service = new Service();

            switch (Char.ToLower(ch))
            {
                case 'a':
                    service.AddVehicles();
                    break;
                case 'b':
                    service.RemoveVehicle();
                    break;
                case 'c':
                    ShowVehicleList();
                    break;
                case 'd':
                    ShowVehicleListWithExpectedVisitor();
                    break;
                default:
                    Console.WriteLine("Not a valid choice!");
                    break;
            }
            Console.ReadKey();
        }
        public void AddVehicles()
        {
            char vehicletypech;
            char enginetypech;
            Vehicle vehicle = new Vehicle();

            Console.WriteLine("Which type of vehicle you want to add");
            Console.WriteLine("Enter an alphabet");

            Console.WriteLine("a. Normal.");
            Console.WriteLine("b. Sports.");
            Console.WriteLine("c. Heavy.");

            vehicletypech = Convert.ToChar(Console.ReadLine());
            switch (Char.ToLower(vehicletypech))
            {
                case 'a':
                    vehicle.VehicleType = "Normal";
                    break;
                case 'b':
                    vehicle.VehicleType = "Sports";
                    break;
                case 'c':
                    vehicle.VehicleType = "Heavy";
                    break;

                default:
                    Console.WriteLine("Not a valid type");
                    break;
            }
            Console.WriteLine("Enter the model number: ");
            vehicle.VisitorCount = 30;
            vehicle.ModelNo = Convert.ToString(Console.ReadLine());
            #region Engine type choose
            if(vehicle.VehicleType == "Normal")
            {
                Console.WriteLine("Chose the engine type : ");
                Console.WriteLine("Enter an alphabet");

                Console.WriteLine("a. Oil.");
                Console.WriteLine("b. Gas.");
                Console.WriteLine("c. Diesel.");
                enginetypech = Convert.ToChar(Console.ReadLine());

                switch (Char.ToLower(enginetypech))
                {
                    case 'a':
                        vehicle.EngineType = "Oil";
                        break;
                    case 'b':
                        vehicle.EngineType = "Gas";
                        break;
                    case 'c':
                        vehicle.EngineType = "Deisel";
                        break;

                    default:
                        Console.WriteLine("Not a valid type");
                        break;
                }
            }
            else
            {
                if(vehicle.VehicleType == "Sports")
                {
                    vehicle.EngineType = "Oil";
                    Console.WriteLine("Enter the tarbo: ");
                    vehicle.Tarbo = Convert.ToString(Console.ReadLine());
                    vehicle.VisitorCount +=  20;
                }
                if (vehicle.VehicleType == "Heavy")
                {
                    vehicle.EngineType = "Deisel";

                    Console.WriteLine("Enter the weight: ");
                    vehicle.Weight = Convert.ToString(Console.ReadLine());
                }
            }

            #endregion

            Console.WriteLine("Enter the Power Engine ");
            vehicle.EnginePower = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter the tire size ");
            vehicle.TireSize = Convert.ToString(Console.ReadLine());
            try
            {
                vehicleFacade.Insert(vehicle);
                Console.WriteLine("Vehicle added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("vehicle not added");
            }


            TakeUserChoice();
        }

        public void RemoveVehicle()
        {
            Console.WriteLine("Enter the vehicle Id you want to remove.");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                if (id > 0)
                {
                    Vehicle vehicle = vehicleFacade.Get(id);
                    if (vehicle != null)
                    {
                        vehicleFacade.Delete(id);
                        Console.WriteLine("Vehicle deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("There have no vehicle with this id.");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Please Enter a valid id");
            }
            
            TakeUserChoice();
        }
        public void ShowVehicleList()
        {
            List<Vehicle> vehicleList = vehicleFacade.GetAll();
            if (vehicleList != null && vehicleList.Count > 0)
            {
                var t = new TablePrinter("Id","Model No", "Vehicle Type", "Engine Type", "Engine Power", "Tire Size", "Weight", "Tarbo");
                foreach (var item in vehicleList)
                {
                    if(item.ModelNo == null)
                    {
                        item.ModelNo = "-";
                    }
                    if (item.VehicleType == null)
                    {
                        item.VehicleType = "-";
                    }
                    if (item.EngineType == null)
                    {
                        item.EngineType = "-";
                    }
                    if (item.EnginePower == null)
                    {
                        item.EnginePower = "-";
                    }
                    if (item.TireSize == null)
                    {
                        item.TireSize = "-";

                    }
                    if (item.Weight == null)
                    {
                        item.Weight = "-";
                    }
                    if (item.Tarbo == null)
                    {
                        item.Tarbo = "-";
                    }
                    t.AddRow(item.Id,item.ModelNo, item.VehicleType, item.EngineType, item.EnginePower, item.TireSize, item.Weight, item.Tarbo);
              
                }
                t.Print();
            }
            else
            {
                Console.WriteLine("No vehicle added yet!");
            }
            TakeUserChoice();

        }


        public void ShowVehicleListWithExpectedVisitor()
        {
            List<Vehicle> vehicleList = vehicleFacade.GetAll();
            if (vehicleList != null && vehicleList.Count > 0)
            {
                var t = new TablePrinter("Id","Model No", "Vehicle Type", "Engine Type", "Engine Power", "Tire Size", "Weight", "Tarbo","Expected Visitor");
                foreach (var item in vehicleList)
                {
                    if (item.ModelNo == null)
                    {
                        item.ModelNo = "-";
                    }
                    if (item.VehicleType == null)
                    {
                        item.VehicleType = "-";
                    }
                    if (item.EngineType == null)
                    {
                        item.EngineType = "-";
                    }
                    if (item.EnginePower == null)
                    {
                        item.EnginePower = "-";
                    }
                    if (item.TireSize == null)
                    {
                        item.TireSize = "-";

                    }
                    if (item.Weight == null)
                    {
                        item.Weight = "-";
                    }
                    if (item.Tarbo == null)
                    {
                        item.Tarbo = "-";
                    }
                    t.AddRow(item.Id,item.ModelNo, item.VehicleType, item.EngineType, item.EnginePower, item.TireSize, item.Weight, item.Tarbo,item.VisitorCount);
                    t.Print();
                }

            }
            else
            {
                Console.WriteLine("No vehicle added yet!");
            }
            TakeUserChoice();

        }



    }
}
