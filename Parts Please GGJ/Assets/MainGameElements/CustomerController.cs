using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;

public class CustomerController : MonoBehaviour
{
    public Animator anim_character;
    public Animator anim_weapon;
    public GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.HandleAnimationTriggers();
        this.HandleCustomerState();
        // After talking, dialogue should set CustomerState = CustomerState.WaitingForRepair
        // FORCED: Item is on the bench, they wait for the repair
        if(gameState.currentCustomer.customerState == CustomerState.Talking && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("STATE: Talking -> Waiting For Repair");
            anim_weapon.SetTrigger("DropWeapon");
            gameState.currentCustomer.setItemLocation(ItemLocation.Bench);
            gameState.currentCustomer.setCustomerState(CustomerState.WaitingForRepair);            
        }
        // FORCED: User returns gun to customer, they start farewell message
        else if (gameState.currentCustomer.customerState == CustomerState.WaitingForRepair && gameState.currentCustomer.itemLocation == ItemLocation.Bench)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("STATE: waiting for repair -> Farewell, pick up item");
                anim_weapon.SetTrigger("PickupWeapon");
                gameState.currentCustomer.setCustomerState(CustomerState.Farewell);
                gameState.currentCustomer.setItemLocation(ItemLocation.Customer);
            }
        }
        // FORCED: Farewell message done, cusomter has item, trigger exit
        else if (gameState.currentCustomer.customerState == CustomerState.Farewell)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("STATE: Farewell => Exit");
                anim_character.SetTrigger("ExitShop");
                gameState.currentCustomer.setCustomerState(CustomerState.Exiting);
            }
        }
    }

    private void HandleAnimationTriggers()
    {
        //if (gameState.currentCustomer.customerState == CustomerState.Entering)
        //{
        //    anim.SetTrigger("EnterShop");
        //}
        //if (gameState.currentCustomer.customerState == CustomerState.Talking)
        //{
        //    anim.SetTrigger("Talking");
        //}
    }

    private void HandleCustomerState()
    {

    }

    public void SetCustomerDialogue()
    {
        anim_character.SetTrigger("Talking");
        gameState.currentCustomer.setCustomerState(CustomerState.Talking);
    }

    public void SetCustomerItemLocation(ItemLocation location)
    {
        gameState.currentCustomer.setItemLocation(location);
    }
    
}
