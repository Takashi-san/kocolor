using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcConvertion : MonoBehaviour {
	[SerializeField] GameObject _response;
	NpcCentral _npcCentral;

	void Start() {
		_npcCentral = GetComponent<NpcCentral>();
		if (!_npcCentral) {
			Debug.Log("No NpcCentral here!");
		}
	}

	public void TryToConvince() {
		if (!_npcCentral.GetConvinced()) {
			if (Random.Range(0, 10) < 5) {
				GameObject response = Instantiate(_response, transform.position, Quaternion.identity);
				response.transform.parent = transform;
				_npcCentral.SetConvinced(true);
			}
		}
	}
}
