using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_first_time()
    {
        if (PlayerPrefs.HasKey("Progress_lvl")) return false;
        return true;
    }

    public bool is_last_lvl_seen()
    {
        if (PlayerPrefs.HasKey("is_last_lvl_seen_yet"))
            return (PlayerPrefs.GetInt("is_last_lvl_seen_yet") == 1);
			return false;
    }

    public void Unlock_and_save(int lvl_num)
    {
        PlayerPrefs.SetInt("Progress_lvl", lvl_num);
        PlayerPrefs.SetInt("is_last_lvl_seen_yet", 0);
    }

    public void auto_int_shown()
    {
        PlayerPrefs.SetInt("is_last_lvl_seen_yet", 1);
    }

    public int get_progress_lvl()
    {
        if (PlayerPrefs.HasKey("Progress_lvl"))
            return PlayerPrefs.GetInt("Progress_lvl");
        return 1;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
