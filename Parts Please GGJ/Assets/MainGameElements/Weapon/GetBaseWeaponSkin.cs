using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PartsPlease;

public class GetBaseWeaponSkin : MonoBehaviour
{
    public GameObject[] WeaponBaseSkins = new GameObject[4];
    public CatalogNumbers catalog;

    
    public void SetWeaponSkin(GunType type)
    {        
        foreach(GameObject cur in WeaponBaseSkins)
        {
            cur.SetActive(false);
        }
        int index = catalog.getWeaponIndex(type);
        Debug.Log("WEAPON: " + index);
        WeaponBaseSkins[index].SetActive(true);
    }
}
