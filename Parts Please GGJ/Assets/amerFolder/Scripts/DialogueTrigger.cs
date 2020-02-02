using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Customer customer;

    public void TriggerDialogue ()
    {



        dialogue.politicalDialogue(customer.faction, customer.hostility);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    


    }
}
