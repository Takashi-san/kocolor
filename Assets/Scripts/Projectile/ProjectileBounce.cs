using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBounce : MonoBehaviour {
	Rigidbody2D _rb;
	[SerializeField] float _force = 0;
	[SerializeField] int _damage = 0;
	bool once = true;

	void Start() {
		_rb = gameObject.GetComponent<Rigidbody2D>();
		if (!_rb) {
			Debug.Log("No RigidBody2D here!");
		}

		bool boolean = (Random.value > 0.5f);
		if (boolean) {
			transform.rotation = Quaternion.Euler(0, 0, -15 + Random.Range(-15, 0));
		}
		else {
			transform.rotation = Quaternion.Euler(0, 0, -180 + 15 + Random.Range(0, 15));
		}
	}

	void FixedUpdate() {
		if (once && (transform.rotation.eulerAngles.z != 0)) {
			_rb.AddRelativeForce(Vector2.right * _force, ForceMode2D.Impulse);
			once = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		ShipMovement ship = other.gameObject.GetComponent<ShipMovement>();
		if (ship) {
			ship.GetComponent<ShipHealth>().Damage(_damage);
			// spawna particula explosao.
			Destroy(gameObject);
		}
	}
}
