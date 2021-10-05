using System;
using System.Threading;
using System.Threading.Tasks;
using GameCreator.Config;
using GameCreator.Features.TimeSettings;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        CancellationTokenSource timeRenderCancellationTokenSource;

        public struct SceneTimeData
        {
            public string Name;
            public bool IsCity;
            public string City;
        }

        public SceneTimeData SceneTime => sceneTimeData;

        public async void SetSceneTime(SceneTimeData data)
        {
            sceneTimeData = data;
            await UpdateTimeAndWeather();
        }

        public void SetTimeOfTheDay(TimeOfTheDay timeOfTheDay)
        {
            var renderConfig = timeRenderConfig.GetTimeRenderConfig(timeOfTheDay);
            ApplyTimeConfig(renderConfig);
        }

        void ApplyTimeConfig(TimeSettingsConfig.TimeRenderConfig renderConfig)
        {
            if (RenderSettings.skybox != renderConfig.Skybox)
            {
                RenderSettings.skybox = renderConfig.Skybox;   
            }
        }

        public async Task UpdateTimeAndWeather()
        {
            await updateTimeAndWeatherCommand.Run(SceneTime);
        }

        public async void StartRealTimeUpdate()
        {
            if (SceneTime.IsCity)
            {
                var interval = TimeSpan.FromSeconds(timeRenderConfig.RealTimeRenderIntervalSeconds);
                timeRenderCancellationTokenSource = new CancellationTokenSource();
                await RunConstantTimeAndWeatherUpdate(interval, timeRenderCancellationTokenSource.Token);
            }
            else
            {
                await UpdateTimeAndWeather();
            }
        }

        public void StopRealTimeUpdate()
        {
            if (timeRenderCancellationTokenSource != null)
            {
                timeRenderCancellationTokenSource.Cancel();
                timeRenderCancellationTokenSource.Dispose();
                timeRenderCancellationTokenSource = null;
            }
        }

        async Task RunConstantTimeAndWeatherUpdate(TimeSpan interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await UpdateTimeAndWeather();
                await Task.WhenAny(Task.Delay(interval, cancellationToken));
            }
        }
    }
}