using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PartsPlease;

public class GameController : MonoBehaviour
{

    public bool Paused = false;
    public int WarMeter;
    public int MaxWarMeter = 10;
    public int turnNumber;
    public int Difficulty;
    public int money;
    public GameObject shop;
    public MoneyController mc;

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
        this.WarMeter = 0;
        this.turnNumber = 0;
        this.Difficulty = 0;
   
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameState.WarMeterAdjusted)
        {
            this.AdjustWarMeter();
        }

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
            if (!mc.openShop)
            {
                if (gameState.currentCustomer.LastCustomer && gameState.currentCustomer.customerState == CustomerState.Exiting)
                {
                    // Disable buttons.
                    gameState.disableButtons();


                }
                else if (gameState.currentCustomer.LastCustomer && gameState.currentCustomer.customerState == CustomerState.Exited)
                {


                    Debug.Log("can shop: " + mc.openShop);

                    if (this.WarMeter >= 10)
                    {
                        SceneLoader.GoToScene(Custom_Scene.End_Lose);
                    }
                    else if (!mc.openShop)
                    {

                        shop.gameObject.SetActive(true);
                        mc.openShop = true;
                    }
                }
            }
          
           
        }
    }

    private void AdjustWarMeter()
    {
        if (gameState.currentCustomer.hostility == Hostility.Escalate)
        {
            this.WarMeter++;
        }
        else if (gameState.currentCustomer.hostility == Hostility.Deescalate)
        {
            this.WarMeter--;
        }
        if (this.WarMeter < 0)
        {
            this.WarMeter = 0;
        }
        gameState.ToggleWarMeter(true);
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

    public void IncrementTurn()
    {
        this.turnNumber++;
        if(this.turnNumber % 2 == 0 && this.Difficulty < 4)
        {
            this.Difficulty++;
        }
    }
}
