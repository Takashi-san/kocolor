using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Animator animator;

	public void PlayGame() {
		animator.SetTrigger("Converter0");
	}

	public void QuitGame() {
		Application.Quit();
	}

}
