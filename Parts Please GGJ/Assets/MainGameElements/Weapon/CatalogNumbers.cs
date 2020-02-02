using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        private Dictionary<string, int> WeaponSkinIndex = new Dictionary<string, int>();

        public void Start()
        {
            this.populateGuns();
            this.populateBulbs();
            this.populateGears();
            this.populateScopes();
            this.populateWeaponIndices();
        }

        private void populateGuns()
        {
            Guns.Add(GunType.YODAGUN, "698YD");
            Guns.Add(GunType.WATERGUN, "W7765");
            Guns.Add(GunType.BABYGUN, "B56C7");
            Guns.Add(GunType.GUNGUN, "GG4BB");
        }

        public string getSerialNumber(GunType gunType, PartType partType)
        {
            switch (partType)
            {
                case PartType.Bulb:
                    return getBulbForModel(gunType);
                case PartType.Gear:
                    return getGearForModel(gunType);
                case PartType.Scope:
                    return getScopeForModel(gunType);
                default:
                    return null;
            }
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

        private void populateWeaponIndices()
        {
            WeaponSkinIndex.Add("698YD", 0);
            WeaponSkinIndex.Add("W7765", 1);
            WeaponSkinIndex.Add("B56C7", 2);
            WeaponSkinIndex.Add("GG4BB", 3);
        }

        public GunType chooseRandomGunType()
        {
            int type = Random.Range(0, 4);
            if (type == 0) return GunType.YODAGUN;
            if (type == 1) return GunType.WATERGUN;
            if (type == 2) return GunType.BABYGUN;
            return GunType.GUNGUN;
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

        public int getWeaponIndex(GunType gunType)
        {
            string modelNum = this.getGunModel(gunType);

            return WeaponSkinIndex[modelNum];
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