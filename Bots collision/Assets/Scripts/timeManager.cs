using System.Threading;

public delegate void StartTimer(object o);

public class timeManager
{
    private int timer = 0;
    public bool IsElapsed { get; set; }
    System.Threading.Timer _timer;
    int _timerValue, _period;
    public timeManager(int timerValue, int period)
    {
        this._timerValue = timerValue;
        this._period = period;
    }
    public void StartTimerWithDispose(object o)
    {
        TimerCallback tm = new TimerCallback(WaitWithDispose);
        _timer = new System.Threading.Timer(tm, 0, 0, _period);
    }

    public void StartTimerWithOutDispose(object o)
    {
        TimerCallback tm = new TimerCallback(WaitWithOutDispose);
        _timer = new System.Threading.Timer(tm, 0, 0, _period);
    }
    //For AI Shooting
    public void WaitWithOutDispose(object o)
    {
        if (timer >= _timerValue)
        {
            IsElapsed = true;
            timer = 0;
            return;
        }
        else
        {
            timer += 1;
            IsElapsed = false;
        }
    }
    //Delay For Player Shooting
    public void WaitWithDispose(object o)
    {
        if (timer >= _timerValue)
        {
            IsElapsed = true;
            _timer.Dispose();
            timer = 0;
            return;
        }
        else
        {
            timer += 1;
            IsElapsed = false;
        }
    }
}


