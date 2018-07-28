using UnityEngine;

public class ModelTestSceneManager : BaseSceneManager {

	private GameCamera _gameCamera;
	private TerrainReactor _terrainReactor;
	public Transform HeroHolder;
	public Transform EnemyHolder;
	
	void Awake() {
		_gameCamera = FindObjectOfType<GameCamera>();
		_terrainReactor = FindObjectOfType<TerrainReactor>();
		Game.Init();
	}
	
	// Use this for initialization
	void Start () {
		Game.SpawnHeroes(HeroHolder);
		Game.SpawnEnemies(EnemyHolder);

		_gameCamera.AttachToHero(Game.GetLeaderActor());
		_terrainReactor.OnHitTerrain += OnPlayerClickedPlane;
	}

	void OnDestroy() {
		_terrainReactor.OnHitTerrain -= OnPlayerClickedPlane;
	}

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
