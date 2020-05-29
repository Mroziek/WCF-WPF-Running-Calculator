using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorBiegowyService
{
    [DataContract]
    public class Pace
    {
        [DataMember]
        public int Minutes { get; set; }

        [DataMember]
        public int Seconds { get; set; }

        [DataMember]
        public string Comment { get; set; }

        public Pace(int minutes, int seconds, string comment)
        {
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.Comment = comment;
        }

    }
}
