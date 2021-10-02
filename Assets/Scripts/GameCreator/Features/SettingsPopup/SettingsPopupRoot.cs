using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.SettingsPopup
{
    public class SettingsPopupRoot : ASceneRoot
    {
        [Inject] NavigationManager navigationManager;

        [SerializeField] Button closeButton;

        void Awake()
        {
            closeButton.onClick.AddListener(HandleCloseClick);
        }

        void Start()
        {
            Debug.Log("[SettingsPopupRoot] Start");
        }

        void HandleCloseClick()
        {
            navigationManager.CloseScene(SceneId.SettingsPopup);
        }
    }
}