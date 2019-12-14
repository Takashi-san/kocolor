using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnExitMono : MonoBehaviour {
	public void DeactivateOnExit(Animator animator, AnimatorStateInfo stateInfo) {
		StartCoroutine(WaitToFinish(animator, stateInfo));
	}

	IEnumerator WaitToFinish(Animator animator, AnimatorStateInfo stateInfo) {
		yield return new WaitForSeconds(stateInfo.length);
		animator.gameObject.SetActive(false);
		yield break;
	}
}
