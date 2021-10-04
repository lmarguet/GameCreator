using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.RealtimeLocation
{
    public class LocationEditPopupRoot : ASceneRoot
    {
        [Inject] NavigationManager navigationManager;

        [SerializeField] Button closeButton;

        void Awake()
        {
            closeButton.onClick.AddListener(HandleCloseClick);
        }

        void HandleCloseClick()
        {
            navigationManager.CloseScene<LocationEditPopupRoot>();
        }
    }
}