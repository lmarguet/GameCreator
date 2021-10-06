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
            SetCameraControlsEnabled(false);
            cameraBase.gameObject.SetActive(false);
            playerCamera.Follow = player.transform;
            playerCamera.LookAt = player.transform;
            playerCamera.gameObject.SetActive(true);
        }

        public void ResetCamera()
        {
            SetCameraControlsEnabled(true);
            playerCamera.gameObject.SetActive(false);
            cameraBase.gameObject.SetActive(true);
            cameraBase.ResetCamera();
        }
    }
}