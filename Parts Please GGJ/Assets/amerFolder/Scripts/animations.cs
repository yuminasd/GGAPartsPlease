using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDialogueBox ()
    {
        animator.SetBool("isOpen", true);




    }
}
