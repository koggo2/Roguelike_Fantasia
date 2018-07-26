using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data {

    public static Player Player { get; private set; }

#if TEST
    public static void InitTestData() {
         Player = new Player() {
             Heroes = new List<Player.HeroContainer>() {
                 new Player.HeroContainer() {
                     Order = 1,
                     Hero = new Hero() {
                         Id = "Hero_Rogue_1",
                         Relics = new List<string>(),
                     }
                 },
                 new Player.HeroContainer() {
                     Order = 1,
                     Hero = new Hero() {
                         Id = "Hero_Mage_1",
                         Relics = new List<string>(),
                     }
                 }
             }
         };

        Player.SetLeader(0);
    }
#endif
    
}
