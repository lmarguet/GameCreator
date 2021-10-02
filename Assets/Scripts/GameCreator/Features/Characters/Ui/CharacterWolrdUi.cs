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
        CharacterView character;

        void Awake()
        {
            openEditPopupButton.onClick.AddListener(HandleOpenEditPopupClick);
        }

        async void HandleOpenEditPopupClick()
        {
            await openEditCharacterPopupCommand.Run(character);
        }

        public void Show(CharacterView character, Transform cameraTransform)
        {
            this.character = character;
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