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
    // GameObject -> Use the new keyword if hiding was intended.
    public Component[] components;
    public void ActiveAndDeactive()
    {
        foreach (var component in components)
        {
            component.gameObject.SetActive(!component.gameObject.activeSelf);
        }
    }

    // redirect to a website
    // e.g. https://www.google.com
    public string url;
    public void Redirect()
    {
        Application.OpenURL(url);
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
