using UnityEngine;

namespace GameCreator.Config
{
    [CreateAssetMenu(fileName = "TerrainEditConfig", menuName = "Config/TerrainEditConfig")]
    public class TerrainEditConfig : ScriptableObject
    {

        [SerializeField] Vector2 diameterRange = new Vector2(1, 100);
        [SerializeField] Vector2 strengthRange = new Vector2(0.1f, 1);

        public Vector2 DiameterRange => diameterRange;
        public Vector2 StrengthRange => strengthRange;
    }
}