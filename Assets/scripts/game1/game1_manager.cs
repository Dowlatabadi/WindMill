﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Classes;
using LinePoint;
using TMPro;
using UnityEngine;

public class game1_manager : MonoBehaviour
{
    public GameObject sub_1;

    public GameObject sub_2;

    //-3,3 x
    //-2,2 y
    public GameObject checkpivot_pefab;

    public List<Vector2> pivots_pos;

    Level lvl;

    public GameObject DialoguePrefab;

    public GameObject W_DialoguePrefab;

    int current_order;

    int failure_counter;

    int renew_limit = 3;

    List<GameObject> gos = new List<GameObject>();

    public GameObject spawn_location;

    public List<int> current_labels = new List<int>();

    public List<GameObject> seen = new List<GameObject>();

    public int OneHitOccured(GameObject pivot)
    {
        //shouldn't some labled pivot be qual in number
        //shouldn't be met again
        StartCoroutine(waitandAdjustSpeed());
        return ++current_order;
    }

    public IEnumerator waitandAdjustSpeed()
    {
        yield return new WaitForSeconds(.2f);
        MillSpeedAdjust();
        yield return new WaitForSeconds(.2f);
        MillSpeedAdjust();
        yield return new WaitForSeconds(.2f);
        MillSpeedAdjust();
    }

    string current_message = "default";

    string current_header = "";

    public void first_button_pressed()
    {
		
remove_guid();
		
        info_btn.gameObject.SetActive(false);
        First_button.gameObject.SetActive(false);
        var pivot_creation =
            (
            gamemode == game_mode.pivotCreation_orderise ||
            gamemode == game_mode.pivotCreation_inaccessible_pivots
            );

        //if pivot creation choose out of two type pivots
        if (pivot_creation)
        {
            //popup two choices
            sub_1.GetComponent<btn_hid_show>().grow();
            sub_2.GetComponent<btn_hid_show>().grow();
        }
        else
        //else if mill creation
        {
            var mill = GameObject.FindWithTag("cylinderparent");
            mill.GetComponent<rotate>().start();
            mill.GetComponent<rotate>().blink_off();
        }
    }

    public void spawn_pivot_at_cross_loc(bool clockWise)
    {
        var cross_sp_renderer =
            GameObject.FindWithTag("cross").GetComponent<SpriteRenderer>();
        var position = GameObject.FindWithTag("cross").transform.position;
        var go =
            GameObject
                .Instantiate(checkpivot_pefab, position, Quaternion.identity);

        if (clockWise)
        {
            go.gameObject.tag = "clockwise";
            go.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            go.GetComponent<SpriteRenderer>().color = Color.blue;
            go.gameObject.tag = "counterclockwise";
        }
        sub_1.GetComponent<btn_hid_show>().shrink();
        sub_2.GetComponent<btn_hid_show>().shrink();
        cross_sp_renderer.enabled = false;

        //spund maybe
        //a little delay todo
        var mill = GameObject.FindWithTag("cylinderparent");
        mill.GetComponent<rotate>().start();
        GameObject
            .FindWithTag("cross")
            .GetComponent<Animator>()
            .SetBool("blink", false);
    }

    public IEnumerator wait_and_go_next(int secs)
    {
        yield return new WaitForSeconds(secs);
        if (!is_lvl_solved)
            Camera.main.GetComponent<PauseManager>().ResumeifPaused();
        else
        {
            //Camera.main.GetComponent<game1_manager>().check_success();
            Camera.main.GetComponent<game1_manager>().goto_last_lvl();
        }
        // UnityEngine.Debug.Log($"string show was empty. white ={22} and ");
    }

    void increase_speed()
    {
        speed_up_fact = 2f;
        speed_up = true;
    }

    bool speed_up = false;

    void reset_speed()
    {
        speed_up_fact = 1f;

        speed_up = false;
        general_mill.GetComponent<rotate>().speed = 20;
    }

