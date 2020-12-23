using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_manager : MonoBehaviour
{
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

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
        if (lvl_num > get_progress_lvl())
            PlayerPrefs.SetInt("Progress_lvl", lvl_num);
        PlayerPrefs.SetInt("temp_lvl_num", lvl_num);
        PlayerPrefs.SetInt("is_last_lvl_seen_yet", 0);
    }

    public void auto_inf_shown()
    {
        PlayerPrefs.SetInt("is_last_lvl_seen_yet", 1);
    }

    public int get_progress_lvl()
    {
        if (PlayerPrefs.HasKey("Progress_lvl"))
            return PlayerPrefs.GetInt("Progress_lvl");
        return 1;
    }

    public void set_music_vol(float percent)
    {
        PlayerPrefs.SetFloat("music_vol", percent);
    }

    public float get_music_vol()
    {
        if (PlayerPrefs.HasKey("music_vol"))
            return PlayerPrefs.GetFloat("music_vol");
        return .3f;
    }

    public float fx_ampli_factor = 4f;

    public void set_effects_vol(float percent)
    {
        PlayerPrefs.SetFloat("effects_vol", percent * fx_ampli_factor);
    }

    public float get_effects_vol()
    {
        if (PlayerPrefs.HasKey("effects_vol"))
            return PlayerPrefs.GetFloat("effects_vol");
        return fx_ampli_factor;
    }

    public void set_ui_direction(string direction)
    {
        PlayerPrefs.SetString("UI_Side", direction);
    }

    public string get_ui_direction()
    {
		
        if (PlayerPrefs.HasKey("UI_Side")) return PlayerPrefs.GetString("UI_Side");
        return "Righties";

    }

    public void set_music(string music_name)
    {
        PlayerPrefs.SetString("music_name", music_name);
    }

    public string get_music()
    {
        if (PlayerPrefs.HasKey("music_name"))
            return PlayerPrefs.GetString("music_name");
        return "ForgottenLand";
    }
}
