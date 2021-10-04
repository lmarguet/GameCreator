using System;
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

        public void RenderSceneTimeSettings()
        {
            var timeOfTheDay = GetTimeOfTheDay();

            var renderConfig = timeRenderConfig.GetTimeRenderConfig(timeOfTheDay);
            ApplyTimeConfig(renderConfig);
        }

        TimeOfDay GetTimeOfTheDay()
        {
            if (sceneTimeData.IsCity)
            {
                // TODO
                Debug.Log("Not supported");
                return TimeOfDay.Day;
            }
            
            return (TimeOfDay)Enum.Parse(typeof(TimeOfDay), sceneTimeData.Name);
        }

        void ApplyTimeConfig(TimeSettingsConfig.TimeRenderConfig renderConfig)
        {
            RenderSettings.skybox = renderConfig.Skybox;
        }
    }
}