    public IEnumerator wait_and_show(string st, bool white, string header = "")
    {
        var temp_lvl = PlayerPrefs.GetInt("temp_lvl_num");

        var lvl_details =
            Levels_Data.levels_info.FirstOrDefault(x => x.lvl_num == temp_lvl);

        increase_speed();
        if (white)
        {
            UnityEngine.Debug.Log($"shouldn't happen");
            yield return new WaitForSeconds(lvl_details.finish_delay);
        }

        reset_speed();

        //destroy other messages
        var prev_go = GameObject.FindGameObjectWithTag("DialogueBox");

        if (prev_go != null)
        {
            GameObject.Destroy (prev_go);
        }

        //instantiating new dialogue
        if (st == null) st = current_message;
        var go =
            GameObject
                .Instantiate(white ? W_DialoguePrefab : DialoguePrefab,
                new Vector3(0, 0, DialoguePrefab.transform.position.z),
                Quaternion.identity);
        gameObject.GetComponent<PauseManager>().PauseifPlaying();

        go.GetComponent<Dialogue_script>().show(st, header);
        go
            .transform
            .SetParent(GameObject.FindGameObjectWithTag("Canvas").transform,
            false);
        Camera.main.GetComponent<PauseManager>().Stops();
    }

    public void show(string st, bool white = false, string header_text = "")
    {
        if (st.Contains("empty"))
        {
            var wait = 0;

            //            UnityEngine.Debug.Log($"<color=white>white</color>");
            StartCoroutine(wait_and_go_next(2));

            return;
        }
        StartCoroutine(wait_and_show(st, white, header_text));
    }

    public void OneMistakeOccured()
    {
        var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];

