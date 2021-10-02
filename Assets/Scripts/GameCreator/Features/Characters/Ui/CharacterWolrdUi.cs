using UnityEngine;

namespace GameCreator.Features.Characters.Ui
{
    public class CharacterWolrdUi : MonoBehaviour
    {
        Transform cameraTransform;
        bool isVisible;

        public void Show(GameObject character, Transform cameraTransform)
        {
            this.cameraTransform = cameraTransform;
            transform.SetParent(character.transform, false);
            UpdateRotation();
            gameObject.SetActive(true);
            isVisible = true;
        }

        public void Hide(Transform parent)
        {
            gameObject.SetActive(false);
            transform.SetParent(parent, false);
            isVisible = false;
        }

        void LateUpdate()
        {
            if (isVisible)
            {
                UpdateRotation();   
            }
        }

        void UpdateRotation()
        {
            transform.LookAt(transform.position + cameraTransform.forward);
        }
    }
}