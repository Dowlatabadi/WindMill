using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Selection_Manager : MonoBehaviour
{
    public Vector3 op_left_pos;

    public GameObject bar_prefab;

    public GameObject Container;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rt = (RectTransform) bar_prefab.transform;
        float width = rt.rect.width*2;
        float height = rt.rect.height*2;
		Debug.Log(width);
        int counter = 0;
        foreach (var info in Levels_Data.levels_info)
        {
            var x = (counter % 3) * width + op_left_pos.x;
            var y = -(int)(counter / 3) * height + op_left_pos.y;
		Debug.Log(x);

            //instantiate
            var go = GameObject.Instantiate(bar_prefab, Container.transform);
            ((RectTransform)go.transform).anchoredPosition  = new Vector3(x, y, 0);

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
            if (go.GetComponent<Level_Node_Structure>().lvl_num >last_lvl)
            {
                //disable button
                go.GetComponent<Button>().interactable = false;
                go
                    .transform
                    .GetChild(0)
                    .gameObject
                    .GetComponent<TextMeshProUGUI>()
                    .color = Color.gray;
                go
                    .transform
                    .GetChild(1)
                    .gameObject
                    .GetComponent<TextMeshProUGUI>()
                    .color = Color.gray;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
