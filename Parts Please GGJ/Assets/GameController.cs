using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update    
    enum Scene
    {
        MainMenu,
        MainGame,
        Shop,
        End_Win,
        End_Lose
    }

    Scene CurrentScene;
    public bool Paused = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        this.CurrentScene = Scene.MainMenu;
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
        if (this.CurrentScene == Scene.MainMenu)
        {
            if (!Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1))
                if (Input.anyKeyDown)
                {
                    this.CurrentScene = Scene.MainGame;
                    SceneLoader.GoToScene(SceneLoader.Scene.MainGame);
                }
        }
        else if (this.CurrentScene == Scene.MainGame)
        {
        }
    }

    public void TogglePaused()
    {       
        if(this.CurrentScene.Equals(Scene.MainMenu))
        {
            return;
        }

        this.Paused = !this.Paused;
        Debug.Log("PAUSED: " + this.Paused);
    }
}
