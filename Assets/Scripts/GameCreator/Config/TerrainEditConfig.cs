using UnityEngine;

namespace GameCreator.Config
{
    [CreateAssetMenu(fileName = "TerrainEditConfig", menuName = "Config/TerrainEditConfig")]
    public class TerrainEditConfig : ScriptableObject
    {

        [SerializeField] Vector2 diameterRange = new Vector2(1, 100);
        [SerializeField] float brushStrengh  = 0.05f;

        public Vector2 DiameterRange => diameterRange;
        public float BrushStrengh => brushStrengh;
    }
}