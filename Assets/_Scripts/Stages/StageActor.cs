using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageActor : MonoBehaviour {

	public Transform HeroHolder;
	public Transform EnemyHolder;

	public void OnPlayerClickedPlane(Vector3 clickedPoint) {
		Game.Heroes.ForEach(hero => hero.Move(clickedPoint));
	}
}
