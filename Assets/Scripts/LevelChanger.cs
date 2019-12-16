using UnityEngine;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;

    public void FadeToLevel(){
        animator.SetTrigger("FadeOut");
    }

}
