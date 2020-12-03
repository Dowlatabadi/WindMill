using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_settings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void close(){
		var obj=GameObject.FindWithTag("Settings");
		Camera.main.GetComponent<SoundManager>().play_clickSound();
		Destroy(obj);
	}
}
