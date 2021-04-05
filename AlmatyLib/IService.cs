using System;
namespace AlmatyLib
{
    public enum ServiceStatus
    {
        Вызов_принят,
        Служба_выехала,
        Служба_приехала,
        Ситуация_под_контролем
    }
    public interface IService
    {
        public int EventType { get; }
        public ServiceStatus Status { set; get; }
        public string Address { get; set; }

    }


    public class FireFighter : IService
    {
        public int EventType { get; } = 104;
        public string Address { get; set; }
        public ServiceStatus Status { set; get; }

    }
    public class Ambulance : IService
    {
        public int EventType { get; } = 103;
        public string Address { get; set; }
        public ServiceStatus Status { set; get; }

    }
    public class Police : IService
    {
        public int EventType { get; } = 102;
        public string Address { get; set; }
        public ServiceStatus Status { set; get; }

    }
}
