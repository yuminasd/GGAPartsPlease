using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;
public class SendInCustomer : MonoBehaviour
{
    public GameState gameState;
    public void SendCustomer()
    {
        gameState.currentCustomer.setCustomerState(CustomerState.Entering);
    }
}
