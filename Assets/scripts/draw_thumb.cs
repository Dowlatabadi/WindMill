using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class draw_thumb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		screen= transform.Find("Screen");
    }
Transform screen;
    public GameObject simple_point;

    public void Draw(
        List<(int x, int y, bool centerised)> points,
        float hardness,
        int c,
        int cc
    )
    {

		//pre calcl
		 var precision = 10;

        //starting bottom left
        var rows = 32 * precision;
        var columns = 16 * precision;
        var width = transform.Find("Screen").GetComponent<RectTransform>().rect.width;
        var height = transform.Find("Screen").GetComponent<RectTransform>().rect.height;
        var width_unit = width / columns;
        var height_unit = height / rows;
        var left_bottom =
            new Vector2(this.transform.position.x - width / 2,
                this.transform.position.y - height / 2);
		//////
        int i = 0;
		
        foreach (var p1 in points)
        {
            i++;
            var p1_go =
                GameObject
                    .Instantiate(simple_point,
                    Vector3.zero,
                    Quaternion.identity,transform.Find("Screen")
                   );
            if (i <= c)
            {
                p1_go.GetComponent<Image>().color = Color.red;
            }
            else
            {
                p1_go.GetComponent<Image>().color = Color.blue;
            }
            p1_go.transform.localPosition = map_scr(p1.x, p1.y, p1.centerised,width_unit,height_unit,left_bottom);
            //UnityEngine.Debug.Log($"position {map_scr(p1.x, p1.y,p1.centerised)}");
        }
        transform.Find("header").GetComponent<Image>().color =
            new Color32((byte)(hardness * 255),
                0,
                (byte)((1 - hardness) * 255),
                20);
    }

    Vector3 map_scr(int row_num, int col_num, bool centerised,float width_unit,float height_unit,Vector2 left_bottom)
    {
       
        if (centerised)
        {
            var temp =
                new Vector2((col_num - 1) * width_unit + width_unit / 2,
                    (row_num - 1) * height_unit + height_unit / 2);
            UnityEngine.Debug.Log($"screen1 {temp}");

            return temp + left_bottom;
        }
        else
        {
            var random_x_off = UnityEngine.Random.Range(0f, width_unit);
            var random_y_off = UnityEngine.Random.Range(0f, height_unit);
            var temp =
                new Vector2((col_num - 1) * width_unit + random_x_off,
                    (row_num - 1) * height_unit + random_y_off);
            UnityEngine.Debug.Log($"screen {temp}");

            return temp + left_bottom;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
