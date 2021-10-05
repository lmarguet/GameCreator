using System;
using GeoTimeZone;
using TimeZoneConverter;

namespace GameCreator.Features.TimeSettings
{
    public static class TimeUtil
    {
        public static DateTime GetTimeForCoordinates(double latitude, double longitude)
        {
            var timeZone = TimeZoneLookup.GetTimeZone(latitude, longitude).Result;
            var timeZoneInfo = TZConvert.GetTimeZoneInfo(timeZone);
            return TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, timeZoneInfo).DateTime;
        }

        public static DateTime GetCurrentTimeWithGmtOffset(double gmtOffset)
        {
            return DateTime.Now.ToUniversalTime().AddHours(gmtOffset);
        }

        const int MorningStart = 6;
        const int DayStart = 11;
        const int EveningStart = 18;
        const int NightStart = 22;

        public static TimeOfTheDay GetTimeOfTheDay(DateTime dateTime)
        {
            var hours = dateTime.TimeOfDay.Hours;

            if (hours >= MorningStart && hours < DayStart)
            {
                return TimeOfTheDay.Morning;
            }

            if (hours >= DayStart && hours < EveningStart)
            {
                return TimeOfTheDay.Day;
            }

            if (hours >= EveningStart && hours < NightStart)
            {
                return TimeOfTheDay.Evening;
            }

            return TimeOfTheDay.Night;
        }
    }
}