using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartsPlease
{


    public class GameState
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
            player = new Player();
            currentCustomer = new Customer();
            currentItem = new Item();
        }
    }
}
