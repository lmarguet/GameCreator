using System;
using System.Threading.Tasks;
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
        }

        public SceneTimeData SceneTime => sceneTimeData;

        public void SetSceneTime(SceneTimeData data)
        {
            sceneTimeData = data;

            RenderSceneTimeSettings();
        }

        public async void RenderSceneTimeSettings()
        {
            var timeOfTheDay = await GetTimeOfTheDay();

            var renderConfig = timeRenderConfig.GetTimeRenderConfig(timeOfTheDay);
            ApplyTimeConfig(renderConfig);
        }

        async Task<TimeOfDay> GetTimeOfTheDay()
        {
            if (sceneTimeData.IsCity)
            {
                var cityResult = await getCityTimeCommand.Run(sceneTimeData.Name);
                return cityResult.TimeOfDay;
            }
            
            return (TimeOfDay)Enum.Parse(typeof(TimeOfDay), sceneTimeData.Name);
        }

        void ApplyTimeConfig(TimeSettingsConfig.TimeRenderConfig renderConfig)
        {
            RenderSettings.skybox = renderConfig.Skybox;
        }
    }
}