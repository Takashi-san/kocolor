using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
	Rigidbody2D _rb;
	InputManager _inputManager;
	[SerializeField] float _force = 0;

	void Start() {
		_rb = gameObject.GetComponent<Rigidbody2D>();
		if (!_rb) {
			Debug.Log("No RigidBody2D here!");
		}

		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();
		if (!_inputManager) {
			Debug.Log("No InputManager found!");
		}
	}

	void FixedUpdate() {
		Vector2 movementForce = new Vector2(_inputManager.GetHorizontal(), _inputManager.GetVertical()) * _force;
		_rb.AddForce(movementForce);
	}
}
