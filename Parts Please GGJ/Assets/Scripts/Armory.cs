using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartsPlease
{
    public class Armory
    {
        private static Armory INSTANCE;
        public List<Item> itemModels = new List<Item>();

        private Armory()
        {
            //add items to armory here (these are what are used to display in schematics, and to check if repair was correct)

        }

        public static Armory get()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new Armory();
            }
            return INSTANCE;
        }
    }

}