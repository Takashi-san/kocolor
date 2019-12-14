using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCentral : MonoBehaviour {
	[SerializeField] bool _convinced = false;
	[SerializeField] bool _repeled = false;

	public void SetConvinced(bool isIt) {
		_convinced = isIt;
	}

	public bool GetConvinced() {
		return _convinced;
	}

	public void SetRepeled(bool isIt) {
		_repeled = isIt;
	}

	public bool GetRepeled() {
		return _repeled;
	}
}
