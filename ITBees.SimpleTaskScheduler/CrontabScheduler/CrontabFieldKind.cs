using System;

namespace TimesheetApi.Services.SchedulingServices.CrontabScheduler
{
    [Serializable]
    public enum CrontabFieldKind
    {
        Minute,
        Hour,
        Day,
        Month,
        DayOfWeek
    }
}