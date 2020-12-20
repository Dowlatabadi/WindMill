using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void Scene_Playground()
    {
        Camera.main.GetComponent<loading_manager>().fade_in_blur();

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Game1");
    }

    public void Scene_Selection()
    {
        Camera.main.GetComponent<loading_manager>().fade_in_blur();
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Selection");
    }

    public void Scene_About()
    {
        Camera.main.GetComponent<loading_manager>().fade_in_blur();

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("About");
    }

    public void Scene_Intro(bool stop_current_scene = false)
    {
        Camera.main.GetComponent<loading_manager>().fade_in_blur();
        if (stop_current_scene)
        {
            try
            {
                var cyl_gos =
                    GameObject.FindGameObjectsWithTag("cylinderparent");
                foreach (var item in cyl_gos)
                {
                    item.GetComponent<rotate>().enabled = false;
                }
            }
            catch (System.Exception)
            {
            }
        }
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("intro");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void Scene_LastLvlPlay()
    {
		var last= Camera.main.GetComponent<save_manager>().get_progress_lvl();
		if (last>50)
		{
			last=50;
		}
        PlayerPrefs
            .SetInt("temp_lvl_num",last
           );
        Debug
            .Log("saved last: " +
            Camera.main.GetComponent<save_manager>().get_progress_lvl());
        Camera.main.GetComponent<loading_manager>().fade_in_blur();

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Game1");
    }

    public void Scene_Playground_LevelParameters(int Lvl_num)
    {
        PlayerPrefs.SetInt("temp_lvl_num", Lvl_num);
        Camera.main.GetComponent<loading_manager>().fade_in_blur();
        Camera.main.GetComponent<SoundManager>().play_clickSound();

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Game1");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
