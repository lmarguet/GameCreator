using System.Threading.Tasks;
using GameCreator.Config;
using GameCreator.Framework;
using Zenject;

namespace GameCreator.Features.TimeSettings
{
    public class GetCityDataCommand : AAsyncCommand<string, CityData>
    {
        [Inject] WeatherApiService weatherApiService;
        [Inject] TimeSettingsConfig timeSettingsConfig;

        protected override async Task<CityData> DoRun(string city)
        {
            var result = await weatherApiService.QueryCity(city);
            var cityData = result.data.getCityByName;

            var cityConfig = timeSettingsConfig.GetCity(city);

            var cityLocalTime = TimeUtil.GetCurrentTimeWithGmtOffset(cityConfig.GmtOffset);
            var timeOfTheDay = TimeUtil.GetTimeOfTheDay(cityLocalTime);

            var resultReturn =  new CityData
            {
                Name = city,
                TimeOfTheDay = timeOfTheDay,
                LocalTime = cityLocalTime,
                Weather = cityData.weather
            };

            return resultReturn;
        }
    }
}