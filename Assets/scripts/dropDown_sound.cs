using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropDown_sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void set_current_music()
    {
        int menuIndex = GetComponent<TMPro.TMP_Dropdown>().value;
        string val = GetComponent<TMPro.TMP_Dropdown>().options[menuIndex].text;

        var res = "";
        switch (menuIndex)
        {
            case 0:
                res = "Supersonic";
                break;
            case 1:
                res = "Morrow";
                break;
				 case 2:
                res = "ForgottenLand";
                break;
            default:
                res = "Supersonic";
                break;
        }
        Camera.main.GetComponent<save_manager>().set_music(res);
        Camera.main.GetComponent<SoundManager>().AdjustSoundPreferences();
		
    }
}
