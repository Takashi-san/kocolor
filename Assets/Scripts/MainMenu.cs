using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator animator;

    public void PlayGame(){
        animator.SetTrigger("FadeOut");
    }

    public void QuitGame(){
        Application.Quit();
    }

}