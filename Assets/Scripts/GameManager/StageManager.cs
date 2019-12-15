using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	[SerializeField] string _firstScene = "";

	void Start() {
		//Load first scene if specified.
		if (_firstScene != "") {
			StartCoroutine(LoadScene(_firstScene));
		}
	}

	IEnumerator LoadScene(string sceneName) {
		AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		yield return loading;
		Scene loadedScene = SceneManager.GetSceneByName(sceneName);
		SceneManager.SetActiveScene(loadedScene);
		yield break;
	}

	IEnumerator LoadScene(int sceneBuildIndex) {
		AsyncOperation loading = SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Additive);
		yield return loading;
		Scene loadedScene = SceneManager.GetSceneByBuildIndex(sceneBuildIndex);
		SceneManager.SetActiveScene(loadedScene);
		yield break;
	}

	IEnumerator UnloadScene(string sceneName) {
		Scene unloadScene = SceneManager.GetSceneByName(sceneName);
		AsyncOperation unloading = SceneManager.UnloadSceneAsync(unloadScene);
		yield return unloading;
		yield break;
	}

	IEnumerator UnloadScene(int sceneBuildIndex) {
		Scene unloadScene = SceneManager.GetSceneByBuildIndex(sceneBuildIndex);
		AsyncOperation unloading = SceneManager.UnloadSceneAsync(unloadScene);
		yield return unloading;
		yield break;
	}

	IEnumerator UnloadActiveScene() {
		Scene activeScene = SceneManager.GetActiveScene();
		AsyncOperation unloading = SceneManager.UnloadSceneAsync(activeScene);
		yield return unloading;
		yield break;
	}

	public void ChangeScene(string sceneName) {
		StartCoroutine(UnloadActiveScene());
		StartCoroutine(LoadScene(sceneName));
	}

	public void ChangeScene(int sceneBuildIndex) {
		StartCoroutine(UnloadActiveScene());
		StartCoroutine(LoadScene(sceneBuildIndex));
	}

	public void CloseGame() {
		Application.Quit();
	}
}
