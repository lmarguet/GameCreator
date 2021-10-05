using GameCreator.Features.EditModeUi;
using GameCreator.Features.GameScene;
using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.StartScreen
{
    public class StartScreenRoot : ASceneRoot
    {
        [Inject] LoadGameSceneCommand loadGameSceneCommand;
        [Inject] LoadEditModeCommand loadEditModeCommand;

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
            await loadEditModeCommand.Run();
        }
    }
}