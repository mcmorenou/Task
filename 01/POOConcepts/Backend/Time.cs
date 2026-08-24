namespace Backend;

public class Time
{
    // Fields
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;

    // Constructors
    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;

    }

    public Time(int hour)
    {
        Hour = hour;
        Minute = 0;
        Second = 0;
        Millisecond = 0;


    }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        Second = 0;
        Millisecond = 0;


    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = 0;

    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }


    // Properties
    public int Hour
    {
        get => _hour;
        set => _hour = ValidateHour(value);
    }
    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }
    public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);
    }
    public int Second
    {

        get => _second;
        set => _second = ValidateSecond(value);
    }


    // Public Methods
    public Time Add(Time other)
    {
        int milliseconds = Millisecond + other.Millisecond;
        int carrySecond = 0;

        if (milliseconds > 999)
        {
            milliseconds -= 1000;
            carrySecond = 1;
        }

        int second = Second + other.Second + carrySecond;

        int carryMinute = 0;

        if (second > 59)
        {
            second -= 60;
            carryMinute = 1;
        }


        int minute = Minute + other.Minute + carryMinute;

        int carryHour = 0;

        if (minute > 59)
        {
            minute -= 60;
            carryHour = 1;
        }


        int hour = Hour + other.Hour + carryHour;

        if (hour > 23)
        {
            hour -= 24;
        }


        return new Time(hour, minute, second, milliseconds);
    }



    public bool IsOtherDay(Time other)
    {
        long totalMilliseconds = ToMilliseconds() + other.ToMilliseconds();
        return totalMilliseconds >= 24L * 60L * 60L * 1000L;

    }


    public long ToMilliseconds()
    {
        return (Hour * 60L * 60L * 1000L)
             + (Minute * 60L * 1000L)
             + (Second * 1000L)
             + Millisecond;
    }

    public long ToSeconds()
    {
        return (Hour * 60L * 60L)
             + (Minute * 60L)
             + Second;
    }

    public long ToMinutes()
    {
        return (Hour * 60L)
             + Minute;
    }


    public override string ToString()
    {
        int hour = Hour % 12;

        string period = Hour < 12 ? "AM" : "PM";

        return $"{hour:D2}:{Minute:D2}:{Second:D2}.{Millisecond:D3} {period}";
    }

    //Private Methods

    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The hours {hour} are not valid");
        }
        return hour;
    }

    private int ValidateMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception($"The milliseconds {millisecond} are not valid");
        }
        return millisecond;
    }

    private int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minutes {minute} are not valid");
        }
        return minute;
    }

    private int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The seconds {second} are not valid");
        }
        return second;
    }



}
