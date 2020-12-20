using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Classes;

public class Selection_Manager : MonoBehaviour
{
    public Vector3 op_left_pos;

    public GameObject bar_prefab;

    public GameObject Container;

    public bool debug_mode;

    // Start is called before the first frame update
    void Start()
    {
        if (debug_mode)
        {
            //unlock
            PlayerPrefs.SetInt("Progress_lvl", 74);
        }
        RectTransform rt = (RectTransform) bar_prefab.transform;
        float width = rt.rect.width * 2;
        float height = rt.rect.height * 2;
        Debug.Log (width);
        int counter = 0;
        foreach (var info in Levels_Data.levels_info)
        {
            var x = (counter % 3) * width + op_left_pos.x;
            var y = -(int)(counter / 3) * height + op_left_pos.y;
//            Debug.Log (x);

            //instantiate
            var go = GameObject.Instantiate(bar_prefab, Container.transform);
            ((RectTransform) go.transform).anchoredPosition =
                new Vector3(x, y, 0);

            //set lvl info
            var node = go.GetComponent<Level_Node_Structure>();
                       
          	node.lvl_num = info.lvl_num;
            node.c = info.c;
            node.cc = info.cc;
            node.ratio = info.labeled_ratio;
            node.gamemode = info.gamemode;
            node.draw_info();

            counter++;
        }
        var last_lvl =
            Camera.main.GetComponent<save_manager>().get_progress_lvl();
        var all = GameObject.FindGameObjectsWithTag("SelectionBar");

        //deactive_locked
        foreach (var go in all)
        {
			//colorise rectangle
			if (go.GetComponent<Level_Node_Structure>().gamemode==game_mode.millCreataion_inaccessible_pivots ||go.GetComponent<Level_Node_Structure>().gamemode==game_mode.millCreataion_orderise ){
go
                    .transform
                    .GetChild(8)
                    .gameObject
					 .GetComponent<Image>()
                    .color = new Color32(255,0,0,40);
			}
			else{
				go
                    .transform
                    .GetChild(8)
                    .gameObject
					 .GetComponent<Image>()
                    .color = new Color32(67,191,171,100);
			}
            if (go.GetComponent<Level_Node_Structure>().lvl_num > last_lvl)
            {
                //disable button
                go.GetComponent<Button>().interactable = false;
                gray(go, 0);
                gray(go, 1);
                gray(go, 2);
                gray(go, 3);
                gray(go, 4);

                //show lock
                go
                    .transform
                    .GetChild(7)
                    .gameObject
                    .GetComponent<Image>()
                    .enabled = true;
            }
        }

        //scroll to last play lvl
        var last_seen = 0;
        if (PlayerPrefs.HasKey("temp_lvl_num"))
        {
            last_seen = PlayerPrefs.GetInt("temp_lvl_num");
            Debug.Log("found last " + last_seen);
        }
        var scroll_height = ((int)(last_seen / 3)) * 160 - 3225;
        var container_rt = Container.GetComponent<RectTransform>();
        container_rt.anchoredPosition =
            new Vector2(container_rt.anchoredPosition.x, scroll_height);
//        Debug.Log("scroll " + scroll_height);
    }

    void gray(GameObject go, int child_num)
    {
        go
            .transform
            .GetChild(child_num)
            .gameObject
            .GetComponent<TextMeshProUGUI>()
            .color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
