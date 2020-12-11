using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross_blinks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void blink(){
	GetComponent<SpriteRenderer>().enabled=true;
	GetComponent<Animator>().SetBool("blink",true);
}
public void blink_off(){
	GetComponent<SpriteRenderer>().enabled=false;

	GetComponent<Animator>().SetBool("blink",false);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
