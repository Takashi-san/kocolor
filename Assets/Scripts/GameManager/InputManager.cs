using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	float _horizontal, _vertical;
	bool _interact, _go;

	// Em Edit >> Project Settings... >> Script Execution Order, foi colocado para ser executado antes de todos.
	void Update() {
		// Tempo que leva para atingir valor máximo pode ser ajustado em Edit >> Project Settings... >> Input.
		// A (-1) <-> D (1).
		_horizontal = Input.GetAxis("Horizontal");
		// S (-1) <-> W (1).
		_vertical = Input.GetAxis("Vertical");

		_interact = Input.GetKeyDown(KeyCode.E);
		_go = Input.GetKeyDown(KeyCode.Q);
	}

	public float GetHorizontal() {
		return _horizontal;
	}

	public float GetVertical() {
		return _vertical;
	}

	public bool GetInteract() {
		return _interact;
	}

	public bool GetGo() {
		return _go;
	}
}
