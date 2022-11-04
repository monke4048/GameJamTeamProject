using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTiltleScreen : MonoBehaviour
{
    // Open a selected scene
    public string sceneName;
    public void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    //  Active and deactive
    // GameOnject -> Use the new keyword if hiding was intended.
    public Component[] components;
    public void ActiveAndDeactive()
    {
        foreach (var component in components)
        {
            component.gameObject.SetActive(!component.gameObject.activeSelf);
        }
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
