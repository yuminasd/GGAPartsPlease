using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PartsPlease
{
    public enum Custom_Scene
    {
        MainMenu,
        MainGame,
        Shop,
        End_Win,
        End_Lose
    }

    public static class SceneLoader
    {
       

        public static void GoToScene(Custom_Scene newScene)
        {
            SceneManager.LoadScene(newScene.ToString());
        }
    }
}
