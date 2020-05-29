using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KalkulatorBiegowyService
{
    [ServiceContract]
    public interface IKalkulatorBiegowy
    {
        [OperationContract]
        Pace CalculateAveragePace(double distance, DateTime time);

        [OperationContract]
        StepLength CalculateStepLength(Pace pace, int cadence);
    }

    
}
