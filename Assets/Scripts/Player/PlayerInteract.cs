using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
	InputManager _inputManager;
	[SerializeField] GameObject _area;

	void Start() {
		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();
		if (!_inputManager) {
			Debug.Log("No InputManager found!");
		}
	}

	void Update() {
		if (_inputManager.GetInteract()) {
			if (_area) {
				GameObject scream = Instantiate(_area, transform.position, Quaternion.identity);
				scream.transform.parent = transform;
			}
			else {
				Debug.Log("No interact area!");
			}
		}
	}
}
