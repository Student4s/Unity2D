using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Game : MonoBehaviour
{
    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }
}
