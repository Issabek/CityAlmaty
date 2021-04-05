using System;
using System.Threading;
using AlmatyLib;
using City.AlmatyLib;
using LiteDB;
namespace City.Almaty2
{
    class Program
    {
        public enum Events
        {
            Fire = 104,
            Ambulance = 103,
            Police = 102
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Service911 fr = new Service911(WriteMSG);
            for (int i = 0; i < rnd.Next(); i++)
            {
                Thread.Sleep(100);
                int ev = rnd.Next(102, 104);
                switch (ev)
                {
                    case 102:
                        fr.DoEvent("Улица пушкина",new Police());
                        break;
                    case 103:
                        fr.DoEvent("Улица пушкина", new Ambulance());
                        break;
                    case 104:
                        fr.DoEvent("Улица пушкина", new FireFighter());
                        break;
                    default:
                        break;
                }
            }
        }
        public static void WriteMSG(string msg, DateTime time, int evttype)
        {
            using (var db = new LiteDatabase(@"myDataDb.db"))
            {
                var evtLogs = db.GetCollection<EventsLog>("EventsLog");
                EventsLog evt = new EventsLog(msg, time, evttype);
                evtLogs.Insert(evt);
                Console.WriteLine(evt);
            }
        }
    }
}
