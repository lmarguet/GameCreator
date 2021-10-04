using System;
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

            RenderSceneTimeSettimgs();
        }

        void RenderSceneTimeSettimgs()
        {
            if (sceneTimeData.IsCity)
            {
                // TODO
                Debug.Log("Not supported");
            }
            else
            {
                var timeOfDay = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), sceneTimeData.Name);
                Debug.Log(timeOfDay);
            }
        }
    }
}