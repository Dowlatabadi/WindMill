using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
 public void Scene_Playground()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game1");
    }
 public void Scene_Selection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Selection");
    }
	 public void Scene_About()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("About");
    }
	 public void Scene_Intro()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("intro");
    }
	 public void QuitApplication()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
