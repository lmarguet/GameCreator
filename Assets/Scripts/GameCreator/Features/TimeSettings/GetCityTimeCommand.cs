using System;
using System.Threading.Tasks;
using GameCreator.Framework;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.TimeSettings
{
    public class GetCityTimeCommand : AAsyncCommand<string, GetCityTimeCommand.Result>
    {
        public struct Result
        {
            public TimeOfDay TimeOfDay;
        }
        
        [Inject] WeatherApiService weatherApiService;
        
        protected override async Task<Result> DoRun(string city)
        {
            var result = await weatherApiService.QueryCity(city);

            //TODO FIX looks like the timestamp returns the time the data was last updated
            var timestamp = long.Parse(result.data.getCityByName.weather.timestamp);
            var time = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
            Debug.Log(time.TimeOfDay);
            Debug.Log(time.ToUniversalTime().TimeOfDay);
            
            
            
            return new Result
            {
                TimeOfDay = TimeOfDay.Morning
            };
        }
    }
}