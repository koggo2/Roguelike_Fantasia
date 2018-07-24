using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageActor : MonoBehaviour {

	public CameraActor CameraActor;
	public Transform HeroHolder;
	public Transform EnemyHolder;

	private Camera _mainCamera;
	private List<HeroActor> _heroes;
	
	// Use this for initialization
	void Start () {
		_mainCamera = Camera.main;
		_heroes = new List<HeroActor>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPlayerClickedPlane(Vector3 clickedPoint) {
		CameraActor.Move(clickedPoint);
		_heroes.ForEach(hero => hero.Move(clickedPoint));
	}

	public void SpawnHeroes() {
		for (var index = 0; index < Data.Player.Heroes.Count; index++) {
			var heroData = Data.Player.Heroes[index];
			var prefabPath = $"Prefabs/Heroes/{heroData.Hero.Id}";
			var hero = Resources.Load<GameObject>(prefabPath);
			if (hero == null)
				return;

			var heroInstance = GameObject.Instantiate(hero);
			heroInstance.tag = TagString.Tag_Hero;
			heroInstance.transform.SetParent(HeroHolder);
			heroInstance.transform.localPosition = CharacterPositioning.GetPosition(index);
			heroInstance.transform.localScale = Vector3.one;
			heroInstance.transform.localRotation = Quaternion.identity;

			var heroActor = heroInstance.GetComponent<HeroActor>();
			heroActor.CharacterIndex = index;

			_heroes.Add(heroActor);
		}
	}

	public void SpawnEnemy() {
		// Using TagString.Tag_Enemy
		var enemy = Resources.Load<GameObject>("Prefabs/Heroes/Hero 1");
		if (enemy == null)
			return;
			
		var heroInstance = GameObject.Instantiate(enemy);
		heroInstance.tag = TagString.Tag_Enemy;
		heroInstance.transform.SetParent(EnemyHolder);
		heroInstance.transform.localPosition = Vector3.zero;
		heroInstance.transform.localScale = Vector3.one;
		heroInstance.transform.localRotation = Quaternion.identity;
	}
}
