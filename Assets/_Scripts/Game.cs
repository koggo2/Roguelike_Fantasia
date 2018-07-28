using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game {

    public static List<HeroActor> Heroes => _heroes;
    private static List<HeroActor> _heroes = new List<HeroActor>();
    
    public static void Init() {
        Debug.Log("Game is Initialized");
        Data.InitTestData();
    }
    
    public static HeroActor GetLeaderActor() {
        return _heroes.Find(actor => actor.name == Data.Player.Leader.Id);
    }
    
    public static void SpawnHeroes(StageActor stageActor) {
        for (var index = 0; index < Data.Player.Heroes.Count; index++) {
            var heroData = Data.Player.Heroes[index];
            var prefabPath = $"Prefabs/Heroes/{heroData.Hero.Id}";
            var hero = Resources.Load<GameObject>(prefabPath);
            if (hero == null)
                return;

            var heroInstance = GameObject.Instantiate(hero);
            heroInstance.tag = TagString.Tag_Hero;
            heroInstance.transform.SetParent(stageActor.HeroHolder);
            heroInstance.transform.localPosition = CharacterPositioning.GetPosition(index);
            heroInstance.transform.localScale = Vector3.one;
            heroInstance.transform.localRotation = Quaternion.identity;
            heroInstance.name = heroData.Hero.Id;

            var heroActor = heroInstance.GetComponent<HeroActor>();
            heroActor.CharacterIndex = index;

            _heroes.Add(heroActor);
        }
    }
    
    public static void SpawnEnemies(StageActor stageActor) {
        // Using TagString.Tag_Enemy
        var enemy = Resources.Load<GameObject>("Prefabs/Heroes/Hero 1");
        if (enemy == null)
            return;
			
        var heroInstance = GameObject.Instantiate(enemy);
        heroInstance.tag = TagString.Tag_Enemy;
        heroInstance.transform.SetParent(stageActor.EnemyHolder);
        heroInstance.transform.localPosition = Vector3.zero;
        heroInstance.transform.localScale = Vector3.one;
        heroInstance.transform.localRotation = Quaternion.identity;
    }
}
