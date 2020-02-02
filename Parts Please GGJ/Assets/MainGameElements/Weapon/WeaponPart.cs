using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;

public class WeaponPart : MonoBehaviour
{
    public bool isBroken;
    private string serialNumber;
    public PartType partType;
    public int index;
    public GameObject[] PrefabParts = new GameObject[3];


    private void OnEnable()
    {
        int spriteIndex = (int)this.partType;
        GameObject partSprite = Instantiate(PrefabParts[index]);
        partSprite.transform.SetParent(this.gameObject.transform);
    }

    public string GetSerialNumber()
    {
        return this.serialNumber;
    }
}