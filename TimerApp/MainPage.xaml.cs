using Microsoft.Maui.Dispatching;

namespace TimerApp
{
    public partial class MainPage : ContentPage
    {
        private IDispatcherTimer _timer;
        int _totalSeconds = 0;
        bool _longBreak;
        bool _shortBreak;

        public MainPage()
        {
            InitializeComponent();

            _timer = Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += OnTimerTick;
        }

        private void StartTimer(object sender, EventArgs e)
        {
            //set seconds for 25 min timer
            _totalSeconds = 25 * 60; 
            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _totalSeconds--;
            if (_totalSeconds == 0)
                _timer.Stop();

            //seperate to mins and seconds, convert to string to pad with 0's
            string secs = (_totalSeconds % 60).ToString();
            string mins = (_totalSeconds / 60).ToString();
            //secs.PadLeft(3, '0');
            //mins.PadLeft(3, '0');

            TimerLabel.Text = $"{mins}:{secs}";
        }
        
    }
}
