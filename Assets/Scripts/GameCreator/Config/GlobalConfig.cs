using UnityEngine;

namespace GameCreator.Config
{
    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "Config/GlobalConfig")]
    public class GlobalConfig : ScriptableObject
    {
        [SerializeField] bool debugMode;

        public bool DebugMode => debugMode;
    }
}