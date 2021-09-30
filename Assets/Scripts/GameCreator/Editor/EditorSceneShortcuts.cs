using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace DiabloMenthe.Editor
{
	public class EditorSceneShortcuts
	{
		const string GAME_SCENE_PATH = "Assets/Scenes/00_Splash.unity";
		const string PATH_TO_PREVIOUSLY_CLOSED_SCENE_KEY = "PATH_TO_PREVIOUSLY_CLOSED_SCENE_KEY";

		[MenuItem("Tools/Run Splash Scene %l", false, 10)]
		public static void RunGame()
		{
			if (EditorApplication.isPlaying) {
				return;
			}

			if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
				return;
			}

			var currentScenePath = EditorSceneManager.GetActiveScene().path;
			if (currentScenePath != GAME_SCENE_PATH) {
				EditorPrefs.SetString(PATH_TO_PREVIOUSLY_CLOSED_SCENE_KEY, currentScenePath);
			}
			EditorSceneManager.OpenScene(GAME_SCENE_PATH);
			EditorApplication.isPlaying = true;
		}

		[MenuItem ("Tools/Back to previously opened scene %#l", false, 11)]
		public static void OpenPrevious ()
		{
			var pathToPrevious = EditorPrefs.GetString(PATH_TO_PREVIOUSLY_CLOSED_SCENE_KEY);
			if (string.IsNullOrEmpty(pathToPrevious)) {
				return;
			}

			var coroutine = StopPlayModeAndOpenScene(pathToPrevious);

			EditorApplication.CallbackFunction updateFunction = null;
			updateFunction = () => {
				if (!coroutine.MoveNext()) {
					EditorApplication.update -= updateFunction;
				}
			};

			EditorApplication.update += updateFunction;
		}

		static IEnumerator StopPlayModeAndOpenScene (string path)
		{
			if (EditorApplication.isPlaying) {
				EditorApplication.isPlaying = false;
			}

			yield return null;

			if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
				EditorSceneManager.OpenScene(path);
			}
		}
	}
}