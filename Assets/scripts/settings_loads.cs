using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings_loads : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var music_name = Camera.main.GetComponent<save_manager>().get_music();
        var music_vol =
            Camera.main.GetComponent<save_manager>().get_music_vol();
UnityEngine.Debug.Log($"saved music is {music_vol}");

        var fx_vol = Camera.main.GetComponent<save_manager>().get_effects_vol();
UnityEngine.Debug.Log($"saved fx is {fx_vol}");

        var res = 0;
        var saved_side = (Camera.main.GetComponent<save_manager>().get_ui_direction()=="Lefties")?0:1;
        side_dropDown.value = saved_side;
      
	    switch (music_name)
        {
           
            case "Morrow":
                res = 1;
                break;
            case "ForgottenLand":
                res = 0;
                break;
            default:
                res = 0;
                break;
        }
		
        music_dropDown.value = res;
        music_slider.value = music_vol;
        fx_slider.value = fx_vol;
    }

    public TMPro.TMP_Dropdown music_dropDown;
    public TMPro.TMP_Dropdown side_dropDown;

    public UnityEngine.UI.Slider music_slider;

    public UnityEngine.UI.Slider fx_slider;

    // Update is called once per frame
    void Update()
    {
    }
}
