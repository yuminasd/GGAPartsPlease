using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PartsPlease;

public class GameController : MonoBehaviour
{

    Custom_Scene CurrentScene;
    GameState gameState;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        this.CurrentScene = Custom_Scene.MainMenu;
        this.gameState = new GameState();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.ManageSceneControl();
  
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
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Open Pause Menu");
                throw new MissingComponentException("Pause Menu Not Implemented Yet");
            }
        }
    }
}
