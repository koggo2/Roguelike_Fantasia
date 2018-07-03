using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data {

     public static Player Player { get; private set; }

    public static void InitData() {
         Player = new Player() {
             Heroes = new List<Player.HeroContainer>() {
                 new Player.HeroContainer() {
                     Order = 1,
                     Hero = new Hero() {
                         Name = "Test Hero",
                     }
                 }
             }
         };
     }
}
