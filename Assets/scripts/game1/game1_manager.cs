using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Classes;
using LinePoint;
using UnityEngine;

public class game1_manager : MonoBehaviour
{
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
        return ++current_order;
    }

    string current_message = "default";

    public void show(string st, bool white = false)
    {
        gameObject.GetComponent<PauseManager>().PauseifPlaying();

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
        go.GetComponent<Dialogue_script>().show(st);
        go
            .transform
            .SetParent(GameObject.FindGameObjectWithTag("Canvas").transform,
            false);
    }

    public void OneMistakeOccured()
    {
        var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];

        cyl_parent.transform.parent = null;
        failure_counter++;
        if (failure_counter > renew_limit)
        {
            UnityEngine.Debug.Log("renew1");

            renew();
        }
        else
        {
            UnityEngine.Debug.Log("reset1");

            reset();
        }
    }

    public void goto_last_lvl()
    {
        Camera.main.GetComponent<Notation_manager>().Update_Notations();
        var temp_prefs_is_set = PlayerPrefs.HasKey("temp_lvl_num");
        if (temp_prefs_is_set)
        {
            var temp_lvl = PlayerPrefs.GetInt("temp_lvl_num");
            var lvl_details =
                Levels_Data
                    .levels_info
                    .FirstOrDefault(x => x.lvl_num == temp_lvl);
            lvl =
                new Level(lvl_details.gamemode,
                    lvl_details.c,
                    lvl_details.cc,
                    lvl_details.labeled_ratio,
                    lvl_details.welcome_info,
                    lvl_details.end_info);
            var SM = Camera.main.GetComponent<save_manager>();
            if (!SM.is_last_lvl_seen())
            {
                var last_progress = SM.get_progress_lvl();
                if (last_progress == temp_lvl)
                {
                    //show dialogue
                    show(lvl.Info);
                    PlayerPrefs.SetInt("is_last_lvl_seen_yet", 1);
                }
            }
        }
        else
        {
            lvl =
                new Level(game_mode.millCreataion_inaccessible_pivots,
                    6,
                    0,
                    1f,
                    "",
                    "");
        }

        gamemode = lvl.gamemode;
        reset();
    }

    public bool is_lvl_solved;

    bool is_end_message_shown_once = false;

    public bool check_success()
    {
        var lvl_solved = gos.All(x => x.GetComponent<pivotActions>().solved);
        if (lvl_solved)
        {
            UnityEngine.Debug.Log("endddddddd");

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
				 Camera.main.GetComponent<SoundManager>().play_successSound();
                    is_end_message_shown_once = true;
                }

                var SV = Camera.main.GetComponent<save_manager>();

                //set max level for next level
                if (!is_lvl_solved)
                {
                    SV.Unlock_and_save(temp_lvl + 1);
                    UnityEngine.Debug.Log($"unlocked {temp_lvl + 1}");
                    is_lvl_solved = true;
                }
            }
            else
            {
                var p =
                    gos
                        .Where(x => !x.GetComponent<pivotActions>().solved)
                        .Count();
                UnityEngine
                    .Debug
                    .Log($"nt solvd,gos={gos.Count()}, faults={p}");
            }
            return true;
        }
        return false;
    }

    void renew()
    {
    }

    void reset()
    {
        is_lvl_solved = false;
        is_end_message_shown_once = false;
        current_labels = new List<int>();
        seen = new List<GameObject>();
        var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];
        cyl_parent.GetComponent<rotate>().stop();
        current_order = 0;
        foreach (var pvt_go in gos)
        {
            GameObject.Destroy (pvt_go);
        }

        UnityEngine.Debug.Log("reset");
        Draw_level (lvl);
    }

    void Draw_level(Level lvl)
    {
        //hide cross
        var needs_cross =
            (
            gamemode == game_mode.pivotCreation_orderise ||
            gamemode == game_mode.pivotCreation_inaccessible_pivots
            );
        if (!needs_cross) GetComponent<LineRenderer>().enabled = false;

        UnityEngine.Debug.Log("all lvl pivots: " + lvl.Pivots.Count());
        var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];
        gos = new List<GameObject>();
        int i = 0;
        foreach (var pvt in lvl.Pivots)
        {
            i++;

            pivots_pos.Add(pvt.pivot_pos);
            GameObject go;

            if (pvt.labeled)
            {
                go =
                    GameObject
                        .Instantiate(checkpivot_pefab,
                        new Vector3(pvt.pivot_pos.x,
                            pvt.pivot_pos.y,
                            checkpivot_pefab.transform.position.z),
                        Quaternion.identity);

                go.GetComponent<pivotActions>().set_number(pvt.order_num);

                current_labels.Add(pvt.order_num);
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
                go.transform.position = spawn_location.transform.position;
            }
            if (pvt.pivot_type == Pivot_type.ClockWise)
            {
                go.gameObject.tag = "clockwise";

                go.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                go.GetComponent<SpriteRenderer>().color = Color.blue;
                go.gameObject.tag = "counterclockwise";
            }
            gos.Add (go);
        }

        cyl_parent.GetComponent<rotate>().SPAWN_pivot(gos.ElementAt(0));

        //move effect initial
        if (failure_counter == 0)
        {
            cyl_parent.transform.SetParent(gos.ElementAt(0).transform, true);
        }

        //UnityEngine.Debug.Log(gos.ElementAt(0).transform.position);
        cyl_parent.transform.eulerAngles =
            new Vector3(cyl_parent.transform.eulerAngles.x,
                cyl_parent.transform.eulerAngles.y,
                0);
        cyl_parent.GetComponent<rotate>().stop();
    }

    public game_mode gamemode;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine
            .Debug
            .Log("slope is:::::" +
            Vector2.SignedAngle(new Vector2(0, 1), new Vector2(1, 2)));
        UnityEngine
            .Debug
            .Log("slope is:::::" +
            Vector2.SignedAngle(new Vector2(0, 1), new Vector2(1, -2)));
        UnityEngine
            .Debug
            .Log("slope is:::::" +
            Vector2.SignedAngle(new Vector2(0, 1), new Vector2(-2, -1)));
        UnityEngine
            .Debug
            .Log("slope is:::::" +
            Vector2.SignedAngle(new Vector2(0, 1), new Vector2(-1, 2)));

        // UnityEngine.Debug.Log("test slope="+Helper.PointsGetSlopeCloseness(new Vector2(0,0),new Vector2(1,0),new Vector2(0,1)));
        failure_counter = 0;
        current_order = 0;
        PlayerPrefs.SetInt("temp_lvl_num", 1);
        goto_last_lvl();
    }

    // Update is called once per frame
}
