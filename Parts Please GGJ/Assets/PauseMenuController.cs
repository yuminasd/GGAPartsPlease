using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    GameController GameController;
    public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        this.GameController = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Paused)
        {
            //Menu.SetActive(true);
            if(this.Menu.activeInHierarchy == false)
            {
                Menu.SetActive(true);
            }
        }
        else if (!GameController.Paused)
        {
            Menu.SetActive(false);
        }

    }

    public void TriggerUnpause()
    {
        if (GameController.Paused)
        {
            GameController.TogglePaused();
        }
      
    }
}
