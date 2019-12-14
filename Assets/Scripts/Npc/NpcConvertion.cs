using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcConvertion : MonoBehaviour {
	[SerializeField] GameObject _response;

	public void TryToConvince() {
		if (Random.Range(0, 10) < 5) {
			Debug.Log("Convinced!");
			GameObject response = Instantiate(_response, transform.position, Quaternion.identity);
			response.transform.parent = transform;
		}
	}
}
