using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_hid_show : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void grow()
    {
        var anmtr = gameObject.transform.GetComponent<Animator>();
        anmtr.SetBool("grow", true);
        anmtr.SetBool("shrink", false);
    }

    public void shrink()
    {
        var anmtr = gameObject.transform.GetComponent<Animator>();
        anmtr.SetBool("shrink", true);
        anmtr.SetBool("grow", false);
    }
}
