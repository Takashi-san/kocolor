using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour {
	[SerializeField] int _num = 0;
	[SerializeField] GameObject[] _people;

	void Start() {
		for (int i = 0; i < _num; i++) {
			Vector2 random = new Vector2(Random.Range(-40f, 40f), -3);
			Instantiate(_people[Random.Range(0, _people.Length)], random, Quaternion.identity);
		}
	}
}
