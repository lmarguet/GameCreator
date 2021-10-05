using UnityEngine;

namespace GameCreator.Features.TerrainEdit
{
    public class TerrainProjector : MonoBehaviour
    {
        [SerializeField] float minSize;
        [SerializeField] float maxSize;

        public void SetBrushScale(float percent)
        {
            var scale = (maxSize - minSize) * percent + minSize;
            transform.localScale = new Vector3(scale, 0, scale);
        }
    }
}