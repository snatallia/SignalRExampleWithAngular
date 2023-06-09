﻿namespace SignalRServer.Features
{
    public class ChartTimer
    {
        private Timer? timer;
        private Action? action;
        private int actionPeriod = 360;
        public DateTime TimerStarted { get; set; }
        public bool IsTimerStarted { get; set; }

        public void PrepareTimer(Action action)
        {
            this.action = action;
            this.timer = new Timer(Execute, false, 1000, 3000);
            TimerStarted = DateTime.Now;
            IsTimerStarted = true;
        }

        private void Execute(object? stateInfo)
        {
            if (action != null)
                action();

            CheckTimerStatus(DateTime.Now);
        }

        public void CheckTimerStatus(DateTime dateTime)
        {
            if ((dateTime - TimerStarted).TotalSeconds > actionPeriod)
            {
                IsTimerStarted = false;
                if (timer != null)
                    timer.Dispose();
            }
        }
    }
}
