using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pause : MonoBehaviour
{
    public static bool paused  = false;
    public GameObject menuPause;
     void Update()
    {
        GamePaused();
    }

    void GamePaused()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (paused)
            {
                Continue();
            }
            else
            {
                PauseGame();
            }
        }
    }
    void Continue()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
    }
    void PauseGame()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
}
