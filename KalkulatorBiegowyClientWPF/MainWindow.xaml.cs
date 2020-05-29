using System;
using System.ServiceModel;
using System.Windows;
using KalkulatorBiegowyService;

namespace KalkulatorBiegowyClientWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FixEmptyTextBoxes();

                var czas = new DateTime();
                czas = czas.Date.AddHours(int.Parse(HoursText.Text)).AddMinutes(int.Parse(MinutesText.Text))
                    .AddSeconds(int.Parse(SecondsText.Text));
                Pace pace;

                Uri adres = new Uri(
                    "http://localhost:8733/Design_Time_Addresses/KalkulatorBiegowyService/KalkulatorBiegowyService/");

                using (var channel = new ChannelFactory<IKalkulatorBiegowy>(
                    new WSHttpBinding(),
                    new EndpointAddress(adres)))
                {
                    IKalkulatorBiegowy service = channel.CreateChannel();
                    pace = service.CalculateAveragePace(
                        double.Parse(DistanceTextKM.Text) + double.Parse(DistanceTextM.Text) / 1000, czas);
                }

                if (pace.Minutes < 0)
                {
                    MessageBox.Show(
                        "Nieprawidłowe Dane! Wynik Ujemny!");
                    return;
                }

                string fixSeconds = "";
                if (pace.Seconds < 10) fixSeconds = "0"; //zawsze 2 cyfry oznaczające sekundy (zamiast 5:0 -> 5:00)
                PaceText.Content = pace.Minutes + ":" +  fixSeconds + pace.Seconds+" min/km";
                TBPaceComment.Text = pace.Comment;

                if (int.Parse(CadenceTB.Text) > 0)
                {
                    StepLength stepLength;

                    using (var channel = new ChannelFactory<IKalkulatorBiegowy>(
                        new WSHttpBinding(),
                        new EndpointAddress(adres)))
                    {
                        IKalkulatorBiegowy service = channel.CreateChannel();
                        stepLength = service.CalculateStepLength(pace, int.Parse(CadenceTB.Text));
                    }


                    string stepLengthString = string.Format("{0:n}m", Convert.ToDouble(stepLength.LengthCM) / 100);

                    StepLengthText.Content = stepLengthString;
                    TBStepComment.Text = stepLength.Comment;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nieprawidłowe Dane! Sprawdź czy dobrze wprowadziłeś dane - program przyjmuje tylko liczby!");
            }
        }

        private void FixEmptyTextBoxes()
        {
            if (HoursText.Text == "") HoursText.Text = "0";
            if (MinutesText.Text == "") MinutesText.Text = "0";
            if (SecondsText.Text == "") SecondsText.Text = "0";
            if (DistanceTextM.Text == "") DistanceTextM.Text = "0";
            if (DistanceTextKM.Text == "") DistanceTextKM.Text = "0";
            if (CadenceTB.Text == "") CadenceTB.Text = "0";
        }


        //clearbutton
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HoursText.Text = "0";
            MinutesText.Text = "0";
            SecondsText.Text = "0";
            TBStepComment.Text = "";
            TBPaceComment.Text = "";
            PaceText.Content = "";
            StepLengthText.Content = "";
            DistanceTextM.Text = "0";
            DistanceTextKM.Text = "0";
            CadenceTB.Text = "0";
        }
    }
}