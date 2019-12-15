using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogAutoScroll : MonoBehaviour {
	Rigidbody2D _rb;
	[SerializeField] float _velocity;
	bool _once = false;

	void Start() {
		_rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (!_once) {
			if (Mathf.Abs(transform.position.y) < 1) {
				Instantiate(gameObject, new Vector3(0, 11, 0), Quaternion.identity);
				_once = true;
			}
		}

		if (transform.position.y < -11) {
			Destroy(gameObject);
		}
	}

	void FixedUpdate() {
		_rb.velocity = Vector2.down * _velocity;
	}
}
