using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {
	[SerializeField] int _damage = 0;
	[SerializeField] float _force = 0;



	void OnTriggerEnter2D(Collider2D other) {
		ShipMovement ship = other.gameObject.GetComponent<ShipMovement>();
		if (ship) {
			if (ship.GetComponent<ShipHealth>().GetHealth() == 0) {
				FindObjectOfType<StageManager>().GetComponent<StageManager>().ChangeScene("Convert");
			}
			else {
				ship.GetComponent<ShipHealth>().Damage(_damage);
				ship.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force, ForceMode2D.Impulse);
			}
		}
	}
}
