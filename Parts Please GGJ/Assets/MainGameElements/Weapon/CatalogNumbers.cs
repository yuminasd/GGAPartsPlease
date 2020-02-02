using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartsPlease
{
    public enum GunType
    {
        YODAGUN,
        WATERGUN,
        BABYGUN,
        GUNGUN
    }

    public class CatalogNumbers : MonoBehaviour
    {

        private Dictionary<GunType, string> Guns { get; set; } = new Dictionary<GunType, string>();

        private Dictionary<string, string> Bulbs { get; set; } = new Dictionary<string, string>();

        private Dictionary<string, string> Gears { get; set; } = new Dictionary<string, string>();

        private Dictionary<string, string> Scopes { get; set; } = new Dictionary<string, string>();

        public void Start()
        {
            this.populateGuns();
            this.populateBulbs();
            this.populateGears();
            this.populateScopes();
        }

        private void populateGuns()
        {
            Guns.Add(GunType.YODAGUN, "698YD");
            Guns.Add(GunType.WATERGUN, "W7765");
            Guns.Add(GunType.BABYGUN, "B56C7");
            Guns.Add(GunType.GUNGUN, "GG4BB");
        }

        private void populateBulbs()
        {
            Bulbs.Add("698YD", "1425A");
            Bulbs.Add("W7765", "1256B");
            Bulbs.Add("B56C7", "A8912");
            Bulbs.Add("GG4BB", "B5762");
        }
        private void populateGears()
        {
            Gears.Add("698YD", "76G12");
            Gears.Add("W7765", "86G43");
            Gears.Add("B56C7", "72G12");
            Gears.Add("GG4BB", "90G18");
        }
        private void populateScopes()
        {
            Scopes.Add("698YD", "S756");
            Scopes.Add("W7765", "S1247");
            Scopes.Add("B56C7", "S6920");
            Scopes.Add("GG4BB", "SAD4U");
        }

        public string getGunModel(GunType gunType)
        {
            return this.Guns[gunType];
        }

        public string getBulbForModel(GunType gunType)
        {
            string modelNum = this.getGunModel(gunType);
            return this.Bulbs[modelNum];
        }

        public string getGearForModel(GunType gunType)
        {
            string modelNum = this.getGunModel(gunType);
            return this.Gears[modelNum];
        }
        public string getScopeForModel(GunType gunType)
        {
            string modelNum = this.getGunModel(gunType);
            return this.Scopes[modelNum];
        }

        public string getBulbModel(string gunType)
        {
            return this.Bulbs[gunType];
        }

        public bool checkBulb(string model, string serial)
        {
            return this.Bulbs[model].Equals(serial);
        }

        public bool checkGear(string model, string serial)
        {
            return this.Gears[model].Equals(serial);
        }

        public bool checkScope(string model, string serial)
        {
            return this.Scopes[model].Equals(serial);
        }

    }
}