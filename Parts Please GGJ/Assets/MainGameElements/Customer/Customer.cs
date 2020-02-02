﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartsPlease
{
    public enum Hostility
    {
        Neutral,
        Deescalate,
        Escalate
    }

    public enum ItemLocation
    {
        Bench,
        Customer
    }

    public enum CustomerState
    {
        Entering,
        Exiting, 
        Exited,
        Farewell,
        Talking,
        WaitingForRepair
    }

    public class Customer : MonoBehaviour
    {

        Faction faction { get; set; }
        Hostility hostility { get; set; }


        public bool FirstCustomer;
        public bool LastCustomer;
        public CustomerState customerState;
        public ItemLocation itemLocation;

        public void Awake()
        {
            this.FirstCustomer = true;
            this.LastCustomer = false;
        }

        public void Reset()
        {
            this.LastCustomer = false;
            this.customerState = CustomerState.Exited;
            this.itemLocation = ItemLocation.Customer;
            // this.faction = GenerateFaction();
            // this.hostility = GenerateHostility();
        }
        
        public void setFirstCustomer(bool state)
        {
            this.FirstCustomer = state;
        }

        public void setLastCustomer(bool state)
        {
            this.LastCustomer = state;
        }

        public void setCustomerState(CustomerState state)
        {
            this.customerState = state;
        }       

        public void setItemLocation(ItemLocation location)
        {
            this.itemLocation = location;
        }
    }
}