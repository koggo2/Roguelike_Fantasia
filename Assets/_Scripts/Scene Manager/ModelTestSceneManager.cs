using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTestSceneManager : BaseSceneManager {

	private StageActor _stageActor;
	
	void Awake() {
		Data.InitTestData();
		_stageActor = FindObjectOfType<StageActor>();
	}
	
	// Use this for initialization
	void Start () {
		if (_stageActor != null) {
			_stageActor.SpawnHeroes();
			_stageActor.SpawnEnemy();
		}
	}
}
