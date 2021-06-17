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
            //DataContext Context = DataContext.getInstance();

            //UserFacade userFacade = new UserFacade(Context);
            //List<User> userlist = userFacade.GetAll();
            //foreach(User item in userlist)
            //{
            //    Console.WriteLine(item.UserName);
            //}
            //Console.ReadKey();
            Service service = new Service();
            Console.WriteLine("*******************WELLCOME TO REZWAN'S SHOWROOM*********************");
            service.TakeUserChoice();
        }
    }
}
