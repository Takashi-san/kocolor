﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour {
	Rigidbody2D _rb;
	InputManager _inputManager;
	[SerializeField] Animator _animator;
	[SerializeField] SpriteRenderer _spriteR;
	[SerializeField] float _velocity = 0;
	GameData _gameData;
	[SerializeField] int _inicialHp = 0;

	void Start() {
		_rb = gameObject.GetComponent<Rigidbody2D>();
		if (!_rb) {
			Debug.Log("No RigidBody2D here!");
		}

		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();
		if (!_inputManager) {
			Debug.Log("No InputManager found!");
		}

		_gameData = FindObjectOfType<GameData>().GetComponent<GameData>();
		_gameData.hp = _inicialHp;
	}

	void FixedUpdate() {
		Vector2 movementVelocity = new Vector2(_inputManager.GetHorizontal() * _velocity, _rb.velocity.y);
		_rb.velocity = movementVelocity;

		_animator.SetFloat("speed", Mathf.Abs(movementVelocity.x));
		if (Mathf.Sign(movementVelocity.x) == -1) {
			_spriteR.flipX = true;
		}
		else if (movementVelocity.x > 0) {
			_spriteR.flipX = false;
		}
	}
}
