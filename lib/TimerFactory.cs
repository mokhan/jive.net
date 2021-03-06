using System;

namespace jive
{
  public class TimerFactory : ITimerFactory
  {
    public System.Timers.Timer create_for(TimeSpan span)
    {
      if (span.Seconds > 0)
      {
        var milliseconds = span.Seconds*1000;
        return new System.Timers.Timer(milliseconds);
      }
      return new System.Timers.Timer(span.Ticks);
    }
  }
}
