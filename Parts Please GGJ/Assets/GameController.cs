using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PartsPlease;

public class GameController : MonoBehaviour
{

    public bool Paused = false;
    GameState gameState;
    Custom_Scene CurrentScene;

    private void Awake()
    {        
        DontDestroyOnLoad(this.gameObject);
        this.CurrentScene = Custom_Scene.MainGame;
        this.gameState = this.GetComponent<GameState>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.ManageSceneControl();
        if (Input.GetKeyDown(KeyCode.Escape) && !this.Paused)
        {
            this.TogglePaused();
        }        

    }

    public void QuitGame()
    {
        Debug.Log("I QUIT THE GAME");
        Application.Quit();
    }

    private void ManageSceneControl()
    {
        if (this.CurrentScene == Custom_Scene.MainMenu)
        {
            if (!Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1))
                if (Input.anyKeyDown)
                {
                    this.CurrentScene = Custom_Scene.MainGame;
                    SceneLoader.GoToScene(Custom_Scene.MainGame);
                }
        }
        else if (this.CurrentScene == Custom_Scene.MainGame)
        {
            if(gameState.currentCustomer.LastCustomer && gameState.currentCustomer.customerState == CustomerState.Exiting)
            {
                // Disable buttons.
                gameState.disableButtons();
                
            } else if (gameState.currentCustomer.LastCustomer && gameState.currentCustomer.customerState == CustomerState.Exited)
            {
                SceneLoader.GoToScene(Custom_Scene.Shop);
            }
        }
    }

    public void TogglePaused()
    {       
        if(this.CurrentScene.Equals(Custom_Scene.MainMenu))
        {
            return;
        }

        this.Paused = !this.Paused;
        Debug.Log("PAUSED: " + this.Paused);
    }
}
