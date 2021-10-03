using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        public void SetCameraControlsEnabled(bool controlsEnabled)
        {
            cameraInputs.enabled = controlsEnabled;
        }

        public void SetupPlayerCamera(GameObject player)
        {
            cameraBase.gameObject.SetActive(false);
            playerCamera.gameObject.SetActive(true);
            playerCamera.SetTarget(player.transform);
        }

        public void ResetCamera()
        {
            playerCamera.gameObject.SetActive(false);
            cameraBase.gameObject.SetActive(true);
            cameraBase.ResetCamera();
        }
    }
}