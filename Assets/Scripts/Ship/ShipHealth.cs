using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour {
	[SerializeField] int _hp = 5;
	[SerializeField] int _maxHp = 5;

	void Start() {
		_hp = _maxHp;
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
