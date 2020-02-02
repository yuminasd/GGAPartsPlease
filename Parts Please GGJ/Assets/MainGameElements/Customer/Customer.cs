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
        public PartType[] DesiredParts = new PartType[4];

        public void Awake()
        {
            this.FirstCustomer = true;
            this.LastCustomer = false;
        }

        public void GetNewCustomer()
        {
            this.LastCustomer = false;
            this.customerState = CustomerState.Exited;
            this.itemLocation = ItemLocation.Customer;
            this.faction = GenerateFaction();
            this.hostility = GenerateHostility();
            this.gunType = catalog.chooseRandomGunType();
            this.populateWeaponPartsArray();
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

        public void populateWeaponPartsArray()
        {
            for(int x = 0; x < 4; x++)
            {
                PartType curPart = this.getRandomPart();
                this.DesiredParts[x] = curPart;
            }
        }

        private PartType getRandomPart()
        {
            int type = Random.Range(0, 4);
            if (type == 0) return PartType.Bulb;
            if (type == 1) return PartType.Gear;
            return PartType.Scope;
            
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