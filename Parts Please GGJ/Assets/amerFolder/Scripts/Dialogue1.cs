using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;
[System.Serializable]
public class Dialogue
{



    public string name;
    public string itemName;
    public string[] sentences;
    string[] greetings = new string[3];
    string[] requests = new string[3];
    public string[] politicalDialgue = new string[3];


    public void setWeaponName (string weaponName)
    {
        Debug.Log("calling weapon name" + weaponName);

        itemName = weaponName;
    }



    void formBasicSentence()
    {

        name = "goerge";
        greetings[0] = "Hello there";
        greetings[1] = "Greetings";
        greetings[2] = "Hi";
        requests[0] = "I need you to fix my  " + itemName;
        requests[1] = "Please fix my " + itemName + "It is very urgent";
        requests[2] = "It is of ut most importance that you to fix my" + itemName;
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
                politicalDialgue[0] = "nice day outisde, hopfully the blufor keep it that way";
                politicalDialgue[1] = "things seem a little shakey with the Blufor but today is fine";
                politicalDialgue[2] = "Boy am i glade things arent as tense as they were";



            }
            else if (faction.Equals(Faction.Blufor))
            {
                politicalDialgue[0] = "finally some good weather, lets hope the Opfor doesnt wreck it";
                politicalDialgue[1] = "political di";
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

            politicalDialgue[0] = "How do you do?";
            politicalDialgue[1] = "just the person im looking for";
            politicalDialgue[2] = "today is your lucky day";


        }











    }




}