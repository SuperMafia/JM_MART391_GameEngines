using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    // public string Level0;

    // Update is called once per frame
    public void StartGame()
    {
        Debug.Log("Loading Level...");
        // SceneManager.LoadScene(Level0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OptionMenu()
    {
        Debug.Log("I am a robot for the future. Blarp.");
    }
    public void QuitGame()
    {
        Debug.Log("I await your Game... -RebelTaxi");
        Application.Quit();
    }
}
