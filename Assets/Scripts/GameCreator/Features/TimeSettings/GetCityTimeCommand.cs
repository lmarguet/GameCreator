using System;
using System.Threading.Tasks;
using GameCreator.Config;
using GameCreator.Framework;
using Zenject;

namespace GameCreator.Features.TimeSettings
{
    public class GetCityTimeCommand : AAsyncCommand<string, GetCityTimeCommand.Result>
    {
        public struct Result
        {
            public TimeOfTheDay TimeOfTheDay;
            public DateTime LocalTime { get; set; }
        }

        [Inject] WeatherApiService weatherApiService;
        [Inject] TimeSettingsConfig timeSettingsConfig;

        protected override async Task<Result> DoRun(string city)
        {
            var result = await weatherApiService.QueryCity(city);
            var cityData = result.data.getCityByName;

            var cityConfig = timeSettingsConfig.GetCity(city);

            var cityLocalTime = TimeUtil.GetCurrentTimeWithGmtOffset(cityConfig.GmtOffset);
            var timeOfTheDay = TimeUtil.GetTimeOfTheDay(cityLocalTime);

            return new Result
            {
                TimeOfTheDay = timeOfTheDay,
                LocalTime = cityLocalTime
            };
        }
    }
}