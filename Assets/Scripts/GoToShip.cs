using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToShip : MonoBehaviour {
	InputManager _inputManager;
	StageManager _stageManager;
	GameData _gameData;
	[SerializeField] string _cena;
	[SerializeField] int _condition;
	[SerializeField] GameObject ascend;

	void Start() {
		_stageManager = FindObjectOfType<StageManager>().GetComponent<StageManager>();
		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();
		_gameData = FindObjectOfType<GameData>().GetComponent<GameData>();
		if (!_inputManager) {
			Debug.Log("No InputManager found!");
		}
	}

	void Update() {
		if (_gameData.hp == _condition) {
			if (ascend) {
				ascend.SetActive(true);
			}
		}
		if (_inputManager.GetGo()) {
			if (_gameData.hp == _condition) {
				_stageManager.ChangeScene(_cena);
			}
		}
	}
}
