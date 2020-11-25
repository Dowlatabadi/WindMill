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

   

    public void Lvl1()
    {
        Scene_Playground_LevelParameters(1,
        1,
        game_mode.millCreataion_orderise,
        .5f);
    }

    public void Lvl2()
    {
        Scene_Playground_LevelParameters(1,
        2,
        game_mode.pivotCreation_orderise,
        1f);
    }

    public void Lvl3()
    {
        Scene_Playground_LevelParameters(0,
        4,
        game_mode.millCreataion_inaccessible_pivots,
        .5f);
    }

    public void Lvl4()
    {
        Scene_Playground_LevelParameters(1,
        4,
        game_mode.pivotCreation_inaccessible_pivots,
        .5f);
    }

    public void Lvl5()
    {
        Scene_Playground_LevelParameters(3,
        1,
        game_mode.pivotCreation_inaccessible_pivots,
        .5f);
    }
 public void Scene_Playground_LevelParameters(
        int cc,
        int c,
        game_mode gamemode,
        float lb_ratio
    )
    {
        PlayerPrefs.SetInt("temp_cc", cc);
        PlayerPrefs.SetInt("temp_gamemode", (int) gamemode);
        PlayerPrefs.SetInt("temp_c", c);
        PlayerPrefs.SetFloat("temp_ratio", lb_ratio);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Game1");
    }
    // Update is called once per frame
    void Update()
    {
    }
}
