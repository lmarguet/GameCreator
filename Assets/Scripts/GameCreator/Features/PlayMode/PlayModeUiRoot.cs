using GameCreator.Features.Characters;
using GameCreator.Features.EditModeUi;
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
        bool showJoytsick;

        void Awake()
        {
            editModeButton.onClick.AddListener(HandlePlaysButtonClick);
            joystick.gameObject.SetActive(false);
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
            if (showJoytsick)
            {
                JoystickInput.Horizontal = joystick.Horizontal;
                JoystickInput.Vertical = joystick.Vertical;   
            }
        }

        public void ShowJoystick(bool show)
        {
            joystick.gameObject.SetActive(show);
            showJoytsick = show;
        }
    }
}