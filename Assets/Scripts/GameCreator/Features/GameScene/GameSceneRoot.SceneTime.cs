using GameCreator.Config;
using GameCreator.Features.TimeSettings;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        public struct SceneTimeData
        {
            public string Name;
            public bool IsCity;
            public string City;
        }

        public SceneTimeData SceneTime => sceneTimeData;

        public void SetSceneTime(SceneTimeData data)
        {
            sceneTimeData = data;
        }

        public void SetTimeOfTheDay(TimeOfTheDay timeOfTheDay)
        {
            var renderConfig = timeRenderConfig.GetTimeRenderConfig(timeOfTheDay);
            ApplyTimeConfig(renderConfig);
        }

        void ApplyTimeConfig(TimeSettingsConfig.TimeRenderConfig renderConfig)
        {
            RenderSettings.skybox = renderConfig.Skybox;
        }

        public async void UpdateTimeAndWeather()
        {
            await updateTimeAndWeatherCommand.Run(SceneTime);
        }

    }
}