using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace PartsPlease 
{

    public class Item : MonoBehaviour
    {
        string modelName;
        public int tier;
        public int baseGunDifficulty;


        //all the parts
        [SerializeField]
        public Part[] partsScripts;
        public RawImage weaponImage;
        public RawImage[] possibleImages;
    
        


        public GameObject part;
        public GameObject[] parts;


        public Vector2[] positions;
        



        void Start()
        {
            
            switch (this.tier) {
                case 1:
                    parts = new GameObject[3];
                    partsScripts = new Part[3];
                    positions = new Vector2[3];
                    weaponImage.texture = possibleImages[0].texture;
                    break;
                case 2:
                    parts = new GameObject[4];
                    partsScripts = new Part[4];
                    positions = new Vector2[4];
                    weaponImage.texture = possibleImages[1].texture;
               

                    break;
                case 3:
                    parts = new GameObject[4];
                    partsScripts = new Part[4];
                    positions = new Vector2[4];
                    weaponImage.texture = possibleImages[2].texture;
                    weaponImage.rectTransform.sizeDelta = possibleImages[2].rectTransform.sizeDelta;
                    break;
                case 4:
                    parts = new GameObject[5];
                    partsScripts = new Part[5];
                    positions = new Vector2[5];
                    weaponImage.texture = possibleImages[3].texture;
                    break;

            }

            initializeParts(parts);
            partPositions(positions);
            calculateDifficulty(baseGunDifficulty);
            getDifficulty();

        }
        public void initializeParts(GameObject[] parts)
        {
            for (int i = 0; i < parts.Length; i++)
            {
               

                parts[i] = Instantiate(part);
                parts[i].transform.parent = gameObject.transform;
                partsScripts[i] = parts[i].GetComponent<Part>();
                partsScripts[i].assignAttributes();


            }

        }

        public void partPositions (Vector2[] pos)
        {
            switch (tier) {

                case 1:
                    pos[0] = new Vector2(10, 0);
                    pos[1] = new Vector2(20, 0);
                    pos[2] = new Vector2(30, 10);

                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i].transform.localPosition = pos[i];
                    }

                    break;
                  
                case 2:
                    pos[0] = new Vector2(10, 0);
                    pos[1] = new Vector2(20, 0);
                    pos[2] = new Vector2(30, 10);
                    pos[3] = new Vector2(30, 10);

                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i].transform.localPosition = pos[i];
                    }

                    break;
                case 3:
                    pos[0] = new Vector2(-60, 25);
                    pos[1] = new Vector2(0, 50);
                    pos[2] = new Vector2(60, 40);
                    pos[3] = new Vector2(0, -15);

                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i].transform.localPosition = pos[i];
                    }
                    break;
                case 4:
                    pos[0] = new Vector2(10, 0);
                    pos[1] = new Vector2(20, 0);
                    pos[2] = new Vector2(30, 10);
                    pos[3] = new Vector2(30, 10);
                    pos[4] = new Vector2(30, 10);

                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i].transform.localPosition = pos[i];
                    }
                    break;

            }




        }


        public void calculateDifficulty (int difficulty)
        {
            switch(difficulty) {

                case 1:
                    difficulty_One();
                    break;
                case 2:
                    difficulty_Two();
                    break;
                case 3:
                    difficulty_Three();
                    break;
         
            }
        }


        public void difficulty_One ()
        {

            switch (tier) {

                case 1:
                    partsScripts[0].state = PartState.NotWorking;
                    if (Random.Range(0,5) == 1)
                    {
                        partsScripts[1].state = PartState.NotWorking;
                    }
                    partsScripts[2].state = PartState.Working;
                    break;
                case 2:
                    partsScripts[0].state = PartState.NotWorking;
                    if (Random.Range(0, 5) == 1)
                    {
                        partsScripts[1].state = PartState.NotWorking;
                    }
                    if (Random.Range(0, 7) == 1)
                    {
                        partsScripts[2].state = PartState.NotWorking;
                    }
                    partsScripts[3].state = PartState.Working;
                    break;
                case 3:
                    partsScripts[0].state = PartState.NotWorking;
                    if (Random.Range(0, 5) == 1)
                    {
                        partsScripts[1].state = PartState.NotWorking;
                    }
                    if (Random.Range(0, 7) == 1)
                    {
                        partsScripts[2].state = PartState.NotWorking;
                    }
                    partsScripts[3].state = PartState.Working;
                    break;
                case 4:
                    partsScripts[0].state = PartState.NotWorking;
                    partsScripts[1].state = PartState.NotWorking;
                    if (Random.Range(0, 5) == 1)
                    {
                        partsScripts[2].state = PartState.NotWorking;
                    }
                    if (Random.Range(0, 7) == 1)
                    {
                        partsScripts[2].state = PartState.NotWorking;
                    }
                    partsScripts[4].state = PartState.Working;
                    break;

            }
          
            




        }

        public void difficulty_Two()
        {
            switch (tier) {

                case 1:
                    if (Random.value < 0.90f)
                    {
                        partsScripts[0].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[0].state = PartState.Working;
                    }
                    if (Random.value < 0.5f)
                    {
                        partsScripts[1].state = PartState.NotWorking;

                    }
                    else
                    {
                        partsScripts[1].state = PartState.Working;
                    }
                    partsScripts[2].state = PartState.Working;


                    break;
                case 2:
                   
                   partsScripts[0].state = PartState.NotWorking;
                    
                
                    if (Random.value < 0.7f)
                    {
                        partsScripts[1].state = PartState.NotWorking;

                    }
                    else
                    {
                        partsScripts[1].state = PartState.Working;
                    }
                    if (Random.value < 0.4f)
                    {
                        partsScripts[2].state = PartState.NotWorking;

                    }
                    else
                    {
                        partsScripts[2].state = PartState.Working;
                    }

                    partsScripts[3].state = PartState.Working;
                    break;
                case 3:
                    partsScripts[0].state = PartState.NotWorking;


                    if (Random.value < 0.7f)
                    {
                        partsScripts[1].state = PartState.NotWorking;

                    }
                    else
                    {
                        partsScripts[1].state = PartState.Working;
                    }
                    if (Random.value < 0.4f)
                    {
                        partsScripts[2].state = PartState.NotWorking;

                    }
                    else
                    {
                        partsScripts[2].state = PartState.Working;
                    }

                    partsScripts[3].state = PartState.Working;
                    break;
                case 4:
                    partsScripts[0].state = PartState.NotWorking;


               
                        partsScripts[1].state = PartState.NotWorking;

                 
                    if (Random.value < 0.6f)
                    {
                        partsScripts[2].state = PartState.NotWorking;

                    }
                    else
                    {
                        partsScripts[2].state = PartState.Working;
                    }

                    if (Random.value < 0.3f)
                    {
                        partsScripts[3].state = PartState.NotWorking;

                    }
                    else
                    {
                        partsScripts[3].state = PartState.Working;
                    }

                    partsScripts[4].state = PartState.Working;
                    break;






            }


        }

        public void difficulty_Three()
        {

            switch (tier) {

                case 1:
                    if (Random.value < 0.50f)
                    {
                        partsScripts[0].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[0].state = PartState.Working;
                    }
                    if (Random.value < 0.70f)
                    {
                        partsScripts[1].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[1].state = PartState.Working;
                    }

                    partsScripts[2].state = PartState.NotWorking;
                    break;
                case 2:
                    if (Random.value < 0.50f)
                    {
                        partsScripts[0].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[0].state = PartState.Working;
                    }

                    if (Random.value < 0.70f)
                    {
                        partsScripts[1].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[1].state = PartState.Working;
                    }

                    if (Random.value < 0.30f)
                    {
                        partsScripts[2].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[2].state = PartState.Working;
                    }

                    partsScripts[3].state = PartState.NotWorking;
                    break;
                case 3:
                    if (Random.value < 0.50f)
                    {
                        partsScripts[0].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[0].state = PartState.Working;
                    }

                    if (Random.value < 0.70f)
                    {
                        partsScripts[1].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[1].state = PartState.Working;
                    }

                    if (Random.value < 0.30f)
                    {
                        partsScripts[2].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[2].state = PartState.Working;
                    }

                    partsScripts[3].state = PartState.NotWorking;
                    break;
               
                case 4:
                    if (Random.value < 0.50f)
                    {
                        partsScripts[0].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[0].state = PartState.Working;
                    }

                    if (Random.value < 0.70f)
                    {
                        partsScripts[1].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[1].state = PartState.Working;
                    }

                    if (Random.value < 0.30f)
                    {
                        partsScripts[2].state = PartState.NotWorking;
                    }
                    else
                    {
                        partsScripts[2].state = PartState.Working;
                    }

                    partsScripts[3].state = PartState.NotWorking;
                    partsScripts[4].state = PartState.NotWorking;
                    break;










            }



        }

      
        public void getDifficulty ()
        {
            for (int i = 0; i < parts.Length; i++)
            {
                Debug.Log("difficilty: " + partsScripts[i].state);
            }



        }

      

    }

   

}