using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failure_event : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	public void failure_call()
	{
		
		Camera.main.GetComponent<game1_manager>().OneMistakeOccured();

	}
	public void play_sound()
	{
		  Camera.main.GetComponent<SoundManager>().play_failure();

	}
}
