using System;
using System.Linq;
using GameCreator.SceneManagement;
using UnityEngine;
namespace GameCreator.Config
{
    [Serializable]
    public class GameSceneConfig
    {
        [SerializeField] Scene sceneID;
        [SerializeField] SceneReference scene;

        public Scene SceneID => sceneID;
        public string Name => scene.ScenePath;
    }

    [CreateAssetMenu(fileName = "ScenesConfig", menuName = "Config/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        [SerializeField] GameSceneConfig[] scenes;

        public string GetSceneName(Scene scene)
        {
            return scenes.First(x => x.SceneID == scene).Name;
        }
    }
}