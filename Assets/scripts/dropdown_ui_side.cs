using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropdown_ui_side : MonoBehaviour
{
  public void set_current_UI_direction()
    {
        int menuIndex = GetComponent<TMPro.TMP_Dropdown>().value;
        
        var res = "";
        switch (menuIndex)
        {
            case 0:
                res = "Lefties";
                break;
            case 1:
                res = "Righties";
                break;
			
            default:
                res = "Righties";
                break;
        }
        Camera.main.GetComponent<save_manager>().set_ui_direction(res);
       
	}
}
