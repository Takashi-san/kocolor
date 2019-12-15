using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour {
	[SerializeField] int _hp = 5;
	[SerializeField] int _maxHp = 5;
	[SerializeField] GameObject[] _blobs = new GameObject[5];

	void Start() {
		_hp = _maxHp;

		switch (_maxHp) {
			case 5:
				Instantiate(_blobs[4], transform.position, Quaternion.identity);
				goto case 4;
			case 4:
				Instantiate(_blobs[3], transform.position, Quaternion.identity);
				goto case 3;
			case 3:
				Instantiate(_blobs[2], transform.position, Quaternion.identity);
				goto case 2;
			case 2:
				Instantiate(_blobs[1], transform.position, Quaternion.identity);
				goto case 1;
			case 1:
				Instantiate(_blobs[0], transform.position, Quaternion.identity);
				break;
		}
	}

	public void Damage(int dmg) {
		_hp -= dmg;
		if (_hp < 0) {
			_hp = 0;
		}
	}

	public void Heal(int heal) {
		_hp += heal;
		if (_hp > _maxHp) {
			_hp = _maxHp;
		}
	}
}
