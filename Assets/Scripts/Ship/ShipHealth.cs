using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour {
	[SerializeField] int _hp = 5;
	[SerializeField] int _maxHp = 5;
	[SerializeField] GameObject[] _blobs = new GameObject[5];
	GameObject[] _LifeBlobs = new GameObject[5];
	GameData _gameData;

	void Start() {
		_gameData = FindObjectOfType<GameData>().GetComponent<GameData>();
		_maxHp = _gameData.hp;
		_hp = _maxHp;

		switch (_maxHp) {
			case 5:
				_LifeBlobs[4] = Instantiate(_blobs[4], transform.position, Quaternion.identity);
				goto case 4;
			case 4:
				_LifeBlobs[3] = Instantiate(_blobs[3], transform.position, Quaternion.identity);
				goto case 3;
			case 3:
				_LifeBlobs[2] = Instantiate(_blobs[2], transform.position, Quaternion.identity);
				goto case 2;
			case 2:
				_LifeBlobs[1] = Instantiate(_blobs[1], transform.position, Quaternion.identity);
				goto case 1;
			case 1:
				_LifeBlobs[0] = Instantiate(_blobs[0], transform.position, Quaternion.identity);
				break;
		}
	}

	public void Damage(int dmg) {
		_hp -= dmg;
		if (_hp < 0) {
			_hp = 0;
		}
		if (_hp == 0) {
			GetComponent<ShipMovement>().Died();
		}

		for (int i = _hp; i < 5; i++) {
			if (_LifeBlobs[i]) {
				_LifeBlobs[i].GetComponent<Blobs>().Die();
			}
		}
	}

	public void Heal(int heal) {
		_hp += heal;
		if (_hp > _maxHp) {
			_hp = _maxHp;
		}
	}

	public int GetHealth() {
		return _hp;
	}
}
