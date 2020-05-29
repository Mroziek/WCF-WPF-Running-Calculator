using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KalkulatorBiegowyService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „KalkulatorBiegowyService” w kodzie i pliku konfiguracji.
    public class KalkulatorBiegowyService : IKalkulatorBiegowy
    {
        public Pace CalculateAveragePace(double distance, DateTime time)
        {
            double timeInSeconds = (time.Hour * 3600) + (time.Minute * 60) + time.Second;

            double paceSeconds = timeInSeconds / distance;

            Pace pace = new Pace((int)paceSeconds / 60, (int)paceSeconds % 60, CommentMethods.GenerateCommentPace(paceSeconds));

            return pace;
        }

        public StepLength CalculateStepLength(Pace pace, int cadence)
        {
            var step1 = 100000 / (pace.Minutes * cadence + (pace.Seconds * cadence / 60));

            StepLength stepLength = new StepLength(step1, CommentMethods.GenerateCommentStepLength(step1));

            return stepLength;
        }
    }
}
