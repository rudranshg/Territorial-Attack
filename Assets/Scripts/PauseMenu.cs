using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseUI;
    public Slider powerslider;
    public Button[] buttons;

    public GameObject pause;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        pause.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        powerslider.interactable = true;
        for (int i = 0; i < 9; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void Pause()
    {
        pause.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        powerslider.interactable = false;
        for(int i=0;i<9;i++)
        {
            buttons[i].interactable = false;
        }
    }

    public void interact()
    {
        for (int i = 0; i < 9; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
