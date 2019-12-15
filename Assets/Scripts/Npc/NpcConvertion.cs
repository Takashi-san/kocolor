using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcConvertion : MonoBehaviour {
	InputManager _inputManager;
	GameData _gameData;
	[SerializeField] GameObject _response;
	[Range(-1, 100)] [SerializeField] float _convertionChance = 0;
	[SerializeField] GameObject _reveal;
	NpcCentral _npcCentral;

	void Start() {
		_npcCentral = GetComponent<NpcCentral>();
		if (!_npcCentral) {
			Debug.Log("No NpcCentral here!");
		}

		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();
		if (!_inputManager) {
			Debug.Log("No InputManager found!");
		}

		if (_npcCentral.GetConvinced()) {
			GameObject response = Instantiate(_response, transform.position, Quaternion.identity);
			response.transform.parent = transform;
		}
		_gameData = FindObjectOfType<GameData>().GetComponent<GameData>();
	}

	public void Update() {
		if (_npcCentral.GetConvinced()) {
			if (_inputManager.GetInteract()) {
				GameObject response = Instantiate(_response, transform.position, Quaternion.identity);
				response.transform.parent = transform;
			}
		}
	}

	public void TryToConvince() {
		if (!_npcCentral.GetConvinced()) {
			if (Random.Range(0, 100) < _convertionChance) {
				if (!_npcCentral.GetRepeled()) {
					_gameData.hp++;
					GameObject response = Instantiate(_response, transform.position, Quaternion.identity);
					response.transform.parent = transform;
					_npcCentral.SetConvinced(true);
					if (_reveal) {
						Instantiate(_reveal, transform.position, Quaternion.identity);
						Destroy(gameObject);
					}
				}
			}
			else {
				_npcCentral.SetRepeled(true);
			}
		}
	}
}
