using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue_script : MonoBehaviour
{
    public string text;

    public void destroy()
    {
        try
        {
            Camera.main.GetComponent<SoundManager>().play_clickSound();
            if (!Camera.main.GetComponent<game1_manager>().check_success())
                Camera.main.GetComponent<PauseManager>().ResumeifPaused();
				else
				{
					Camera.main.GetComponent<game1_manager>().check_success();
					Camera.main.GetComponent<game1_manager>().goto_last_lvl();
				}
        }
        catch
        {
        }
        GameObject.Destroy (gameObject);
    }

    public void show(string text)
    {
        var textOBJ = transform.GetChild(0);
        textOBJ.gameObject.GetComponent<TextMeshProUGUI>().text = text;
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
