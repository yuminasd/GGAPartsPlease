using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;
[System.Serializable]
public class Dialogue
{



    public string name;
    public string itemName = "gunPlaceHolder";
    public string[] sentences;
    string[] greetings = new string[3];
    string[] requests = new string[3];
    public string[] politicalDialgue = new string[3];






    void formBasicSentence()
    {

        name = "goerge";
        itemName = "gunPlaceHolder";
        greetings[0] = "Hello there";
        greetings[1] = "Greetings";
        greetings[2] = "Listen up";
        requests[0] = "I need you to fix my  " + itemName;
        requests[1] = "Please fix my " + itemName + "It is very urgent";
        requests[2] = "It is of ut most importance for you to fix my" + itemName;
        sentences = new string[3];


    }


    public string[] randomizeSentence()
    {
        formBasicSentence();


        int pickGreet = Random.Range(0, greetings.Length);
        int pickRequest = Random.Range(0, requests.Length);
        int pickPolitical = Random.Range(0, politicalDialgue.Length);
        sentences[0] = greetings[pickGreet];

        sentences[1] = politicalDialgue[pickPolitical];
        sentences[2] = requests[pickRequest];

        return sentences;


    }

    public void politicalDialogue(Faction faction,Hostility hostilitiy)
    {

        if (hostilitiy.Equals(Hostility.Deescalate))
        {

            if (faction.Equals(Faction.Opfor))
            {
                politicalDialgue[0] = "political dialogue 1 red, de";
                politicalDialgue[1] = "political dialogue 2 red, de";
                politicalDialgue[2] = "political dialogue 3 red, de";



            }
            else if (faction.Equals(Faction.Blufor))
            {
                politicalDialgue[0] = "political dialogue 1 blue, de";
                politicalDialgue[1] = "political dialogue 2 blue, de";
                politicalDialgue[2] = "political dialogue 3 blue, de";
            }


        }
        if (hostilitiy.Equals(Hostility.Escalate))
        {

            if (faction.Equals(Faction.Opfor))
            {

                politicalDialgue[0] = "political dialogue 1 red, esc";
                politicalDialgue[1] = "political dialogue 2 red, esc";
                politicalDialgue[2] = "political dialogue 3 red, esc";


            }
            else if (faction.Equals(Faction.Blufor))
            {
                politicalDialgue[0] = "political dialogue 1 blue, esc";
                politicalDialgue[1] = "political dialogue 2 blue, esc";
                politicalDialgue[2] = "political dialogue 3 blue, esc";
            }


        }

        if (hostilitiy.Equals(Hostility.Neutral))
        {

            politicalDialgue[0] = "neutral 1";
            politicalDialgue[1] = "neutral 2";
            politicalDialgue[2] = "neutral 3";


        }











    }




}