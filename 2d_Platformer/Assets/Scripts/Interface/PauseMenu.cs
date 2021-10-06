using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public void Go_to_MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }

    public void Pause_end()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
