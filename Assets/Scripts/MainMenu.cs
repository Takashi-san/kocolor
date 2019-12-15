using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public Animator animator;

	public void PlayGame() {
		animator.SetTrigger("Converter0");
	}

	public void QuitGame() {
		Application.Quit();
	}

}
