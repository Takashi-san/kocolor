using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;

    public void FadeToLevel(){
        animator.SetTrigger("FadeOut");
    }

    public void OnLevelComplete(){
        SceneManager.LoadScene("convert");
    }
}
