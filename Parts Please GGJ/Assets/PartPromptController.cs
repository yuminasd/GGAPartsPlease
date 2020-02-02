using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;

public class PartPromptController : MonoBehaviour
{
    public GameObject prompt;
    public GameObject lightIcon, brokenLightIcon, gearIcon, brokenGearIcon, scopeIcon, brokenScopeIcon;

    public void showPrompt(WeaponPart part)
    {
        prompt.SetActive(true);
        lightIcon.SetActive(false);
        brokenLightIcon.SetActive(false);
        gearIcon.SetActive(false);
        brokenGearIcon.SetActive(false);
        scopeIcon.SetActive(false);
        brokenScopeIcon.SetActive(false);
        switch (part.partType)
        {
            case PartType.Bulb:
                lightIcon.SetActive(!part.isBroken);
                brokenLightIcon.SetActive(part.isBroken);
                break;
            case PartType.Gear:
                gearIcon.SetActive(!part.isBroken);
                brokenGearIcon.SetActive(part.isBroken);
                break;
            case PartType.Scope:
                scopeIcon.SetActive(!part.isBroken);
                brokenScopeIcon.SetActive(part.isBroken);
                break;
        }
    }
}
