using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Notation_manager : MonoBehaviour
{
    public GameObject lvl_indicator;

    public GameObject life_prefab_alive;

    public GameObject life_prefab_dead;

    // Start is called before the first frame update
    void Start()
    {
       
    }
public void Update_Notations(){
	 var temp_prefs_is_set = PlayerPrefs.HasKey("temp_lvl_num");
        if (temp_prefs_is_set)
        {
          var lvl=PlayerPrefs.GetInt("temp_lvl_num");
            lvl_indicator.GetComponentInChildren<TextMeshProUGUI>().text =
                $"L  {lvl.ToString()}";
        }
}
    // Update is called once per frame
    void Update()
    {
    }
}