        cyl_parent.transform.parent = null;
        failure_counter++;
        if (failure_counter > renew_limit)
        {
            //UnityEngine.Debug.Log("renew1");
            renew();
        }
        else
        {
            // UnityEngine.Debug.Log("reset1");
            reset();
        }
    }

    public GameObject First_button;

    public void goto_last_lvl()
    {
        //        UnityEngine.Debug.Log($"goto to");
        Camera.main.GetComponent<Notation_manager>().Update_Notations();
        var temp_prefs_is_set = PlayerPrefs.HasKey("temp_lvl_num");
        if (temp_prefs_is_set)
        {
            var temp_lvl = PlayerPrefs.GetInt("temp_lvl_num");
            if (temp_lvl == 51)
            {
                gameObject.GetComponent<Scene_manager>().Scene_Selection();
                return;
            }

            //            UnityEngine.Debug.Log($"goto tem_lvl={temp_lvl}");
            var lvl_details =
                Levels_Data
                    .levels_info
                    .FirstOrDefault(x => x.lvl_num == temp_lvl);
            lvl =
                new Level(lvl_details.header_text,
                    lvl_details.gamemode,
                    lvl_details.c,
                    lvl_details.cc,
                    lvl_details.labeled_ratio,
                    lvl_details.welcome_info,
                    lvl_details.end_info,
                    lvl_details.start_vct,
                    lvl_details.predefined_locations,
                    lvl_details.pivot_creation_answer);

            var SM = Camera.main.GetComponent<save_manager>();
            if (!SM.is_last_lvl_seen())
            {
                var last_progress = SM.get_progress_lvl();
                if (last_progress == temp_lvl)
                {
                    //show dialogue
                    show(lvl.Info, false, lvl.header_text);
                    PlayerPrefs.SetInt("is_last_lvl_seen_yet", 1);
                }
            }
            current_message = lvl_details.welcome_info;
            current_header = lvl_details.header_text;
        }
        else
        {
            lvl =
                new Level("",
                    game_mode.millCreataion_inaccessible_pivots,
                    6,
                    0,
                    1f,
                    "",
                    "",
                    new Vector2(0, 1));
        }

        gamemode = lvl.gamemode;
        reset();
    }

    public bool is_lvl_solved;

    public GameObject primary_pvt;

    bool is_end_message_shown_once = false;

    public void show_current_info()
    {
        show(current_message, false, current_header);
        info_btn.GetComponent<Animator>().SetBool("Blink", false);
    }

    public GameObject info_btn;

    public void info_charged()
    {
        var temp_lvl = PlayerPrefs.GetInt("temp_lvl_num");
        var lvl_details =
            Levels_Data.levels_info.FirstOrDefault(x => x.lvl_num == temp_lvl);
        current_message = lvl_details.welcome_info;
        current_header = lvl_details.header_text;
        info_btn.GetComponent<Animator>().SetBool("Blink", true);
    }

    public bool check_success(GameObject current_pvt = null)
    {
        var failed = false;
        var gamemode = Camera.main.GetComponent<game1_manager>().gamemode;
        var AccessModeGame =
            (
            gamemode == game_mode.pivotCreation_inaccessible_pivots ||
            gamemode == game_mode.millCreataion_inaccessible_pivots
            );
        var all_pivots =
            GameObject
                .FindGameObjectsWithTag("clockwise")
                .Union(GameObject.FindGameObjectsWithTag("counterclockwise"));
        var lvl_solved = true; //initiate value

        var mill = GameObject.FindGameObjectsWithTag("cylinderparent")[0];

        var mill_rotation = (int) mill.transform.eulerAngles.z;
        var loop_detected = false;
        if (current_pvt != null)
        {
            loop_detected =
                current_pvt
                    .GetComponent<pivotActions>()
                    .solved_angle
                    .Any(A => Mathf.Abs(mill_rotation - A) <= 3);
        }

        //UnityEngine.Debug.Log($"<color=red> loop_detected {loop_detected} <color>");
        if (AccessModeGame)
        {
            lvl_solved =
                all_pivots
                    .Where(x =>
                        x.GetComponent<pivotActions>().get_my_num() != 999)
                    .All(x => x.GetComponent<pivotActions>().solved);
            if (
                !all_pivots
                    .Any(x =>
                        x.GetComponent<pivotActions>().get_my_num() == 999) &&
                lvl_solved
            )
            {
                lvl_solved = true;
            }
            else if (lvl_solved && !loop_detected)
            {
                lvl_solved = false;
            }
            else if (!lvl_solved && loop_detected)
            {
                failed = true;
            }
        }
        else
        {
            //order mode
            lvl_solved =
                all_pivots
                    .Where(x =>
                        x.GetComponent<pivotActions>().get_my_num() != 999)
                    .All(x => x.GetComponent<pivotActions>().solved);
            if (!lvl_solved && loop_detected)
            {
                failed = true;
            }
            else if (loop_detected && lvl_solved)
            {
                lvl_solved = true;
            }
            else if (
                lvl_solved &&
                !all_pivots
                    .Any(x =>
                        x.GetComponent<pivotActions>().get_my_num() == 999)
            )
            {
                lvl_solved = true;
            }
            else
            {
                lvl_solved = false;
            }
        }
        if (lvl_solved)
        {
            // UnityEngine.Debug.Log("endddddddd");
            //show end dialogue
            var temp_prefs_is_set = PlayerPrefs.HasKey("temp_lvl_num");
            if (temp_prefs_is_set)
            {
                var temp_lvl = PlayerPrefs.GetInt("temp_lvl_num");
                var lvl_details =
                    Levels_Data
                        .levels_info
                        .FirstOrDefault(x => x.lvl_num == temp_lvl);
                if (!is_end_message_shown_once)
                {
                    show(lvl_details.end_info, true);
                    Camera
                        .main
                        .GetComponent<SoundManager>()
                        .play_successSound();

                    //flashes
                    Camera
                        .main
                        .GetComponent<effect_mananger>()
                        .flash_blue(current_pvt);
                    is_end_message_shown_once = true;
                }

                var SV = Camera.main.GetComponent<save_manager>();

                //set max level for next level
                if (!is_lvl_solved)
                {
                    SV.Unlock_and_save(temp_lvl + 1);

                    //                    UnityEngine.Debug.Log($"next is set to= {temp_lvl + 1}");
                    is_lvl_solved = true;
                }
            }
            else
            {
                var p =
                    all_pivots
                        .Where(x => !x.GetComponent<pivotActions>().solved)
                        .Count();
                // UnityEngine
                //     .Debug
                //     .Log($"nt solvd,gos={gos.Count()}, faults={p}");
            }

            return true;
        }
        if (failed)
        {
            current_pvt.GetComponent<pivotActions>().failed();
            //call pivot failure
        }

        return false;
    }

    void renew()
    {
    }

    public void reset_button()
    {
        if (GetComponent<PauseManager>().playing_or_Paused())
        {
            reset();
        }
    }

    void reset()
    {
		GetComponent<PauseManager>().Stops();
		GetComponent<Notation_manager>().lvl_btn_off();
        failure_counter = 0;
        First_button.gameObject.SetActive(true);
        info_btn.gameObject.SetActive(true);

        is_lvl_solved = false;
        is_end_message_shown_once = false;
        current_labels = new List<int>();
        seen = new List<GameObject>();
        var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];
        cyl_parent.GetComponent<rotate>().stop();
        current_order = 0;
        destroy_all(gos.ToArray());
        var cs = GameObject.FindGameObjectsWithTag("clockwise");
        destroy_all (cs);
        var ccs = GameObject.FindGameObjectsWithTag("counterclockwise");
        destroy_all (ccs);

        // UnityEngine.Debug.Log("reset");
        Draw_level (lvl);
        info_btn.GetComponent<Animator>().SetBool("Blink", false);
    }

    void destroy_all(GameObject[] gos)
    {
        foreach (var pvt_go in gos)
        {
            GameObject.Destroy (pvt_go);
        }
    }

    public byte check_transparency = 60;

    void Draw_level(Level lvl)
    {
        var cross_sp_renderer =
            GameObject.FindWithTag("cross").GetComponent<SpriteRenderer>();
        var label_less =
            (
            gamemode == game_mode.millCreataion_inaccessible_pivots ||
            gamemode == game_mode.pivotCreation_inaccessible_pivots
            );

        //hide cross
        var needs_cross =
            (
            gamemode == game_mode.pivotCreation_orderise ||
            gamemode == game_mode.pivotCreation_inaccessible_pivots
            );
        var text = First_button.GetComponentInChildren<TextMeshProUGUI>();

        if (!needs_cross)
        {
            cross_sp_renderer.enabled = false;
            text.text = "Start";
        }
        else
        {
            cross_sp_renderer.enabled = true;
            text.text = "Create";
        }
        var debug_str = "";

        // UnityEngine.Debug.Log("all lvl pivots: " + lvl.Pivots.Count());
        var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];
        gos = new List<GameObject>();
        int i = 0;
        var rand_indexes =
            lvl
                .Pivots
                .Select((x, ind) => ind)
                .OrderBy(x => UnityEngine.Random.value)
                .ToArray();
				if (lvl.header_text=="Intro.."){

spawn_guid(lvl.Pivots.ElementAt(0).pivot_pos);
		}
        foreach (var pvt in lvl.Pivots)
        {
            if (lvl.Omited_answer == i && needs_cross)
            {
                i++;
                continue;
            }
            i++;
            pivots_pos.Add(pvt.pivot_pos);
            GameObject go;

            if (pvt.labeled || (pvt.order_num == -1000))
            {
                go =
                    GameObject
                        .Instantiate(checkpivot_pefab,
                        new Vector3(pvt.pivot_pos.x,
                            pvt.pivot_pos.y,
                            checkpivot_pefab.transform.position.z),
                        Quaternion.identity);

                current_labels.Add(pvt.order_num);

                go.GetComponent<pivotActions>().set_number(pvt.order_num, true);
                if (!label_less && (pvt.order_num != -1000))
                {
                    go
                        .transform
                        .Find("bigger_check")
                        .GetComponent<SpriteRenderer>()
                        .color = new Color32(255, 255, 255, 100);
                }
            }
            else
            {
                go =
                    GameObject
                        .Instantiate(checkpivot_pefab,
                        new Vector3(pvt.pivot_pos.x,
                            pvt.pivot_pos.y,
                            checkpivot_pefab.transform.position.z),
                        Quaternion.identity);
            }

            go.GetComponent<pivotActions>().labled = pvt.labeled;
            if (failure_counter == 0)
            {
                go.GetComponent<dest_move>().Move = true;
                go.GetComponent<dest_move>().DestPos = go.transform.position;
                go.transform.position =
                    lvl.Pivots.ElementAt(rand_indexes[i - 1]).pivot_pos * 2;
            }
            if (pvt.pivot_type == Pivot_type.ClockWise)
            {
                go.gameObject.tag = "clockwise";

                go.GetComponent<SpriteRenderer>().color = Color.red;
                go
                    .transform
                    .Find("graphics")
                    .GetComponent<SpriteRenderer>()
                    .color =
                    new Color((103f / 255f), (69f / 255f), (125f / 255f), .6f);
                go
                    .transform
                    .Find("graphics")
                    .GetComponent<Animator>()
                    .SetBool("clockwise", true);
                if (!pvt.labeled || label_less)
                {
                    go
                        .transform
                        .Find("bigger_check")
                        .GetComponent<SpriteRenderer>()
                        .color = new Color32(255, 0, 0, check_transparency);
                }
            }
            else
            {
                go.GetComponent<SpriteRenderer>().color = Color.blue;
                go
                    .transform
                    .Find("graphics")
                    .GetComponent<SpriteRenderer>()
                    .color =
                    new Color((103f / 255f), (69f / 255f), (125f / 255f), .6f);
                go
                    .transform
                    .Find("graphics")
                    .GetComponent<SpriteRenderer>()
                    .flipX = true;
                go
                    .transform
                    .Find("graphics")
                    .GetComponent<Animator>()
                    .SetBool("clockwise", false);
                if (!pvt.labeled || label_less)
                {
                    go
                        .transform
                        .Find("bigger_check")
                        .GetComponent<SpriteRenderer>()
                        .color = new Color32(0, 0, 255, check_transparency);
                }
                go.gameObject.tag = "counterclockwise";
            }
            if (pvt.order_num == -1000)
            {
                // go.GetComponent<SpriteRenderer>().color = new Color((103f/255f), (69f/255f), (125f/255f), 1f);
                go.GetComponent<SpriteRenderer>().enabled = false;

                go.transform.Find("number").GetComponent<TextMeshPro>().color =
                    new Color32(0, 89, 8, 255);

                go
                    .transform
                    .Find("graphics")
                    .GetComponent<SpriteRenderer>()
                    .enabled = false;
                var b1 = go.transform.Find("black1");
                var b2 = go.transform.Find("black2");
                var b3 = go.transform.Find("black3");
                var b4 = go.transform.Find("black4");

                b1.GetComponent<SpriteRenderer>().enabled = true;
                b1.GetComponent<Animator>().enabled = true;
                b1.GetComponent<Animator>().SetBool("clockwise", true);
                b2.GetComponent<SpriteRenderer>().enabled = true;
                b2.GetComponent<Animator>().enabled = true;
                b2.GetComponent<Animator>().SetBool("clockwise", false);
                b3.GetComponent<SpriteRenderer>().enabled = true;
                b3.GetComponent<Animator>().enabled = true;
                b3.GetComponent<Animator>().SetBool("clockwise", true);
                b4.GetComponent<SpriteRenderer>().enabled = true;
                b4.GetComponent<Animator>().enabled = true;
                b4.GetComponent<Animator>().SetBool("clockwise", false);
            }
            gos.Add (go);
        }

        //select starting position for mill
        var index = 0;
        var starting_pivot = gos.ElementAt(0);

        //initial angle
        var mill_angle =
            new Vector3(cyl_parent.transform.eulerAngles.x,
                cyl_parent.transform.eulerAngles.y,
                -2f);
        if (!needs_cross)
        {
            var is_one_labeled = lvl.Pivots.ElementAt(0).labeled;
            if (!is_one_labeled)
            {
                var possible_choices =
                    lvl.Pivots.Skip(1).Where(x => !x.labeled);
                if (possible_choices.Any())
                {
                    index =
                        lvl
                            .Pivots
                            .Select((x, ind) => (x, ind))
                            .Skip(1)
                            .Where(t => !t.x.labeled && t.x.order_num != -1000)
                            .OrderBy(x => UnityEngine.Random.value)
                            .FirstOrDefault()
                            .ind;

                    starting_pivot = gos.ElementAt(index);
                }
            }
        }
        else
        {
            mill_angle =
                new Vector3(0,
                    0,
                    Vector2.SignedAngle(new Vector2(0, 1), lvl.start_vct));
        }

        cyl_parent.GetComponent<rotate>().SPAWN_pivot(starting_pivot);
		
        //move effect initial
        if (failure_counter == 0)
        {
            cyl_parent
                .transform
                .SetParent(gos.ElementAt(index).transform, true);
        }

        //UnityEngine.Debug.Log(gos.ElementAt(0).transform.position);
        cyl_parent.transform.eulerAngles = mill_angle;

        cyl_parent.GetComponent<rotate>().stop();
        cyl_parent.GetComponent<Animator>().enabled = true;
        if (!needs_cross)
        {
            cyl_parent.GetComponent<rotate>().blink();
        }
        else
        {
            GameObject
                .FindWithTag("cross")
                .GetComponent<Animator>()
                .SetBool("blink", true);
        }
		
    }

    public game_mode gamemode;
    public GameObject guide_prefab;
