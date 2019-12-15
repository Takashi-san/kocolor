using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobs : MonoBehaviour {
	GameObject _player;
	Rigidbody2D _rb;
	[SerializeField] float _velocity = 0;
	[SerializeField] int _order = 0;
	[SerializeField] float _offset = 0;
	[SerializeField] GameObject _explosion;

	void Start() {
		_player = FindObjectOfType<ShipMovement>().gameObject;
		_rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		Vector2 distance = _player.transform.position - transform.position;
		if (distance.magnitude > _offset * _order) {
			_rb.velocity = distance.normalized * _velocity;
		}
		else {
			_rb.velocity *= 0.5f;
		}
	}

	public void Die() {
		Instantiate(_explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
