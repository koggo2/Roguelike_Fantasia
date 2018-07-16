using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageActor : MonoBehaviour {

	public Transform HeroHolder;
	public Transform EnemyHolder;

	private GameObject _heroInstance;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPlayerClickedPlane(Vector3 clickedPoint) {
		Debug.Log(clickedPoint.ToString());

		_heroInstance.GetComponent<HeroActor>().Move(clickedPoint);
	}

	public void SpawnHeroes() {
		foreach (var heroData in Data.Player.Heroes) {
			var prefabPath = $"Prefabs/Heroes/{heroData.Hero.Id}";
			var hero = Resources.Load<GameObject>(prefabPath);
			if (hero == null)
				return;
			
			var heroInstance = GameObject.Instantiate(hero);
			heroInstance.tag = TagString.Tag_Hero;
			heroInstance.transform.SetParent(HeroHolder);
			heroInstance.transform.localPosition = Vector3.zero;
			heroInstance.transform.localScale = Vector3.one;
			heroInstance.transform.localRotation = Quaternion.identity;

			_heroInstance = heroInstance;
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

		_heroInstance = heroInstance;
	}
}
