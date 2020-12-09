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
        GetComponent<Animator>().SetBool("should_blink", true);
    }

    public void blink_off()
    {
        GetComponent<Animator>().SetBool("should_blink", false);
    }
}
