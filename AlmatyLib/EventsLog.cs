using System;
using System.Collections.Generic;
using System.Text;

namespace City.AlmatyLib
{
    public class EventsLog
    {
        public int id { get; set; }
        public string Message { get; set; }
        public DateTime EventTime { get; set; }
        public int EventType { get; set; }
        public EventsLog(string msg, DateTime dt, int evt)
        {
            this.Message = msg;
            this.EventTime = dt;
            this.EventType = evt;
        }
        public override string ToString()
        {
            return string.Format("{0} --- {1}", EventTime, Message);
        }
        public EventsLog()
        {

        }
    }
}

