using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTestSceneManager : BaseSceneManager {

	private CameraActor _cameraActor;
	private StageActor _stageActor;
	
	void Awake() {
		_cameraActor = FindObjectOfType<CameraActor>();
		_stageActor = FindObjectOfType<StageActor>();
		Game.Init();
	}
	
	// Use this for initialization
	void Start () {
		Game.SpawnHeroes(_stageActor);
		Game.SpawnEnemies(_stageActor);

		_cameraActor.AttachToHero(Game.GetLeaderActor());
	}
}
