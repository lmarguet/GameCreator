using GameCreator.Features.Characters;
using GameCreator.Features.EditMode;
using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.PlayMode
{
    public class PlayModeUiRoot : ASceneRoot
    {
        [Inject] LoadEditModeUiCommand loadEditModeUiCommand;
        [Inject] NavigationManager navigationManager;

        [SerializeField] Button editModeButton;
        [SerializeField] Joystick joystick;

        void Awake()
        {
            editModeButton.onClick.AddListener(HandlePlaysButtonClick);
        }

        void Start()
        {
            Debug.Log("[PlayModeUiRoot] Start");
        }

        async void HandlePlaysButtonClick()
        {
            await loadEditModeUiCommand.Run();
            navigationManager.CloseScene(SceneId.PlayModeUi);
        }

        void Update()
        {
            JoystickInput.Horizontal = joystick.Horizontal;
            JoystickInput.Vertical = joystick.Vertical;
        }
    }
}