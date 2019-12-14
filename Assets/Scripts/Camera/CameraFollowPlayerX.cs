using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerX : MonoBehaviour {
	GameObject _player;
	Rigidbody2D _rb;
	[SerializeField] float _limit;
	[SerializeField] float _half;

	void Start() {
		_player = FindObjectOfType<PlayerWalk>().gameObject;
		_rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		if (Mathf.Abs(_player.transform.position.x) > _limit - _half) {
			_rb.MovePosition(new Vector2(Mathf.Sign(_player.transform.position.x) * (_limit - _half), transform.position.y));
		}
		else {
			_rb.MovePosition(new Vector2(_player.transform.position.x, transform.position.y));
		}
	}
}
