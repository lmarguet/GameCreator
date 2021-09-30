using GameCreator.Features.EditMode;
using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.StartScreen
{
    public class StartScreenRoot : ASceneRoot
    {
        [Inject] LoadGameSceneCommand loadGameSceneCommand;
        [Inject] LoadEditModeUiCommand loadEditModeUiCommand;

        [SerializeField] Button newGameButton;

        void Awake()
        {
            newGameButton.onClick.AddListener(HandleNewGameClicked);
        }

        void Start()
        {
            Debug.Log("[StartScreenRoot] Start");
        }

        async void HandleNewGameClicked()
        {
            await loadGameSceneCommand.Run();
            await loadEditModeUiCommand.Run();
        }
    }
}