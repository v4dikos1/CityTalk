using System.ComponentModel;

namespace Domain.Entities.Enums;

public enum DayOfWeekEnum
{
    [Description("Понеделельник")]
    Monday = 1,
    [Description("Вторник")]
    Tuesday = 2,
    [Description("Среда")]
    Wednesday = 3,
    [Description("Четверг")]
    Thursday = 4,
    [Description("Пятница")]
    Friday = 5,
    [Description("Суббота")]
    Saturday = 6,
    [Description("Воскресенье")]
    Sunday = 7
}