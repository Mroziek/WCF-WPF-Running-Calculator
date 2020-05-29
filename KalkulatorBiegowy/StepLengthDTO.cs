using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorBiegowyService
{
    [DataContract]
    public class StepLength
    {
        [DataMember]
        public int LengthCM { get; set; }

        [DataMember]
        public string Comment { get; set; }

        public StepLength(int lengthCM, string comment)
        {
            this.LengthCM = lengthCM;
            this.Comment = comment;
        }

    }
}
