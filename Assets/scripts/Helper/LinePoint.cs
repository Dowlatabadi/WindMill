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
public static float LinesAngelBetween(Line line1,Line l2){
var angle1 =
                Mathf
                    .Atan((line1.m_slope - l2.m_slope) /
                    (1f + line1.m_slope * l2.m_slope));

            return ((angle1 * 180) / Mathf.PI);
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
            var slope = (float)(point2.y - point1.y) / (float)(point1.x - point2.x);
            if (point1.x - point2.x == 0) slope = 10000f;
            return new Line {
                m_slope = slope,
                b =
                   point1.y-( slope*point1.x )
            };
        }

        public static Vector2
        find_next_point(List<Vector2> points, float min_dist, float min_slope)
        {
            List<(Vector2, float, float)> result_points =
                new List<(Vector2, float, float)>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            float distance = 0;
            float Slope_diff = 0;
            var x = Random.Range(-2f, 2f);
            var y = Random.Range(-4f, 4f);
            var point = new Vector2(x, y);
            if (points.Count() == 0)
            {
                return point;
            }
            if (points.Count() == 1)
            {
                while (distance < min_dist)
                {
                    x = Random.Range(-1.5f, 1.5f);
                    y = Random.Range(-3.5f, 3.5f);
                    point = new Vector2(x, y);
                    distance = Vector2.Distance(points[0], point);
                }

                return point;
            }

            bool is_ok = false;
            int try1 = 0;
            bool timeOut = false;
            while (distance < min_dist || Slope_diff < min_slope)
            {
                try1++;
                if (stopWatch.ElapsedMilliseconds > 300)
                {
                    UnityEngine.Debug.Log("timeout failed");
                    timeOut = true;
                    break;
                }
                x = Random.Range(-1.5f, 1.5f);
                y = Random.Range(-3.5f, 3.5f);
                point = new Vector2(x, y);
                is_ok = true;

                List<(float, float)> so_far_worst = new List<(float, float)>();
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
                        Slope_diff =
                            Helper
                                .PointsGetSlopeCloseness(point, point1, point2);
                        if (distance < min_dist || Slope_diff < min_slope)
                        {
                            so_far_worst.Add((distance, Slope_diff));
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
                    var worst = so_far_worst.OrderBy(w => w.Item1*w.Item1+w.Item2).First();
                    result_points.Add((point, worst.Item1, worst.Item2));
                }
            }
            UnityEngine.Debug.Log($"{Slope_diff}>{min_slope}" + "slope");
            UnityEngine.Debug.Log($"{distance}>{min_dist}" + "dist");
            UnityEngine.Debug.Log("try1=" + try1);
            var chosen = new Vector2(0, 0);
            if (timeOut)
            {
                chosen =
                    result_points
                        .OrderByDescending(yy => yy.Item2*yy.Item2+yy.Item3)
                        .First()
                        .Item1;
            }
            else
            {
                chosen = point;
            }
            return chosen;
        }
    }
}
