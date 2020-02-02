using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartInteraction : MonoBehaviour
{
    // Weapon Replacement stuff
    public PartPromptController partPromptController;
    public WeaponController weaponController;
    public int slot;

    public void clickpart()
    {
        Debug.Log("Clicked: " + slot);
        WeaponPart part = this.weaponController.currentParts[this.slot];
        weaponController.activePart = part;
        this.partPromptController.showPrompt(part);
    }

    
}
