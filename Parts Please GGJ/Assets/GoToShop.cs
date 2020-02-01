using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToShop : MonoBehaviour
{
    public GameController gc;
    public void Shop()
    {
        gc.GoToShopScene();
    }
}
