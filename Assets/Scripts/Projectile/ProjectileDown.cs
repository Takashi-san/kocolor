using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDown : MonoBehaviour {
	Rigidbody2D _rb;
	[SerializeField] float _velocity = 0;
	[SerializeField] int _damage = 0;

	void Start() {
		_rb = gameObject.GetComponent<Rigidbody2D>();
		if (!_rb) {
			Debug.Log("No RigidBody2D here!");
		}
	}

	void FixedUpdate() {
		_rb.velocity = new Vector2(_rb.velocity.x, -_velocity);
	}

	void OnTriggerEnter2D(Collider2D other) {
		ShipMovement ship = other.gameObject.GetComponent<ShipMovement>();
		if (ship) {
			ship.GetComponent<ShipHealth>().Damage(_damage);
			// spawna particula explosao.
			Destroy(gameObject);
		}
	}
}
