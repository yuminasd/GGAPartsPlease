using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        private const int OPFOR = 30;
        private const int BLUFOR = 60;
        private const int ESCAL = 30;
        private const int DESCAL = 60;

        public Faction faction { get; set; }
        public Hostility hostility { get; set; }


        public bool FirstCustomer;
        public bool LastCustomer;
        public CustomerState customerState;
        public ItemLocation itemLocation;
        public GunType gunType;
        public CatalogNumbers catalog;
        public Image clothing; 

        public void Awake()
        {
            this.FirstCustomer = true;
            this.LastCustomer = false;
        }

        public void GetNewCustomer()
        {
            Debug.Log("creating new customer");
            this.LastCustomer = false;
            this.customerState = CustomerState.Exited;
            this.itemLocation = ItemLocation.Customer;
            this.faction = GenerateFaction();
            this.hostility = GenerateHostility();
            this.setClothingColor(this.faction);
            this.gunType = catalog.chooseRandomGunType();
         
        }

        private Faction GenerateFaction()
        {
            int faction = Random.Range(0, 90);
            if(faction >= 0 && faction <= OPFOR)
            {
                return Faction.Opfor;
            }
            if (faction > OPFOR && faction <= BLUFOR)
            {
                return Faction.Blufor;
            }
            return Faction.Neutral;
        }

        private Hostility GenerateHostility()
        {
            int hostility = Random.Range(0, 90);
            if (hostility >= 0 && hostility <= ESCAL)
            {
                return Hostility.Escalate;
            }
            if (hostility > ESCAL && hostility <= DESCAL)
            {
                return Hostility.Deescalate;
            }
            return Hostility.Neutral;
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


        public void setClothingColor (Faction faction) {
            Debug.Log("changing color of clothing to color of faction: " + faction);
            if (this.faction == Faction.Blufor)
            {
                clothing.color = Color.blue;
            }
            else if (this.faction == Faction.Opfor)
            {
                clothing.color = Color.red;
            }
            else clothing.color = Color.white;
                
        }
    }
}