using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        // Loads a scene. May change this to move to a new menu for level select later
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Debug.Log("nice quit ya got there"); // quitting doesn't happen in editor, so this lets me know it works
        Application.Quit(); // quits the game
    }
}
