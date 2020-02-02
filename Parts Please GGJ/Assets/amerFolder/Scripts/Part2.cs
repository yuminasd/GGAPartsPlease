using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PartsPlease
{
    public enum PartState
    {
        Working,
        NotWorking
    }


    public enum PartType
    {
        Bulb,
        Gear,
        Scope,
    }





    public class Part : MonoBehaviour
    {

        public RawImage partImage;
        public RawImage[] partImages;
        public int x;
        public int y;


        short serialNumber;
        public PartState state;


        void Start()
        {

     
        }

    

        public void assignAttributes ()
        {
            
            int i = Random.Range(0, 3);
            Debug.Log("starting new item:" + i);
 

            switch (i) {
                case 0:
                    partImage.texture = partImages[0].texture;
                    break;
                case 1:
                    partImage.texture = partImages[1].texture;
                    break;
                case 2:
                    partImage.texture = partImages[2].texture;
                    break;


            }

            partImage.rectTransform.sizeDelta = new Vector2(50, 50);

        }



    }   

}