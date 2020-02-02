using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPartSlow : MonoBehaviour
{
    public WeaponPart part;
    public string ExpectedSerialNumber;

    public void setPart(WeaponPart part)
    {
        this.part = part;
    }

    public bool isValid()
    {
        if (this.part == null) return false;
        return this.ExpectedSerialNumber.Equals(this.part.GetSerialNumber());
    }
}
