using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_blink : MonoBehaviour
{
    void Start()
    {
    }

    public void blink()
    {
		GameObject.FindWithTag("cross").
        GetComponent<Animator>().SetBool("blink", true);
    }

    public void blink_off()
    {
       	GameObject.FindWithTag("cross").
        GetComponent<Animator>().SetBool("blink", false);
    }
}
