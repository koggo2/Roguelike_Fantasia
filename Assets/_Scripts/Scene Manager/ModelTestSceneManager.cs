using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;

public class ModelTestSceneManager : BaseSceneManager {

	private GameCamera _gameCamera;
	public Transform HeroHolder;
	public Transform EnemyHolder;
	public Transform StageHolder;

	private List<TerrainReactor> _terrainReactors;
	
	void Awake() {
		_gameCamera = FindObjectOfType<GameCamera>();
		_terrainReactors = new List<TerrainReactor>();

		Game.Init();
	}
	
	// Use this for initialization
	void Start () {
		Game.SpawnHeroes(HeroHolder);
		Game.SpawnEnemies(EnemyHolder);

		var fieldPrefab = Resources.Load<GameObject>("Prefabs/Fields/Field_1");
		if (fieldPrefab != null) {
			for (int i = 0; i < 2; ++i) {
				var instanceField = Instantiate(fieldPrefab);
				instanceField.transform.SetParent(StageHolder);
				instanceField.transform.localPosition = new Vector3(0f, 0f, 100f * i);
				instanceField.transform.localScale = Vector3.one;
				instanceField.transform.localRotation = Quaternion.identity;
				
				instanceField.GetComponent<NavMeshSurface>().BuildNavMesh();
				
				var reactor = instanceField.GetComponentInChildren<TerrainReactor>(); 
				reactor.OnHitTerrain += OnPlayerClickedPlane;
				_terrainReactors.Add(reactor);
			}
		}

		_gameCamera.AttachToHero(Game.GetLeaderActor());
	}

	void OnDestroy() {
		_terrainReactors.ForEach(reactor => reactor.OnHitTerrain -= OnPlayerClickedPlane);
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
