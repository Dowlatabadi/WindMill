using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash_go : MonoBehaviour
{
	public void idle_state()
    {
	
		GetComponent<Animator>().SetBool("should_flash", false);
		Destroy(gameObject);
       
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
