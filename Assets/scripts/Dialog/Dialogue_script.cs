using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_script : MonoBehaviour
{
    public string text;

    public void destroy()
    {
		try{

		Camera.main.GetComponent<game_manager>().play_clickSound();

		}
		catch {
//		Camera.main.GetComponent<game1_manager>().play_clickSound();

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
