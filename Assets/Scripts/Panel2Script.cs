using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel2Script : MonoBehaviour
{
    public void RestartButton()
    {

        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }


    public void ExitButton()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
