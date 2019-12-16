using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {
	[SerializeField] int _damage = 0;
	[SerializeField] float _force = 0;
	[SerializeField] string _cena;
	[SerializeField] string _cenaWin;
	public bool win = false;
	public bool fim = false;
	bool once = true;

	void Update() {
		if (fim && once && win) {
			FindObjectOfType<StageManager>().GetComponent<StageManager>().ChangeScene("Fim");
			once = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		ShipMovement ship = other.gameObject.GetComponent<ShipMovement>();
		if (ship) {
			if (ship.GetComponent<ShipHealth>().GetHealth() == 0) {
				if (!win) {
					FindObjectOfType<StageManager>().GetComponent<StageManager>().ChangeScene(_cena);
				}
				else {
					if (fim) {
						FindObjectOfType<StageManager>().GetComponent<StageManager>().ChangeScene("Fim");
					}
					else {
						FindObjectOfType<StageManager>().GetComponent<StageManager>().ChangeScene(_cenaWin);
					}
				}
			}
			else {
				ship.GetComponent<ShipHealth>().Damage(_damage);
				ship.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force, ForceMode2D.Impulse);
			}
		}
	}

	IEnumerator Fim() {
		yield return new WaitForSeconds(3);
		FindObjectOfType<StageManager>().GetComponent<StageManager>().ChangeScene("Fim");
	}
}
