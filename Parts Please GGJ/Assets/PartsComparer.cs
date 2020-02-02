using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;

public class PartsComparer : MonoBehaviour
{
    public CatalogNumbers catalog;
    public GameState gameState;
    public GameObject InitialPart;
    public WeaponPartSlot[] PartSlots = new WeaponPartSlot[4];

    private void OnEnable()
    {
        for(int x = 0; x < 4; x++)
        {
            WeaponPartSlot cur = this.PartSlots[x];
            // Creating a new blank weapon part
            GameObject init = Instantiate(InitialPart);
            init.AddComponent<WeaponPart>();

            // Getting the desired partType
            PartType desiredType = gameState.currentCustomer.DesiredParts[x];
            init.GetComponent<WeaponPart>().partType = desiredType;
            init.GetComponent<WeaponPart>().isBroken = gameState.GetComponentInParent<GameController>().DetermineIfPartIsBroken();

            cur.part = init.GetComponent<WeaponPart>();
        }
    }

    public bool assertPartsAreFixed()
    {
        bool valid = true;
        for (int x = 0; x < 4; x++)
        {
            WeaponPartSlot currentPartSlot = PartSlots[x];
            WeaponPart currentPart = currentPartSlot.part;
            if (currentPart == null) valid = false;
            else if (currentPart.partType != gameState.currentCustomer.DesiredParts[x])
            {
                valid = false;
            }
            else if (!currentPart.GetSerialNumber().Equals(catalog.getSerialNumber(gameState.currentCustomer.gunType, gameState.currentCustomer.DesiredParts[x])))
            {
                valid = false;
            }
        }
        return valid;
    }
}
