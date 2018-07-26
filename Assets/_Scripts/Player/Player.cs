using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public class HeroContainer {
        public int Order;
        public Hero Hero;
    }

    public Hero Leader;
    public List<HeroContainer> Heroes;

    public void SetLeader(int index) {
        if (Heroes.Count <= index)
            return;
        
        Leader = Heroes[index].Hero;
    }
    
    public void SetLeader(string heroId) {
        var selectedHero = Heroes.Find(hero => hero.Hero.Id == heroId);
        if (selectedHero != null)
            Leader = selectedHero.Hero;
    }
}
