using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.SettingsPopup
{
    public class SettingsPopupRoot : ASceneRoot
    {
        [Inject] CloseSceneCommand closeSceneCommand;
        
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
            closeSceneCommand.Execute(SceneId.SettingsPopup);
        }
    }
}