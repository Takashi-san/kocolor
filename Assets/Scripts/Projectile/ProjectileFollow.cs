using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollow : MonoBehaviour {
	Rigidbody2D _rb;
	GameObject _player;
	[SerializeField] float _velocity = 0;
	[SerializeField] float _followForce = 0;
	[SerializeField] float _followMultiplier = 1;
	[SerializeField] int _damage = 0;

	void Start() {
		_rb = gameObject.GetComponent<Rigidbody2D>();
		if (!_rb) {
			Debug.Log("No RigidBody2D here!");
		}

		_player = FindObjectOfType<ShipMovement>().gameObject;
		if (!_rb) {
			Debug.Log("No Ship in the scene!");
		}
	}

	void FixedUpdate() {
		if (transform.position.y > _player.transform.position.y) {
			float distance = _player.transform.position.x - transform.position.x;

			if (Mathf.Sign(distance) != Mathf.Sign(_rb.velocity.x)) {
				//_rb.velocity = new Vector2(0, _rb.velocity.y);
				_rb.AddForce(Vector2.right * Mathf.Sign(distance) * _followForce * _followMultiplier);
			}
			else {
				_rb.AddForce(Vector2.right * Mathf.Sign(distance) * _followForce);
			}

		}
		_rb.velocity = new Vector2(_rb.velocity.x, -_velocity);


		if (transform.position.y < -15) {
			Destroy(gameObject);
		}
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
