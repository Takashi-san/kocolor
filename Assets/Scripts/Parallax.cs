using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
	Rigidbody2D _player;
	Rigidbody2D _rb;
	[SerializeField] float _multiplier;
	[SerializeField] float _limit;
	[SerializeField] float _half;

	void Start() {
		_player = FindObjectOfType<PlayerWalk>().GetComponent<Rigidbody2D>();
		_rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		if (Mathf.Abs(_player.transform.position.x) <= _limit - _half) {
			_rb.velocity = _multiplier * new Vector2(_player.velocity.x, 0);
		}
		else {
			_rb.velocity = Vector2.zero;
		}
	}
}
