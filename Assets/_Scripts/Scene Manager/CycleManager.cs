using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleManager : MonoBehaviour {

    private List<HeroActor> _heroes;

    private void Start() {
        StartCoroutine(CheckActorCondition());
    }

    public void AddHero(HeroActor actor) {
        if (_heroes.Contains(actor))
            return;
        
        _heroes.Add(actor);
    }

    public void RemoveHero(HeroActor actor) {
        if (!_heroes.Contains(actor))
            return;
        
        _heroes.Remove(actor);
    }

    private IEnumerator CheckActorCondition() {

        foreach (var hero in _heroes) {
            hero.CheckCondition();
        }
        
        yield break;
    }
}
