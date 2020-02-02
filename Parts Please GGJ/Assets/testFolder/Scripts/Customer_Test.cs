using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Customer_Test : MonoBehaviour
{
    // Start is called before the first frame update

    public Faction faction;
    public Hostility hostility;
    public RawImage image;
   // public Weapon weapon;



    void Start()
    {
        image = GetComponentInChildren<RawImage>();

        switch (Random.Range(0, 3))
        {

            case 0:
                faction = Faction.NEUTRAL;
                image.color = Color.gray;
                break;
            case 1:
                faction = Faction.BLUE;
                image.color = Color.blue;
                break;
            case 2:
                faction = Faction.RED;
                image.color = Color.red;
                break;
            default:
                faction = Faction.NEUTRAL;
                break;
        }

        switch (Random.Range(0, 3)) {

            case 0:
                hostility = Hostility.NEUTRAL;
                break;
            case 1:
                hostility = Hostility.ESCALATE;
                break;
            case 2:
                hostility = Hostility.DEESCELATE;
                break;
            default:
                hostility = Hostility.NEUTRAL;
                break;

        }


    }

    public enum Faction { NEUTRAL, RED, BLUE };
    public enum Hostility {NEUTRAL, ESCALATE, DEESCELATE };

    

    public Faction getFaction ()
    {


        return faction;

    }
    public Hostility getHostility ()
    {

        return hostility;
    }
}
