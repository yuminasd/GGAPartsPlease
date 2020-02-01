using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;

public class GoToShop : MonoBehaviour
{
    public void Shop()
    {
        SceneLoader.GoToScene(Custom_Scene.Shop);
    }
}
