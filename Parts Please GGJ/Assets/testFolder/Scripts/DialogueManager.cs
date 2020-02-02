using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public List<string> QueSentences;
    public Animator animator;
    public TextMeshProUGUI continueText;
    private int clickCount;


    public int i;

    void Start()
    {
        
        QueSentences.Capacity = 3;
        i = 0;
        clickCount = 0;
    }

   

    public void StartDialogue(Dialogue dialogue)
    {

        nameText.text =  dialogue.name;


        foreach(string sentence in dialogue.randomizeSentence())
        {
            Debug.Log(dialogue.randomizeSentence());
            QueSentences.Add(sentence);

        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
  

        if (QueSentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        dialogueText.text = QueSentences[i];
        

        if (i + 1 != QueSentences.Count)
        {
            i++;
        }
        else
        {

            continueText.text = "finish";
     
        }
        clickCount++;

    }


   public void EndDialogue()
    { 
        if (clickCount == 4)
        {
            Debug.Log("End of Converstaion");
            animator.SetBool("isOpen", false);
        }
    

    }

  
}
        