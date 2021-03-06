using UnityEngine;

namespace GameCreator.Extensions
{
    public static class TransformExtensions
    {
        public static Transform Clear(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                Object.Destroy(child.gameObject);
            }

            return transform;
        }
    }
}