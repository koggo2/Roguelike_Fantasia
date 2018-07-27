using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageActor : MonoBehaviour {

	public Transform HeroHolder;
	public Transform EnemyHolder;

	public void OnPlayerClickedPlane(Vector3 clickedPoint) {
		var leaderHero = Game.GetLeaderActor();
		var direction = (clickedPoint - leaderHero.transform.position).normalized;
		var angle = Vector3.Angle(leaderHero.transform.forward, direction);
		Game.Heroes.ForEach(hero => {
			var pos = CharacterPositioning.GetPosition(hero.CharacterIndex, angle);
			hero.Move(clickedPoint + pos, direction);
		});
	}
}
