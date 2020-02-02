using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;

public class WeaponPart
{
    public bool isBroken;
    public string serialNumber;
    public PartType partType;
    public int index;
    public int partLocationModifier;


    public WeaponPart()
    {
        this.isBroken = false;
        this.serialNumber = "";
        this.partType = PartType.Bulb;
        this.partLocationModifier = 1;
        this.index = 0;
    }
    public WeaponPart (WeaponPart newPart)
    {
        this.isBroken = false;
        this.serialNumber = newPart.serialNumber;
        this.partType = newPart.partType;
        this.partLocationModifier = newPart.partLocationModifier;
        this.index = newPart.index;
    }

    public void setCurrentPart(WeaponPart newPart)
    {
        this.isBroken = newPart.isBroken;
        this.serialNumber = newPart.serialNumber;
        this.partType = newPart.partType;
        this.partLocationModifier = newPart.partLocationModifier;
        this.index = newPart.index;
    }

    public string GetSerialNumber()
    {
        return this.serialNumber;
    }

    public void setPartTypeAndSerial(PartType type, string serial)
    {
        this.partType = type;
        this.serialNumber = serial;
    }

    public bool Equals(WeaponPart other)
    {
        if (this.isBroken != other.isBroken) return false;
        if (!this.serialNumber.Equals(other.serialNumber)) return false;
        if (this.index != other.index) return false;
        return true;
    }
}