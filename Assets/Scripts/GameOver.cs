using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartButton (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuButton (){
        SceneManager.LoadScene("mainMenu");
    }

    public void ExitButton (){
        Application.Quit ();
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
