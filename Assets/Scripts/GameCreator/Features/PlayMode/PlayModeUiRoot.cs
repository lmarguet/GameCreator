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
        [Inject] CloseSceneCommand closeSceneCommand;

        [SerializeField] Button editModeButton;

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
            closeSceneCommand.Execute(SceneId.PlayModeUi);
        }
    }
}