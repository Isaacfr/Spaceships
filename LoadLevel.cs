using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoad;

    public void ApplicationLoadLevel()
    {
        Application.LoadLevel(levelToLoad);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
