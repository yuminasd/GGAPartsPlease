using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        MainMenu,
        MainGame,
        Shop,
        End_Win,
        End_Lose
    }

    public static void GoToScene(Scene newScene)
    {
        SceneManager.LoadScene(newScene.ToString());
    }
}
