using GameCreator.Features.PlayMode;
using GameCreator.Features.SettingsPopup;
using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.EditMode
{
    public class EditModeUiRoot : ASceneRoot
    {
        [Inject] LoadSettingsPopupCommand loadSettingsPopupCommand;
        [Inject] LoadPlayModeUiCommand loadPlayModeUiCommand;
        [Inject] CloseSceneCommand closeSceneCommand;

        [SerializeField] Button settingsButton;
        [SerializeField] Button playModeButton;

        void Awake()
        {
            settingsButton.onClick.AddListener(HandleSettingsButtonClick);
            playModeButton.onClick.AddListener(HandlePlaysButtonClick);
        }
        
        void Start()
        {
            Debug.Log("[EditModeUiRoot] Start");
        }

        async void HandlePlaysButtonClick()
        {
            await loadPlayModeUiCommand.Run();
            closeSceneCommand.Execute(SceneId.EditModeUi);
        }

        async void HandleSettingsButtonClick()
        {
            await loadSettingsPopupCommand.Run();
        }
    }
}