using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public struct HeroContainer {
        public int Order;
        public Hero Hero;
    }

    public List<HeroContainer> Heroes;
}
