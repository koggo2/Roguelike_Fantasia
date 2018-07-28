using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageActor : MonoBehaviour {

	public Transform HeroHolder;
	public Transform EnemyHolder;

	public void OnPlayerClickedPlane(Vector3 clickedPoint) {
		var leaderHero = Game.GetLeaderActor();
		var direction = (clickedPoint - leaderHero.transform.position).normalized;
		var angle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
		
		Game.Heroes.ForEach(hero => {
			var pos = CharacterPositioning.GetPosition(hero.CharacterIndex);
			var rotatedPos = Quaternion.Euler(0f, angle, 0f) * pos;
			Debug.Log(pos, angle, rotatedPos);
			hero.Move(clickedPoint + rotatedPos, direction);
		});
	}
}
