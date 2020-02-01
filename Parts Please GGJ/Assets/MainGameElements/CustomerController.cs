using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;

public class CustomerController : MonoBehaviour
{
    public Animator anim;
    public GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.currentCustomer.customerState == CustomerState.Entering)
        {
            anim.SetTrigger("EnterShop");
        }
        if (gameState.currentCustomer.customerState == CustomerState.WaitingForRepair && gameState.currentCustomer.itemLocation == ItemLocation.Customer)
        {
            anim.SetTrigger("ExitShop");
        }
    }

    public void SetCustomerDialogue()
    {
        gameState.currentCustomer.setCustomerState(CustomerState.Talking);

    }

    public void SetCustomerItemLocation(ItemLocation location)
    {
        gameState.currentCustomer.setItemLocation(location);
    }

    
}
