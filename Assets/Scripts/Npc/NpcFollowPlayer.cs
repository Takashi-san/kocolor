using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFollowPlayer : MonoBehaviour {
	Rigidbody2D _rb;
	GameObject _player;
	NpcCentral _npcCentral;
	[SerializeField] Animator _animator;
	[SerializeField] SpriteRenderer _spriteR;
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

		_offset += Random.Range(0, 4);
	}

	void FixedUpdate() {
		if (_npcCentral.GetConvinced()) {
			float distance = _player.transform.position.x - transform.position.x;
			if (Mathf.Abs(distance) > _offset) {
				Vector2 movementVelocity = new Vector2(Mathf.Sign(distance) * _velocity, _rb.velocity.y);
				_rb.velocity = movementVelocity;

				_animator.SetFloat("speed", Mathf.Abs(movementVelocity.x));
				if (Mathf.Sign(movementVelocity.x) == -1) {
					_spriteR.flipX = true;
				}
				else if (movementVelocity.x > 0) {
					_spriteR.flipX = false;
				}
			}
			else {
				_animator.SetFloat("speed", 0);
			}
		}
		else {
			if (_npcCentral.GetRepeled()) {
				if (_repeledTime > _timer) {
					float distance = _player.transform.position.x - transform.position.x;
					Vector2 movementVelocity = new Vector2(-1 * Mathf.Sign(distance) * _velocity * _repeledModifier, _rb.velocity.y);
					_rb.velocity = movementVelocity;

					_timer += Time.fixedDeltaTime;

					_animator.SetFloat("speed", Mathf.Abs(movementVelocity.x));
					if (Mathf.Sign(movementVelocity.x) == -1) {
						_spriteR.flipX = true;
					}
					else if (movementVelocity.x > 0) {
						_spriteR.flipX = false;
					}
				}
				else {
					_timer = 0;
					_npcCentral.SetRepeled(false);
					_animator.SetFloat("speed", 0);
				}
			}
		}
	}
}
