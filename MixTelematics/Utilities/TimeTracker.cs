using System.Diagnostics;

namespace MixTelematics.Utilities
{
    public class TimeTracker
    {
        private Stopwatch _stopwatch;
        public TimeTracker()
        {
            _stopwatch = new Stopwatch();
        }

        public void Start() => _stopwatch.Start();
        public void End() => _stopwatch.Stop();
        public string TotalTimeTaken()
        {
            var ts = _stopwatch.Elapsed;

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);

            return elapsedTime;
        }

    }
}
