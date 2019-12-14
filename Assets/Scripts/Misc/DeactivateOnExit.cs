using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnExit : StateMachineBehaviour {
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.GetComponent<DeactivateOnExitMono>().DeactivateOnExit(animator, stateInfo);
	}
}
