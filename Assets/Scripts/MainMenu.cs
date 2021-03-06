using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Play(int index)
    {
        SceneManager.LoadScene(index);
    }
 
    public void Exit()
    {
        Debug.Log("EXIT!");
        Application.Quit();
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().PlayMusic("MainMenuTheme");
    }

}
