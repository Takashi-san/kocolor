using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcConvertion : MonoBehaviour {
	[SerializeField] GameObject _response;
	[Range(0, 100)] [SerializeField] float _convertionChance = 0;
	NpcCentral _npcCentral;

	void Start() {
		_npcCentral = GetComponent<NpcCentral>();
		if (!_npcCentral) {
			Debug.Log("No NpcCentral here!");
		}
	}

	public void TryToConvince() {
		if (!_npcCentral.GetConvinced()) {
			if (Random.Range(0, 100) < _convertionChance) {
				if (!_npcCentral.GetRepeled()) {
					GameObject response = Instantiate(_response, transform.position, Quaternion.identity);
					response.transform.parent = transform;
					_npcCentral.SetConvinced(true);
				}
			}
			else {
				_npcCentral.SetRepeled(true);
			}
		}
	}
}
