using System.Collections;
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


        Transform c_obj = transform.GetChild(1);
		c_obj.gameObject.GetComponent<TextMeshProUGUI>().text =$"{c}";
        Transform cc_obj = transform.GetChild(2);
		cc_obj.gameObject.GetComponent<TextMeshProUGUI>().text =$"{cc}";

        Transform order_type = transform.GetChild(3);
		order_type.gameObject.GetComponent<TextMeshProUGUI>().text =$"{translate(gamemode).order_type}";

        Transform creation = transform.GetChild(4);
		creation.gameObject.GetComponent<TextMeshProUGUI>().text =$"{translate(gamemode).creation_type}";

        
    }

    public static (string order_type,string creation_type) translate(game_mode gm)
    {
        switch (gm)
        {
            case game_mode.millCreataion_orderise:
                return ("1 2 3","----");
                break;
            case game_mode.pivotCreation_orderise:
                return ("1 2 3","+");

                break;
            case game_mode.millCreataion_inaccessible_pivots:
                return ("∞","----");

                break;
            default:
            case game_mode.pivotCreation_inaccessible_pivots:
                return ("∞","+");

                break;
        }
    }
}
