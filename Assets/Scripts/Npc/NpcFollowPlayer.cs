﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFollowPlayer : MonoBehaviour {
	Rigidbody2D _rb;
	GameObject _player;
	NpcCentral _npcCentral;
	[SerializeField] float _velocity = 0;
	[SerializeField] float _offset = 0;
	[Range(0, 1)] [SerializeField] float _repeledModifier = 0;
	[SerializeField] float _repeledTime = 0;
	float _timer = 0;

	void Start() {
		_rb = gameObject.GetComponent<Rigidbody2D>();
		if (!_rb) {
			Debug.Log("No RigidBody2D here!");
		}

		_npcCentral = GetComponent<NpcCentral>();
		if (!_npcCentral) {
			Debug.Log("No NpcCentral here!");
		}

		_player = FindObjectOfType<PlayerWalk>().gameObject;
		if (!_player) {
			Debug.Log("No Player in scene!");
		}
	}

	void FixedUpdate() {
		if (_npcCentral.GetConvinced()) {
			float distance = _player.transform.position.x - transform.position.x;
			if (Mathf.Abs(distance) > _offset) {
				Vector2 movementVelocity = new Vector2(Mathf.Sign(distance) * _velocity, _rb.velocity.y);
				_rb.velocity = movementVelocity;
			}
		}
		else {
			if (_npcCentral.GetRepeled()) {
				if (_repeledTime > _timer) {
					float distance = _player.transform.position.x - transform.position.x;
					Vector2 movementVelocity = new Vector2(-1 * Mathf.Sign(distance) * _velocity * _repeledModifier, _rb.velocity.y);
					_rb.velocity = movementVelocity;

					_timer += Time.fixedDeltaTime;
				}
				else {
					_timer = 0;
					_npcCentral.SetRepeled(false);
				}
			}
		}

	}
}