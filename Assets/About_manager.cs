using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class About_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public int signal=0;
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
signal++;
		}
    }
}
