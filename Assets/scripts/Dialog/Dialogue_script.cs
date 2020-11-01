using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_script : MonoBehaviour
{
    public string text;

    public void destroy()
    {
		try{

		Camera.main.GetComponent<SoundManager>().play_clickSound();
		Camera.main.GetComponent<PauseManager>().ResumeifPaused();

		}
		catch {

		}
        GameObject.Destroy (gameObject);

    }

    public void show(string text)
    {
        this.text = text;
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
