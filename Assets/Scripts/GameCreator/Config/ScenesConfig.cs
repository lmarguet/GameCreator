using System;
using System.Linq;
using GameCreator.SceneManagement;
using UnityEngine;

namespace GameCreator.Config
{
    [Serializable]
    public class GameSceneConfig
    {
        [SerializeField] SceneId sceneIdID;
        [SerializeField] SceneReference scene;

        public SceneId SceneIdID => sceneIdID;
        public string Name => scene.ScenePath;
    }

    [CreateAssetMenu(fileName = "ScenesConfig", menuName = "Config/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        [SerializeField] GameSceneConfig[] scenes;

        public string GetSceneName(SceneId sceneId)
        {
            return scenes.First(x => x.SceneIdID == sceneId).Name;
        }
    }
}