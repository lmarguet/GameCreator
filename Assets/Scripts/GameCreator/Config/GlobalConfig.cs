using UnityEngine;

namespace GameCreator.Config
{
    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "Config/GlobalConfig")]
    public class GlobalConfig : ScriptableObject
    {
        [SerializeField] bool debugMode;
        [SerializeField] int characterDragTreshold;

        public bool DebugMode => debugMode;
        public int CharacterDragTreshold => characterDragTreshold;
    }
}