using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartsPlease
{


    public class GameState : MonoBehaviour
    {
        public bool WarMeterAdjusted = false;
        bool ButtonsDisabled = false;
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

        public void disableButtons()
        {
            this.ButtonsDisabled = true;
        }

        public void ToggleWarMeter(bool state)
        {
            this.WarMeterAdjusted = state;
        }
    }
}
