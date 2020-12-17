using System;
using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;

public class pivotActions : MonoBehaviour
{
    public bool intro;

    // Start is called before the first frame update
    void Start()
    {
    }

    public bool labled;

    public bool solved = false;
    public int solved_angle = 370;

    public void check_up(bool animate)
    {
        if (animate)
        {
            gameObject
                .transform
                .Find("check")
                .GetComponent<Animator>()
                .SetBool("grow", true);
				 gameObject
                .transform
                .Find("bigger_check")
                .GetComponent<Animator>()
                .SetBool("grow", true);
            solved = true;
        }
        Camera.main.GetComponent<game1_manager>().check_success(this.gameObject);
            

			 var gamemode = Camera.main.GetComponent<game1_manager>().gamemode;
        var AccessModeGame =
            (
            gamemode == game_mode.pivotCreation_inaccessible_pivots ||
            gamemode == game_mode.millCreataion_inaccessible_pivots
            );
			//if (AccessModeGame){
  var mill = GameObject.FindGameObjectsWithTag("cylinderparent")[0];

			solved_angle =(int)mill.transform.eulerAngles.z;
			Debug.Log(solved_angle+" solved at rotation");
			//}

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
        if (str == "") return 0;
        if (str == "∞") return 999;
        return int.Parse(str);
    }

    public void set_number(int num)
    {
        var gamemode = Camera.main.GetComponent<game1_manager>().gamemode;
        var AccessModeGame =
            (
            gamemode == game_mode.pivotCreation_inaccessible_pivots ||
            gamemode == game_mode.millCreataion_inaccessible_pivots
            );
        string st = num.ToString();
        if (num == -1000) st = "∞";

        //set color first
        //gameObject.transform.Find("number").GetComponent<TMPro.TextMeshPro>().text=num.ToString();;
        gameObject
            .transform
            .Find("number")
            .GetComponent<TMPro.TextMeshPro>()
            .enabled = true;
        if (num == -1000 || (!AccessModeGame))
        {
            gameObject
                .transform
                .Find("number")
                .GetComponent<TMPro.TextMeshPro>()
                .text = st;
        }
        else
        {
            gameObject
                .transform
                .Find("number")
                .GetComponent<TMPro.TextMeshPro>()
                .text = "";
        }

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
        if (mill.GetComponent<rotate>().stopped) return;
        if (!intro)
        {
            var gamemode = Camera.main.GetComponent<game1_manager>().gamemode;
            var AccessModeGame =
                (
                gamemode == game_mode.pivotCreation_inaccessible_pivots ||
                gamemode == game_mode.millCreataion_inaccessible_pivots
                );
            var GM_script = Camera.main.GetComponent<game1_manager>();
            var current_num = GM_script.OneHitOccured(this.gameObject);
            if (!AccessModeGame)
            {
				if (get_my_num() == 999){
					 need_reset = true;
				}
                else if (!labled)
                {
                    set_number (current_num);
                    if (GM_script.current_labels.Contains(current_num))
                    {
                        need_reset = true;
                    }
                    else
                    {
                        Camera.main.GetComponent<SoundManager>().play_ding();
                        solved = true;
                        check_up(true);
                    }
                } //is labeled
                else
                {
                    if (
                        get_my_num() == current_num &&
                        !GM_script.seen.Contains(this.gameObject) &&
                        (
                        !GM_script.current_labels.Contains(current_num) ||
                        labled
                        )
                    )
                    {
                        Camera.main.GetComponent<SoundManager>().play_ding();
                        solved = true;
                        check_up(true);
						
                        GM_script.seen.Add(this.gameObject);
                        GM_script.current_labels.Add (current_num);
                    }
                    else if (
                        solved &&
                        !GM_script.current_labels.Contains(current_num)
                    )
                    {
                        check_up(false);
                        set_number (current_num);
                        Camera.main.GetComponent<SoundManager>().play_ding();
                        GM_script.current_labels.Add (current_num);
                    }
                    else
                    {
                        need_reset = true;
                    }
                }
            }
            else
            {
                // accessmode game
                if (get_my_num() == 999)
                    //if it is untouchable (infinite)
                    need_reset = true;
                else
                {
                    Camera.main.GetComponent<SoundManager>().play_ding();
                    check_up(!solved);
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
        // else
        // {
        // 	check_up();
        // }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
