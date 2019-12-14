using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCircular : MonoBehaviour {
	[SerializeField] float _pushForce = 0;
	[SerializeField] bool _done = false;

	void OnTriggerEnter2D(Collider2D other) {
		ShipMovement ship = other.gameObject.GetComponent<ShipMovement>();
		if (ship) {
			if (!_done) {
				Vector2 direction = (ship.gameObject.transform.position - transform.position);
				ship.GetComponent<Rigidbody2D>().AddForce(direction.normalized * _pushForce, ForceMode2D.Impulse);
				_done = true;
			}
		}
	}

	public void Reset() {
		_done = false;
	}
}
