using System;
using System.Threading.Tasks;
using GameCreator.Features.GameScene;
using GameCreator.Features.PlayMode;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.TimeSettings
{
    public class UpdateTimeAndWeatherCommand : AAsyncCommand<GameSceneRoot.SceneTimeData>
    {
        [Inject] NavigationManager navigationManager;
        [Inject] GetCityDataCommand getCityDataCommand;

        protected override async Task DoRun(GameSceneRoot.SceneTimeData data)
        {
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();

            TimeOfTheDay timeOfTheDay;
            if (gameSceneRoot.SceneTime.IsCity)
            {
                var cityData = await getCityDataCommand.Run(data.City);
                timeOfTheDay = cityData.TimeOfTheDay;

                if (gameSceneRoot.CurrentMode == GameSceneMode.PlayMode)
                {
                    var playUiRoot = navigationManager.GetScene<PlayModeUiRoot>();
                    playUiRoot.SetCityData(cityData);
                }
            }
            else
            {
                timeOfTheDay = (TimeOfTheDay)Enum.Parse(typeof(TimeOfTheDay), gameSceneRoot.SceneTime.Name);
            }

            gameSceneRoot.SetTimeOfTheDay(timeOfTheDay);
        }
    }
}