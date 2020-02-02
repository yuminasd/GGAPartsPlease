using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PartsPlease
{

    public class Customer2 : MonoBehaviour
    {

       


        public Faction faction;
        public Hostility hostility;
        public RawImage image;

        void Start()
        {

            image = GetComponentInChildren<RawImage>();

            switch (Random.Range(0, 3))
            {

                case 0:
                    faction = Faction.Neutral;
                    image.color = Color.gray;
                    break;
                case 1:
                    faction = Faction.Blufor;
                    image.color = Color.blue;
                    break;
                case 2:
                    faction = Faction.Opfor;
;
                    image.color = Color.red;
                    break;
                default:
                    faction = Faction.Neutral;
                    break;
            }

            switch (Random.Range(0, 3))
            {

                case 0:
                    hostility = Hostility.Neutral;
                    break;
                case 1:
                    hostility = Hostility.Escalate;
                    break;
                case 2:
                    hostility = Hostility.Deescalate;
                    break;
                default:
                    hostility = Hostility.Neutral;
                    break;

            }





        }


    }
}