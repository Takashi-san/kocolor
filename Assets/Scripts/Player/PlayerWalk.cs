using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour {
	Rigidbody2D _rb;
	InputManager _inputManager;
	[SerializeField] float _velocity = 0;

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
		Vector2 movementVelocity = new Vector2(_inputManager.GetHorizontal() * _velocity, _rb.velocity.y);
		_rb.velocity = movementVelocity;
	}
}
