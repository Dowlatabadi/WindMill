using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Classes;
public class Scene_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
void Awake(){

	Screen.sleepTimeout = SleepTimeout.NeverSleep;
}
    public void Scene_Playground()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Game1");
    }

    public void Scene_Selection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Selection");
    }

    public void Scene_About()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("About");
    }

    public void Scene_Intro()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("intro");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

   

 public void Scene_Playground_LevelParameters(
        int Lvl_num
    )
    {
        PlayerPrefs.SetInt("temp_lvl_num", Lvl_num);
      
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Game1");
    }
    // Update is called once per frame
    void Update()
    {
    }
}
