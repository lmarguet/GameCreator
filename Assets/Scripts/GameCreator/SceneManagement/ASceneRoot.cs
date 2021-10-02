using UnityEngine;

namespace GameCreator.SceneManagement
{
    public abstract class ASceneRoot : MonoBehaviour
    {
        public void Close()
        {
            Destroy(gameObject);
        }
    }
}