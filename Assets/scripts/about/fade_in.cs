using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
public class fade_in : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (auto_start) Start_coloring();
    }
int get_my_num(){
	var par=gameObject.transform.parent;
	int i=0;
foreach (Transform child in par) {
i++;
if (par.getChild(i)==transform)
return i;
return -1;
}
}
    public bool start = false;

    public bool auto_start = false;

    Stopwatch SW = new Stopwatch();

    public void Start_coloring()
    {
        SW.Restart();
        start = true;
    }

    public GameObject next;

    public float delay = 0;
bool fired=false;
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();

            textmeshPro.color =
                Color
                    .Lerp(textmeshPro.color,
                    new Color(textmeshPro.color.r,textmeshPro.color.g,textmeshPro.color.b,.98f),
                    Time.deltaTime);
            if (SW.Elapsed.TotalSeconds > 7 || )
            {
                if (next != null && !fired)
                {
                    next.GetComponent<fade_in>().Start_coloring();
                    //start = false;
					fired=true;
                }
            }
        }
    }
}
