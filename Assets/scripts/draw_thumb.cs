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
            new Vector2(transform.Find("Screen").position.x - width / 2,
                transform.Find("Screen").position.y - height / 2);
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
        }
		Color hard_color=new Color32(0,0,0,0);
		if (hardness<.4f )
		hard_color=new Color32((byte)(255*(1-hardness)),0,0,(byte)(255*(1-hardness)));
		else if (hardness<0.5f)
		hard_color=new Color32((byte)((255*(1-hardness))),0,0,(byte)(255*(1-hardness)));
		else if (hardness<.7f)
		hard_color=new Color32(0,0,(byte)(255*hardness),200);
        transform.Find("header").GetComponent<Image>().color =
          		new Color32((byte)(((float)c/(c+cc))*255),0,(byte)(((float)cc/(c+cc))*255),180);

    }

    Vector3 map_scr(int row_num, int col_num, bool centerised,float width_unit,float height_unit,Vector2 left_bottom)
    {
       
        if (centerised)
        {
            var temp1 =
                new Vector2((col_num - 1) * width_unit + width_unit / 2,
                    (row_num - 1) * height_unit + height_unit / 2);

            return temp1 + left_bottom;
        }
        else
        {
            var random_x_off = UnityEngine.Random.Range(0f, width_unit);
            var random_y_off = UnityEngine.Random.Range(0f, height_unit);
            var temp1 =
                new Vector2((col_num - 1) * width_unit + random_x_off,
                    (row_num - 1) * height_unit + random_y_off);
            // UnityEngine.Debug.Log($"screen {temp1}");

            return temp1 + left_bottom;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
