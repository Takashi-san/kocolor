using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSine : MonoBehaviour {
	Rigidbody2D _rb;
	[SerializeField] float _velocity = 0;
	[SerializeField] float _velocitySine = 0;
	[SerializeField] float _sinePeriod = 0;
	[SerializeField] int _damage = 0;
	float _timer = 0;

	void Start() {
		_rb = gameObject.GetComponent<Rigidbody2D>();
		if (!_rb) {
			Debug.Log("No RigidBody2D here!");
		}

		if (_sinePeriod == 0) {
			_sinePeriod = 1;
			Debug.Log("SinePeriod = 0. Zero division!");
		}
	}

	void FixedUpdate() {
		_timer += Time.fixedDeltaTime;
		if (_timer > _sinePeriod) {
			_timer -= _sinePeriod;
		}
		_rb.velocity = new Vector2(Mathf.Sin(2 * Mathf.PI * (_timer / _sinePeriod)) * _velocitySine, -_velocity);
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
