using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider_script_vol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void set_music_vol(float vol)
    {
        Camera
            .main
            .GetComponent<save_manager>()
            .set_music_vol(GetComponent<Slider>().value);

        Camera.main.GetComponent<SoundManager>().AdjustSoundPreferences();
    }

    public void set_fx_vol(float vol)
    {
        Camera
            .main
            .GetComponent<save_manager>()
            .set_effects_vol(GetComponent<Slider>().value);

        Camera.main.GetComponent<SoundManager>().AdjustSoundPreferences();
    }
}
