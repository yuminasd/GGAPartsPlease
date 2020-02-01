using System.Collections;
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

    public class Customer : MonoBehaviour
    {

        Faction faction { get; set; }
        Hostility hostility { get; set; }

        public bool LastCustomer { get; set; }
        public bool HasExited { get; set; }

        public void Awake()
        {
            this.LastCustomer = false;
        }

        public void setLastCustomer(bool state)
        {
            this.LastCustomer = state;
        }

        public void setHasExited(bool state)
        {
            this.HasExited = state;
        }
    }
}