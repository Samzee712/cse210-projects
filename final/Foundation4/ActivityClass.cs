using System;
using System.Collections.Generic;

public abstract class Activity
{
    protected DateTime _date;
    protected int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} \n {GetType().Name}\n ({_minutes} min):\n Distance {GetDistance():F1} km,\n Speed {GetSpeed():F1} kph,\n Pace: {GetPace():F2} min per km";
    }
}