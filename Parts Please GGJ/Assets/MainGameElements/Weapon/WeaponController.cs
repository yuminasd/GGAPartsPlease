using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PartsPlease;

public class WeaponController : MonoBehaviour
{
    public GameController gc;
    public GunType gunType;
    public Dictionary<int, WeaponPart> expectedParts = new Dictionary<int, WeaponPart>();
    public Dictionary<int, WeaponPart> currentParts = new Dictionary<int, WeaponPart>();
    public CatalogNumbers catalog;
    //public Dictionary<int, Transform[]> partMap = new Dictionary<int, Transform[]>();
    public Dictionary<int, Dictionary<int, Transform>> partMap = new Dictionary<int, Dictionary<int, Transform>>();
    public Transform[] YodaParts = new Transform[4];
    public Transform[] WaterParts = new Transform[4];
    public Transform[] BabyParts = new Transform[4];
    public Transform[] GunParts = new Transform[4];
    public List<string> ErrorMessage = new List<string>();

    public GameObject[] theGuns;

    // Sprite Pools
    public GameObject[] BulbSpritePool = new GameObject[4];
    public GameObject[] GearSpritePool = new GameObject[4];
    public GameObject[] ScopeSpritePool = new GameObject[4];

    // Active Part for Replacement
    public WeaponPart activePart;


    // Start is called before the first frame update
    void Start()
    {
        this.expectedParts.Add(0, new WeaponPart());
        this.expectedParts.Add(1, new WeaponPart());
        this.expectedParts.Add(2, new WeaponPart());
        this.expectedParts.Add(3, new WeaponPart());
        this.currentParts.Add(0, new WeaponPart());
        this.currentParts.Add(1, new WeaponPart());
        this.currentParts.Add(2, new WeaponPart());
        this.currentParts.Add(3, new WeaponPart());
        this.populatePartMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void populatePartMap()
    {

        Dictionary<int, Transform> yoda = new Dictionary<int, Transform>();
        Dictionary<int, Transform> water = new Dictionary<int, Transform>();
        Dictionary<int, Transform> bb = new Dictionary<int, Transform>();
        Dictionary<int, Transform> gun = new Dictionary<int, Transform>();
        for(int x = 0; x < 4; x++)
        {
            yoda.Add(x, YodaParts[x]);
            water.Add(x, WaterParts[x]);
            bb.Add(x, BabyParts[x]);
            gun.Add(x, GunParts[x]);
        }
        partMap.Add(0, yoda);
        partMap.Add(1, water);
        partMap.Add(2, bb);
        partMap.Add(3, gun);


    }

    //public void populatePartMap()
    //{
    //    this.partMap.Add(0, this.YodaParts);
    //    this.partMap.Add(1, this.WaterParts);
    //    this.partMap.Add(2, this.BabyParts);
    //    this.partMap.Add(3, this.GunParts);

    //}

    public void resetGunParts()
    {
        for (int x = 0; x < 4; x++)
        {
            BulbSpritePool[x].SetActive(false);
            GearSpritePool[x].SetActive(false);
            ScopeSpritePool[x].SetActive(false);
            BulbSpritePool[x].GetComponent<PartFollow>().setParentPosition(null);
            GearSpritePool[x].GetComponent<PartFollow>().setParentPosition(null);
            ScopeSpritePool[x].GetComponent<PartFollow>().setParentPosition(null);
        }
    }

    public void getNewGun()
    {
        this.resetGunParts();
        this.gunType = catalog.chooseRandomGunType();
        this.ErrorMessage = new List<string>();

        // Enable the proper gun item
        int gunToEnable = getPartLocationModifier();
        foreach (GameObject gun in this.theGuns)
        {
            gun.SetActive(false);
        }
        this.theGuns[gunToEnable].SetActive(true);


        // set each item slot on the gun to a weapon part
        for (int y = 0; y < 4; y++)
        {

            WeaponPart newPart = new WeaponPart();
            int partNum = Random.Range(0, 3);
            newPart.partLocationModifier = getPartLocationModifier();
            if (partNum == 0)
            {
                newPart.serialNumber = catalog.getBulbForModel(this.gunType);
                newPart.partType = PartType.Bulb;
                newPart.isBroken = gc.DetermineIfPartIsBroken();
                newPart.index = y;

                // Set the sprite to active
                BulbSpritePool[y].SetActive(true);
                // Gets an int 0-3 based on the gunType
                int locIndex = getPartLocationModifier();
                Transform t = partMap[locIndex][y];

                // Set the sprite to follow the transform for this part slot (y)
                BulbSpritePool[y].GetComponent<PartFollow>().setParentPosition(t);
            }
            else if (partNum == 1)
            {
                newPart.serialNumber = catalog.getGearForModel(this.gunType);
                newPart.partType = PartType.Gear;
                newPart.isBroken = gc.DetermineIfPartIsBroken();
                newPart.index = y;

                // Set the sprite to active
                GearSpritePool[y].SetActive(true);
                // Gets an int 0-3 based on the gunType
                int locIndex = getPartLocationModifier();

                // Get the transform[] for the correct gun type
                Transform t = partMap[locIndex][y];
                // Set the sprite to follow the transform for this part slot (y)
                GearSpritePool[y].GetComponent<PartFollow>().setParentPosition(t);
            }
            else if (partNum == 2)
            {
                newPart.serialNumber = catalog.getScopeForModel(this.gunType);
                newPart.partType = PartType.Scope;
                newPart.isBroken = gc.DetermineIfPartIsBroken();
                newPart.index = y;

                // Set the sprite to active
                ScopeSpritePool[y].SetActive(true);
                // Gets an int 0-3 based on the gunType
                int locIndex = getPartLocationModifier();

                // Get the transform[] for the correct gun type
                Transform t = partMap[locIndex][y];
                // Set the sprite to follow the transform for this part slot (y)
                ScopeSpritePool[y].GetComponent<PartFollow>().setParentPosition(t);
            }

            expectedParts[y] = new WeaponPart(newPart);
            currentParts[y] = newPart;
        }

    }

    private int getPartLocationModifier()
    {
        if (this.gunType == GunType.YODAGUN)
        {
            return 0;
        }
        if (this.gunType == GunType.WATERGUN)
        {
            return 1;
        }
        if (this.gunType == GunType.BABYGUN)
        {
            return 2;
        }
        return 3;
    }

    public bool gunIsFixed()
    {
        bool isFixed = true;
        for (int x = 0; x < 4; x++)
        {
            WeaponPart expected = this.expectedParts[x];
            WeaponPart current = this.currentParts[x];
            if (!expected.Equals(current)) isFixed = false;

        }
        return isFixed;
    }
    public void addError(int index, string serialnum)
    {
        this.ErrorMessage.Add(
            string.Format("Item in slot {0} had serial: {1}. Expected: {2}", index, serialnum, this.expectedParts[index].serialNumber));
    }

    public void replaceWeaponPart(WeaponPart newPart)
    {
        this.currentParts[newPart.index] = newPart;
    }

    public void clearActivePart()
    {
        this.activePart = null;
    }
}
