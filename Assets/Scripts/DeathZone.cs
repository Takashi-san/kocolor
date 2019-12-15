using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {
	[SerializeField] int _damage = 0;
	[SerializeField] float _force = 0;
	[SerializeField] string _cena;
	[SerializeField] string _cenaWin;
	public bool win = false;

	void OnTriggerEnter2D(Collider2D other) {
		ShipMovement ship = other.gameObject.GetComponent<ShipMovement>();
		if (ship) {
			if (ship.GetComponent<ShipHealth>().GetHealth() == 0) {
				if (!win) {
					FindObjectOfType<StageManager>().GetComponent<StageManager>().ChangeScene(_cena);
				}
				else {
					FindObjectOfType<StageManager>().GetComponent<StageManager>().ChangeScene(_cenaWin);
				}
			}
			else {
				ship.GetComponent<ShipHealth>().Damage(_damage);
				ship.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force, ForceMode2D.Impulse);
			}
		}
	}
}
