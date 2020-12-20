using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace LinePoint
{
    public class Line
    {
        public float m_slope { get; set; }

        public float b { get; set; }
    }

    public static class Helper
    {
        public static float
        PointsGetSlopeCloseness(Vector2 point, Vector2 point1, Vector2 point2)
        {
            var line1 = Helper.GetLine(point1, point);
            var line2 = Helper.GetLine(point2, point);
            var actualline = Helper.GetLine(point1, point2);

            //         UnityEngine.Debug.Log("line1"+line1.m_slope );
            //         UnityEngine.Debug.Log("actual"+actualline.m_slope );
            // UnityEngine.Debug.Log((line1.m_slope - actualline.m_slope)/(1f+line1.m_slope *actualline.m_slope));
            var angle1 =
                Mathf
                    .Atan((line1.m_slope - actualline.m_slope) /
                    (1f + line1.m_slope * actualline.m_slope));

            return Mathf.Abs((angle1 * 180) / Mathf.PI);
        }

        public static float LinesAngelBetween(Line line1, Line l2)
        {
            var angle1 =
                Mathf
                    .Atan((l2.m_slope - line1.m_slope) /
                    (1f + l2.m_slope * line1.m_slope));

            return ((angle1 * 180) / Mathf.PI);
        }
public static float FindNearestPointOnLine(Vector2 origin, Vector2 direction, Vector2 point)
{
    var prj_mg=Vector3.Project(new Vector3((point-origin).x,(point-origin).y,0),new Vector3(direction.x,direction.y,0)).magnitude;
		//	UnityEngine.Debug.Log($"<color=blue>prj is {prj_mg} </color>");

var vatar=(point-origin).magnitude;

    
    return Mathf.Sqrt(vatar*vatar-prj_mg*prj_mg);
}
        public static float LinePointGetDist(Vector2 point, Line line)
        {
            var b1 = point.y + (point.x / line.m_slope);

            //UnityEngine.Debug.Log(b1);
            var x_collisionPoint =
                (b1 - line.b) / (line.m_slope + (1 / line.m_slope));
            var y_colltionPoint = line.m_slope * x_collisionPoint + line.b;
            return Vector2
                .Distance(new Vector2(x_collisionPoint, y_colltionPoint),
                point);
        }

        public static float
        TriDist(Vector2 point, Vector2 point1, Vector2 point2)
        {
            //UnityEngine.Debug.Log(b1);
            var d1 = Vector2.Distance(point, point1);
            var d2 = Vector2.Distance(point, point2);
            return Mathf.Min(d1, d2);
        }

        public static Line GetLine(Vector2 point1, Vector2 point2)
        {
            var slope =
                (float)(point1.y - point2.y) / (float)(point1.x - point2.x);
            if (point1.x - point2.x == 0) slope = 10000f;
            return new Line {
                m_slope = slope,
                b = point1.y - (slope * point1.x)
            };
        }

        public static Vector2
        find_next_point(List<Vector2> points, float min_dist, float min_slope)
        {
            var min_margin = .01f;
            List<(Vector2, float, float, float)> result_points =
                new List<(Vector2, float, float, float)>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            float distance = 0;
            float margin = 0f;
            float Slope_diff = 0;
            var x = UnityEngine.Random.Range(-2f, 2f);
            var y =  UnityEngine.Random.Range(-4f, 4f);
            var point = new Vector2(x, y);
            if (points.Count() == 0)
            {
                return point;
            }
            if (points.Count() == 1)
            {
                while (distance < min_dist || margin < min_margin)
                {
                    x = UnityEngine.Random.Range(-1.5f, 1.5f);
                    y = UnityEngine.Random.Range(-3.5f, 3.5f);
                    point = new Vector2(x, y);
                    distance = Vector2.Distance(points[0], point);
                    margin = Mathf.Abs(point.x - points[0].x);
                }

                return point;
            }

            bool is_ok = false;
            int try1 = 0;
            bool timeOut = false;
            while (distance < min_dist ||
                Slope_diff < min_slope ||
                margin < min_margin
            )
            {
                try1++;
                if (stopWatch.ElapsedMilliseconds > 100)
                {
                    // UnityEngine.Debug.Log("timeout failed");
                    timeOut = true;
                    break;
                }
                x = UnityEngine.Random.Range(-1.5f, 1.5f);
                y = UnityEngine.Random.Range(-3.5f, 3.5f);
                point = new Vector2(x, y);
                is_ok = true;

                List<(float, float, float)> so_far_worst =
                    new List<(float, float, float)>();
                for (int i = 0; i < points.Count(); i++)
                {
                    //if (is_ok == false) break;
                    for (int j = 0; j < points.Count(); j++)
                    {
                        if (i == j) continue;

                        var point1 = points.ElementAt(i);
                        var point2 = points.ElementAt(j);
                        var line = Helper.GetLine(point1, point2);
                        distance = Helper.TriDist(point, point1, point2);
                        margin =
                            Mathf
                                .Min(Mathf.Abs(point.x - point1.x),
                                Mathf.Abs(point.x - point2.x));
                        Slope_diff =
                            Helper
                                .PointsGetSlopeCloseness(point, point1, point2);
                        if (
                            distance < min_dist ||
                            Slope_diff < min_slope ||
                            margin < min_margin
                        )
                        {
                            so_far_worst.Add((distance, Slope_diff, margin));
                            is_ok = false;
                            // break;
                        }
                        else
                        {
                            // UnityEngine.Debug.Log(Slope_diff + "passed");
                        }
                    }
                }
                if (!is_ok)
                {
                    var worst =
                        so_far_worst
                            .OrderBy(w =>
                                w.Item1 * w.Item1 +
                                w.Item2 +
                                (
                                50 * /*factor of margin*/
                                (w.Item3)
                                ))
                            .First();
                    result_points
                        .Add((point, worst.Item1, worst.Item2, worst.Item3));
                }
            }

            // UnityEngine.Debug.Log($"{Slope_diff}>{min_slope}" + "slope");
            // UnityEngine.Debug.Log($"{distance}>{min_dist}" + "dist");
            // UnityEngine.Debug.Log("try1=" + try1);
            var chosen = new Vector2(0, 0);
            if (timeOut)
            {
                chosen =
                    result_points
                        .OrderByDescending(yy =>
                            yy.Item2 * yy.Item2 + yy.Item3 + (50 * (yy.Item4)))
                        .First()
                        .Item1;
            }
            else
            {
                chosen = point;
            }
            return chosen;
        }
 public static Vector2
        get_grid_pos(Vector2 input)
        {
			var precision=10;
            //starting bottom left
            var rows = 32*precision;
            var columns = 16*precision;
            var screen_width = Screen.width;
            var screen_height = Screen.height;
			var left_bottom=Camera.main.ScreenToWorldPoint(new Vector2(-screen_width/2,-screen_height/2));
			var top_right=Camera.main.ScreenToWorldPoint(new Vector2(screen_width/2,screen_height/2));

			var width = top_right.x-left_bottom.x;
            var height = top_right.y-left_bottom.y;
            float width_unit = width / columns;
            float height_unit = height / rows;
//UnityEngine.Debug.Log($"left bottom {left_bottom}");
            
                return new Vector2((int)((input.x-left_bottom.x)/width_unit-80),(int)((input.y-left_bottom.y)/height_unit-160));
            
        }
        public static Vector2
        get_squared_pos(int row_num, int col_num, bool centerised = true)
        {
			var precision=10;
            //starting bottom left
            var rows = 32*precision;
            var columns = 16*precision;
            var width = Screen.width;
            var height = Screen.height;
            var width_unit = width / columns;
            var height_unit = height / rows;

            if (centerised)
            {
                var temp =
                    new Vector2((col_num - 1) * width_unit + width_unit / 2,
                        (row_num - 1) * height_unit + height_unit / 2);
                return Camera.main.ScreenToWorldPoint(temp);
            }
            else
            {
                var random_x_off = UnityEngine.Random.Range(0f, width_unit);
                var random_y_off = UnityEngine.Random.Range(0f, height_unit);
                var temp =
                    new Vector2((col_num - 1) * width_unit + random_x_off,
                        (row_num - 1) * height_unit + random_y_off);
                return Camera.main.ScreenToWorldPoint(temp);
            }
        }
public static List<(int x, int y)>
        plus_points(this List<(int x, int y)> firstpoints, List<(int x, int y)> secondpoints)
		{
firstpoints.AddRange(secondpoints);
return firstpoints;
		}

		public static List<(int x, int y)>
       add_offset(this List<(int x, int y)> firstpoints, (int x,int y) offset)
		{

return firstpoints.Select<(int x, int y), (int x, int y)>(t=>(t.x+offset.x,t.y+offset.y)).ToList();
		}
        public static List<(int x, int y)>
        get_asymetric_poses(int start_angle, int point_number,float scale_factor=6f,float y_scale=1)
        {
			
			var precision=10;
			(int x,int y) offset=((8+1)*precision,16*precision);
            var scale = scale_factor*precision; //from 8;
            var result = new List<(int x, int y)>();
            var angle_share = 360 / point_number;
            var next_angle = start_angle;
//            UnityEngine.Debug.Log($"angle share is {angle_share}");

            for (int i = 0; i < point_number; i++)
            {
          
                var x = (int) Mathf.Round(Mathf.Cos(next_angle* (Mathf.PI / 180) ) * scale)+offset.x;
                var y = (int) (Mathf.Round(Mathf.Sin(next_angle* (Mathf.PI / 180) ) * scale*y_scale)+offset.y);
                result.Add((y,x));
//            UnityEngine.Debug.Log($"for angle {next_angle} generated {i}::: ({x}, {y}), sin(-180) {Mathf.Sin(-180* Mathf.PI)}");
                next_angle = (next_angle + angle_share) ;
            }
            return result;
        }


		 public static List<(int x, int y)>
        get_arc_poses(int start_angle, int point_number,int angle_share,float scale_factor=6f,float y_scale=1)
        {
			
			var precision=10;
			(int x,int y) offset=((8+1)*precision,16*precision);
            var scale = scale_factor*precision; //from 8;
            var result = new List<(int x, int y)>();
           // var angle_share = 360 / point_number;
            var next_angle = start_angle;
     //       UnityEngine.Debug.Log($"angle share is {angle_share}");

            for (int i = 0; i < point_number; i++)
            {
          
                var x = (int) Mathf.Round(Mathf.Cos(next_angle* (Mathf.PI / 180) ) * scale)+offset.x;
                var y = (int) (Mathf.Round(Mathf.Sin(next_angle* (Mathf.PI / 180) ) * scale*y_scale)+offset.y);
                result.Add((y,x));
//            UnityEngine.Debug.Log($"for angle {next_angle} generated {i}::: ({x}, {y}), sin(-180) {Mathf.Sin(-180* Mathf.PI)}");
                next_angle = (next_angle + angle_share) ;
            }
            return result;
        }


		public static (GameObject next_go,float angle_dist) 
        next_order(
            IEnumerable<GameObject> pvt_gos,
            GameObject start_go,
            int Clocksign,
            Vector2 l1
        )
        {
			//Clocksign=-Clocksign;
            l1 = new Vector2(l1.x, l1.y);
            var min_diff = 1f;

            var res = (start_go,180f);
            foreach (var go in pvt_gos)
            {
                if (GameObject.ReferenceEquals( start_go, go)) continue;

                //order of point 1 and 2 is important==direction of line
                var mapped_and_maybe_reflected =
                    -new Vector2(start_go.transform.position.x,start_go.transform.position.y) + new Vector2(go.transform.position.x,go.transform.position.y);
                if (
                    Vector2.SignedAngle(l1, mapped_and_maybe_reflected) *
                    Clocksign <
                    0
                )
                    mapped_and_maybe_reflected =
                        new Vector2(-mapped_and_maybe_reflected.x,
                            -mapped_and_maybe_reflected.y);
                var AngelBetween =
                    Vector2.SignedAngle(l1, mapped_and_maybe_reflected);
                // UnityEngine.Debug.Log("new ang: " + AngelBetween);
                if (
                    AngelBetween != 0 &&
                    AngelBetween != 180 &&
                    AngelBetween != -180
                )
                {
                    if (
                        /*AngelBetween * min_diff> 0 && */
                        Math.Abs(AngelBetween) > Math.Abs(min_diff)
                    )
                    {
                        // UnityEngine
                        //     .Debug
                        //     .Log($"correct condition: {Math.Abs(AngelBetween)} > {Math.Abs(min_diff)}");

                        min_diff = AngelBetween;
                        res = (go,Math.Abs(min_diff));
                    }
                }
                // else if(AngelBetween == 0){
                // 			res = i;
                // 			min_diff = AngelBetween;
                // }
            }
           
            return res;
        }
    }
}
