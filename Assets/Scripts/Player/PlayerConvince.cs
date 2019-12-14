using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConvince : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		NpcConvertion npc = other.gameObject.GetComponent<NpcConvertion>();
		if (npc) {
			npc.TryToConvince();
		}
	}
}
