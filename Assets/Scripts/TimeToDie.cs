using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDie : MonoBehaviour {
	[SerializeField] float _surviveTime;
	[SerializeField] GameObject _projectile;
	float _timer = 0;
	bool _once = true;

	float _topY = 6;
	float _absX = 3.5f;

	void Update() {
		_timer += Time.deltaTime;
		if ((_timer > _surviveTime) && _once) {
			StartCoroutine(rain(_projectile, 0, 0.1f, 0.5f));
			FindObjectOfType<DeathZone>().win = true;
			_once = false;
		}
	}

	void Spawn(GameObject projectile, int num) {
		for (int i = 0; i < num; i++) {
			Vector3 random = new Vector3(Random.Range(-_absX, _absX), _topY, 0);
			Instantiate(projectile, random, projectile.transform.rotation);
		}
	}

	IEnumerator rain(GameObject projectile, int num, float min, float max) {
		Spawn(projectile, Random.Range(5, 10));
		yield return new WaitForSeconds(Random.Range(min, max));
		StartCoroutine(rain(projectile, num, min, max));
		yield break;
	}
}
