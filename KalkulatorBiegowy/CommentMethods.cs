using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorBiegowyService
{
    class CommentMethods
    {
        public static string GenerateCommentPace(double paceSeconds)
        {
            if (paceSeconds > 700)
            {
                return "To jest tempo spacerowe :)";
            }
            else if (paceSeconds > 550)
            {
                return "To jest tempo szybkiego marszu";
            }
            else if (paceSeconds > 450)
            {
                return "To jest tempo truchtu :)";
            }
            else if (paceSeconds > 360)
            {
                return "To już całkiem dobre tempo jak na początkującego:)";
            }
            else if (paceSeconds > 300)
            {
                return "W takim tempie przebiegniesz 10km poniżej godziny! Dobra robota!";
            }
            else if (paceSeconds > 240)
            {
                return "To już bardzo dobre tempo jak na amatora! Z powodzeniem będziesz w czołówce miejskich zawodów";
            }
            else if (paceSeconds > 180)
            {
                return "Świetne tempo! Masz szanse zdobyć podium na lokalnych zawodach!";
            }
            else if (paceSeconds > 120)
            {
                return "Brawo! To jest tempo zawodowego biegacza!";
            }
            else
            {
                return "To jest kalkulator biegowy nie rowerowy! Podaj dane jeszcze raz :)";
            }
        }

        public static string GenerateCommentStepLength(double stepLenght)
        {
            if (stepLenght < 100)
            {
                return "Postaraj się wydłużyć swój krok podzcas biegu";
            }
            else if (stepLenght < 130)
            {
                return "To bezpieczna długość kroku dla początkującego! Oby tak dalej :)";
            }
            else if (stepLenght < 150)
            {
                return "To standardowa długość kroku wśród amatorów";
            }
            else if (stepLenght < 180)
            {
                return "Twoja długość kroku jest dłuższa niż u innych amatorów! To da Ci przewagę na zawodach!";
            }
            else
            {
                return "Świetnie! To bardzo długi krok! Nie straszni Ci rywale ani głębokie kałuże :)";
            }
        }
    }
}
