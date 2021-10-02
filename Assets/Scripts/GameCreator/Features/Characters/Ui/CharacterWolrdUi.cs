using GameCreator.Features.Characters.EditPopup;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.Characters.Ui
{
    public class CharacterWolrdUi : MonoBehaviour
    {
        [Inject] OpenEditCharacterPopupCommand openEditCharacterPopupCommand;

        [SerializeField] Button openEditPopupButton;

        Transform cameraTransform;
        bool isVisible;

        void Awake()
        {
            openEditPopupButton.onClick.AddListener(HandleOpenEditPopupClick);
        }

        async void HandleOpenEditPopupClick()
        {
            await openEditCharacterPopupCommand.Run();
        }

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