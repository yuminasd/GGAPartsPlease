using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartsPlease
{


    public class GameState
    {
        World world;
        Player player;
        Customer currentCustomer;
        Item currentItem;

        public GameState()
        {
            reset();
        }

        public void reset()
        {
            world = new World();
            player = new Player();
            //player
            currentCustomer = new Customer();
            currentItem = new Item();
        }
    }
}
