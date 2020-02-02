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
    public TextMeshProUGUI continueText;
    private int clickCount;
    public Animator anim;
    public Button continueButton;

    public int i;

    void Start()
    {
        
        QueSentences.Capacity = 3;
   
    }

   

    public void StartDialogue(Dialogue dialogue)
    {

     
        continueButton.gameObject.SetActive(true);
        nameText.text =  dialogue.name;
        clickCount = 0;
        dialogueText.text = "";
        i = 0;
        continueText.text = "continue";
        QueSentences.Clear();
        

        foreach (string sentence in dialogue.randomizeSentence())
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
            EndDialogue();
        
    }


   public void EndDialogue()
    { 
        if (clickCount == 4)
        { 
            
            Debug.Log("End of Converstaion");
            anim.SetBool("isOpen", false);
            continueButton.gameObject.SetActive(false);
        }
    

    }

  
}
        