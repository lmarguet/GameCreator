using System;
using System.Threading.Tasks;
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
        
        protected override async Task<Result> DoRun(string city)
        {
            var result = await weatherApiService.QueryCity(city);
            var cityData = result.data.getCityByName;
            
            var latitude = double.Parse(cityData.coord.lat);
            var longitude = double.Parse(cityData.coord.lon);
            
            var convertedTime = TimeUtil.GetTimeForCoordinates(latitude, longitude);
            var timeOfTheDay = TimeUtil.GetTimeOfTheDay(convertedTime);
            
            return new Result
            {
                TimeOfTheDay = timeOfTheDay,
                LocalTime = convertedTime
            };
        }
    }
}