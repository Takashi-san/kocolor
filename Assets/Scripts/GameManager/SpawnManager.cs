using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	[SerializeField] GameObject _projectileWave;
	[SerializeField] GameObject _projectileStraight;
	[SerializeField] GameObject _projectileSine;
	[SerializeField] GameObject _projectileFollow;

	[SerializeField] int[] _num = new int[4];
	[SerializeField] float[] _min = new float[4];
	[SerializeField] float[] _max = new float[4];

	float _topY = 6;
	float _absX = 3.5f;

	void Start() {
		StartCoroutine(rain(_projectileWave, _num[0], _min[0], _max[0]));
		StartCoroutine(rain(_projectileStraight, _num[1], _min[1], _max[1]));
		StartCoroutine(rain(_projectileSine, _num[2], _min[2], _max[2]));
		StartCoroutine(rain(_projectileFollow, _num[3], _min[3], _max[3]));
	}

	void Spawn(GameObject projectile, int num) {
		for (int i = 0; i < num; i++) {
			Vector3 random = new Vector3(Random.Range(-_absX, _absX), _topY, 0);
			Instantiate(projectile, random, projectile.transform.rotation);
		}
	}

	IEnumerator rain(GameObject projectile, int num, float min, float max) {
		Spawn(projectile, num);
		yield return new WaitForSeconds(Random.Range(min, max));
		StartCoroutine(rain(projectile, num, min, max));
		yield break;
	}
}
