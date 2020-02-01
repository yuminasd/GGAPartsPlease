using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartsPlease
{


    public class GameState : MonoBehaviour
    {
        int ThreatLevel = 0;
        
        Player player;
        public Customer currentCustomer;
        Item currentItem;

        public GameState()
        {
            reset();
        }

        public void reset()
        {
            //player = new Player();
            //currentItem = new Item();
        }
    }
}
