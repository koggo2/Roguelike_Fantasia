using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIManager : MonoBehaviour {

	protected BaseSceneManager _sceneManager;

	private void Awake() {
		_sceneManager = GetComponentInParent<BaseSceneManager>();
	}
}
