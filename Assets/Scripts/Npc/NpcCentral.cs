using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCentral : MonoBehaviour {
	bool _convinced;

	public void SetConvinced(bool isIt) {
		_convinced = isIt;
	}

	public bool GetConvinced() {
		return _convinced;
	}
}