public void spawn_guid(Vector3 position){
	GameObject.Instantiate(guide_prefab,position+new Vector3(0.1f,-.2f,0),Quaternion.identity);
}
public void remove_guid(){
	GameObject.Destroy( GameObject.FindWithTag("guide"));
}
    public void MillSpeedAdjust()
    {
        if (primary_pvt == null)
        {
            return;
        }
        var all_pivots =
            GameObject
                .FindGameObjectsWithTag("clockwise")
                .Union(GameObject.FindGameObjectsWithTag("counterclockwise"));
        if (all_pivots.Count() == 1)
        {
            general_mill.GetComponent<rotate>().speed = 25f;
            return;
        }
        var mill_vect =
            new Vector2(-Mathf
                    .Sin(general_mill.transform.eulerAngles.z * Mathf.Deg2Rad),
                Mathf
                    .Cos(general_mill.transform.eulerAngles.z * Mathf.Deg2Rad));
        var Clocksign = (primary_pvt.tag == "clockwise" ? 1 : -1);
        var (next_pvt, angle_dist) =
            Helper.next_order(all_pivots, primary_pvt, Clocksign, mill_vect);

        //debug only
        if (debug)
        {
            next_pvt.GetComponent<SpriteRenderer>().color = Color.black;
            primary_pvt.GetComponent<SpriteRenderer>().color = Color.white;
        }

        ///
        var arrow =
            next_pvt.transform.position - primary_pvt.transform.position;
        var arrow_2d = new Vector2(arrow.x, arrow.y);
        var bet_ang = Vector2.SignedAngle(mill_vect, arrow_2d);
        if (bet_ang * Clocksign > 0)
        {
            arrow_2d = new Vector2(-arrow.x, -arrow.y);
        }
        var norm_dist = Mathf.Abs(Vector2.SignedAngle(mill_vect, arrow_2d)); //between 0 and 180

        //UnityEngine.Debug.Log($"<color=yellow>bet_ang({mill_vect},{arrow})={norm_dist}</color>");
        ///
        //var dist=Helper.FindNearestPointOnLine(new Vector2(primary_pvt.transform.position.x,primary_pvt.transform.position.y),mill_vect,new Vector2(next_pvt.transform.position.x,next_pvt.transform.position.y));
        var diff = 0f;

        // if (Mathf.Abs(dist)<0.3f)
        // {
        // 	return;
        // }
        var next_speed =
            //4*sqrt(x)+10
            Mathf
                .Clamp(((float) Mathf.Pow((norm_dist / 35f) - 2.41f, 3f)) *
                speed_up_fact +
                20f,
                7f,
                30f);
        if (norm_dist < 45 && norm_dist > 5)
        {
            next_speed = Mathf.Clamp(next_speed * 3f, 7f, 30f);

        }
        if (norm_dist <= 180 && norm_dist >= 45)
        {
            next_speed = Mathf.Clamp(next_speed * 2.5f, 7f, 33f);

        }

        //	UnityEngine.Debug.Log($"<color=blue>spd={next_speed} dist={angle_dist} mill_vect is {mill_vect}</color>");
        general_mill.GetComponent<rotate>().speed = next_speed;
    }

    public float speed_up_fact = 1f;

    void Update()
    {
        // InvokeRepeating("MillSpeedAdjust", .1f, 1f);
        // if (speed_up)
        // {
        //     general_mill.GetComponent<rotate>().speed =
        //         Mathf
        //             .Clamp(general_mill.GetComponent<rotate>().speed + .6f,
        //             20f,
        //             50f);
        // }
    }

    public bool debug = false;

    GameObject general_mill;

    // Start is called before the first frame update
    void Start()
    {
        Stopwatch SW = new Stopwatch();
        SW.Restart();
        general_mill = GameObject.FindGameObjectsWithTag("cylinderparent")[0];

        Camera
            .main
            .GetComponent<Touch_manager>()
            .move_cross(new Vector3(0, 0, 0));

        // UnityEngine.Debug.Log("test slope="+Helper.PointsGetSlopeCloseness(new Vector2(0,0),new Vector2(1,0),new Vector2(0,1)));
        failure_counter = 0;
        current_order = 0;
        Camera.main.GetComponent<UIManager>().AdjustUI();

        //PlayerPrefs.SetInt("temp_lvl_num", 1);
        goto_last_lvl();
        //UnityEngine.Debug.Log($"<color=red> debug took {SW.Elapsed.Milliseconds} milli </color>");
    }
}
