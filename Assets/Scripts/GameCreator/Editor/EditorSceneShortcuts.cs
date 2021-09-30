using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace GameCreator.Editor
{
	public class EditorSceneShortcuts
	{
		const string GameScenePath = "Assets/Scenes/Bootstrap.unity";
		const string PathToPreviouslyClosedSceneKey = "PATH_TO_PREVIOUSLY_CLOSED_SCENE_KEY";

		[MenuItem("Tools/Run Boostrap Scene %l", false, 10)]
		public static void RunGame()
		{
			if (EditorApplication.isPlaying) {
				return;
			}

			if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
				return;
			}

			var currentScenePath = SceneManager.GetActiveScene().path;
			if (currentScenePath != GameScenePath) {
				EditorPrefs.SetString(PathToPreviouslyClosedSceneKey, currentScenePath);
			}
			EditorSceneManager.OpenScene(GameScenePath);
			EditorApplication.isPlaying = true;
		}

		[MenuItem ("Tools/Back to previously opened scene %#l", false, 11)]
		public static void OpenPrevious ()
		{
			var pathToPrevious = EditorPrefs.GetString(PathToPreviouslyClosedSceneKey);
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