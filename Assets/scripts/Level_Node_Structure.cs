﻿using System.Collections;
using System.Collections.Generic;
using Classes;
using TMPro;
using UnityEngine;

public class Level_Node_Structure : MonoBehaviour
{
    public int lvl_num;

    // Start is called before the first frame update
    public int cc;

    public int c;

    public game_mode gamemode;

    public float ratio;

    public void go_lvl()
    {
        Camera
            .main
            .GetComponent<Scene_manager>()
            .Scene_Playground_LevelParameters(lvl_num);
    }

    void Start()
    {
    }

    public void draw_info()
    {
        Transform firstChild_lvl_bold = transform.GetChild(0);
		 firstChild_lvl_bold.gameObject.GetComponent<TextMeshProUGUI>().text =$"Lvl {lvl_num}";


        Transform Child_details = transform.GetChild(1);
        Child_details.gameObject.GetComponent<TextMeshProUGUI>().text =
            $"C {c}\nCC {cc}\n{translate(gamemode)}";
    }

    public static string translate(game_mode gm)
    {
        switch (gm)
        {
            case game_mode.millCreataion_orderise:
                return "Order\nM";
                break;
            case game_mode.pivotCreation_orderise:
                return "Order\nP";

                break;
            case game_mode.millCreataion_inaccessible_pivots:
                return "Infinite Go\nM";

                break;
            default:
            case game_mode.pivotCreation_inaccessible_pivots:
                return "Infinite Go\nP";

                break;
        }
    }
}