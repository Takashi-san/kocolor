using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
	Rigidbody2D _rb;
	InputManager _inputManager;
	[SerializeField] float _force = 0;
	[SerializeField] float _deadForce = 0;
	bool _died = false;

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
		if (!_died) {
			Vector2 movementForce = new Vector2(_inputManager.GetHorizontal(), _inputManager.GetVertical()) * _force;
			_rb.AddForce(movementForce);
		}
	}

	public void Died() {
		_died = true;
		_rb.constraints = RigidbodyConstraints2D.None;
		_rb.AddForce(Vector2.up * _deadForce, ForceMode2D.Impulse);
		_rb.AddTorque(_deadForce);
		_rb.gravityScale = 3;
	}
}
