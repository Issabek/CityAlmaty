using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AlmatyLib;
namespace City.AlmatyLib
{
    public delegate void myDel(string msg, DateTime date, int type);
    public class Service911
    {
        myDel ServiceDel;
        public Service911()
        {

        }
        public Service911(myDel del)
        {
            ServiceDel = del;
        }
        public void DoEvent(string Address, IService service)
        {
            Random rnd = new Random();
            service.Address = Address;
            ServiceDel?.Invoke(string.Format("{0}: {1}",service.GetType().Name,ServiceStatus.Вызов_принят), DateTime.Now,service.EventType);
            ServiceDel?.Invoke(string.Format("{0}: {1}", service.GetType().Name, ServiceStatus.Служба_выехала), DateTime.Now, service.EventType);
            for (int i = 0; i < rnd.Next(10, 30); i++)
            {
                Thread.Sleep(50);
                Console.Write(".");
            }
            Console.WriteLine("");
            ServiceDel?.Invoke(string.Format("{0}: {1}", service.GetType().Name, ServiceStatus.Служба_приехала), DateTime.Now, service.EventType);
            for (int i = 0; i < rnd.Next(10, 30); i++)
            {
                Thread.Sleep(50);
                Console.Write(".");
            }
            Console.WriteLine("");
            ServiceDel?.Invoke(string.Format("{0}: {1}", service.GetType().Name, ServiceStatus.Ситуация_под_контролем), DateTime.Now, service.EventType);
            service.Status = ServiceStatus.Ситуация_под_контролем;
        }
    }
}
