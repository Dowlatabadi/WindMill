using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivotActions : MonoBehaviour
{
    public bool intro;

    // Start is called before the first frame update
    void Start()
    {
    }

    public bool labled;

    public void check_up()
    {
        gameObject
            .transform
            .Find("check")
            .GetComponent<Animator>()
            .SetBool("grow", true);
    }
 public void failed()
    {
		var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];
        cyl_parent.GetComponent<rotate>().stop();
        gameObject
            .transform
            .Find("failure")
            .GetComponent<Animator>()
            .SetBool("grow", true);
			
    }
    public int get_my_num()
    {
        var str =
            gameObject
                .transform
                .Find("number")
                .GetComponent<TMPro.TextMeshPro>()
                .text;
        return int.Parse(str);
    }

    public void set_number(int num)
    {
        //set color first
        //gameObject.transform.Find("number").GetComponent<TMPro.TextMeshPro>().text=num.ToString();;
        gameObject
            .transform
            .Find("number")
            .GetComponent<TMPro.TextMeshPro>()
            .enabled = true;
        gameObject
            .transform
            .Find("number")
            .GetComponent<TMPro.TextMeshPro>()
            .text = num.ToString();
        gameObject
            .transform
            .Find("number")
            .GetComponent<Animator>()
            .SetBool("grow", true);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        var need_reset = false;
        GameObject mill = null;
        if (col != null)
            mill = col.transform.gameObject.transform.parent.gameObject;
        else
        {
            mill = GameObject.FindGameObjectsWithTag("cylinderparent")[0];
        }
        if (mill.GetComponent<rotate>().stopped)  return;
        if (!intro)
        {
            
            var GM_script = Camera.main.GetComponent<game1_manager>();
            var current_num = GM_script.OneHitOccured(this.gameObject);
            if (!labled)
            {
                set_number (current_num);
                if (GM_script.current_labels.Contains(current_num))
                {
                    need_reset = true;
                }
				else{
					Camera.main.GetComponent<SoundManager>().play_ding();

				}
            }
            else
            {
                if (
                    get_my_num() == current_num &&
                    !GM_script.seen.Contains(this.gameObject) &&
                    (!GM_script.current_labels.Contains(current_num) || labled)
                )
                {
					Camera.main.GetComponent<SoundManager>().play_ding();
                    check_up();
                    GM_script.seen.Add(this.gameObject);
                    GM_script.current_labels.Add (current_num);
                }
                else
                {
                    need_reset = true;
                }
            }
        }

        if (this.gameObject.tag == "clockwise")
            mill.GetComponent<rotate>().set_pivot(this.gameObject, true);
        else if (this.gameObject.tag == "counterclockwise")
            mill.GetComponent<rotate>().set_pivot(this.gameObject, false);
        if (need_reset)
        {
           
 failed();
    
Debug.Log("sound");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
