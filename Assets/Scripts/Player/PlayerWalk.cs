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
	}

	void FixedUpdate() {
		_rb.velocity = (Vector2.up * _inputManager.GetVertical() + Vector2.right * _inputManager.GetHorizontal()) * _velocity;
	}
}
