using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue_script : MonoBehaviour
{
    public string text;

    public void destroy()
    {
        Camera.main.GetComponent<PauseManager>().Reset_Thinking();
        try
        {
            Camera.main.GetComponent<SoundManager>().play_clickSound();
            if (!Camera.main.GetComponent<game1_manager>().check_success())
                Camera.main.GetComponent<PauseManager>().ResumeifPaused();
            else
            {
                //Camera.main.GetComponent<game1_manager>().check_success();
                Camera.main.GetComponent<game1_manager>().goto_last_lvl();
            }
        }
        catch
        {
        }
        GameObject.Destroy (gameObject);
            var temp_lvl = PlayerPrefs.GetInt("temp_lvl_num");
		
		if (temp_lvl == 51)
            {
                Camera.main.gameObject.GetComponent<Scene_manager>().Scene_Intro();
               
            }
    }

    public void show(string text,string title="")
    {
        var textOBJ = transform.GetChild(0);
        textOBJ.gameObject.GetComponent<TextMeshProUGUI>().text = text;
	   var rectTransform =textOBJ.gameObject.GetComponent<RectTransform>();
		if (title!=""){

			rectTransform.anchoredPosition=new Vector2(rectTransform.anchoredPosition.x,-804);
			var titleOBJ = transform.GetChild(1);
			
        titleOBJ.gameObject.GetComponent<TextMeshProUGUI>().text = title;
		}
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
