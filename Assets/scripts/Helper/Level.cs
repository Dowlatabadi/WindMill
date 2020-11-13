using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LinePoint;
using UnityEngine;

namespace Classes
{
    public enum game_mode
    {
        millCreataion,
        pivotCreation
    }

    public enum Pivot_type
    {
        ClockWise = 1,
        CounterClockWise = -1
    }

    public class Level
    {
        public game_mode gamemode { get; set; }

        public List<(
                Vector2 pivot_pos,
                Pivot_type pivot_type,
                bool labeled,
                int order_num
            )
        >
        Pivots { get; set; }

        public string Info { get; set; }

        public int Known_pivots { get; set; }

        public Level(
            game_mode game_mode,
            List<(
                    Vector2 pivot_pos,
                    Pivot_type pivot_type,
                    bool labeled,
                    int order_num
                )
            >
            Pivots,
            string Info,
            int Known_pivots
        )
        {
            this.gamemode = game_mode;
            this.Pivots = Pivots;
            this.Info = Info;
            this.Known_pivots = Known_pivots;
        }

        public Level(
            game_mode game_mode,
            int number_of_C,
            int number_of_CC,
            float label_portion
        )
        {
            var total_points = number_of_C + number_of_CC;
            var labeled_number = (int)(total_points * label_portion);
            List<int> indexes = Enumerable.Range(0, total_points).ToList();
            List<int> Labeled_indexes =
                indexes
                    .OrderBy(x => UnityEngine.Random.value)
                    .Take(labeled_number)
                    .ToList();
            UnityEngine.Debug.Log("labeled ones====" + labeled_number);
            UnityEngine.Debug.Log(String.Join(",", Labeled_indexes));
            List<int> C_indexes =
                indexes
                    .OrderBy(x => UnityEngine.Random.value)
                    .Take(number_of_C)
                    .ToList();

            var res =
                new List<(
                        Vector2 pivot_pos,
                        Pivot_type pivot_type,
                        bool labeled
                    )
                >();

            List<Vector2> pivots_pos = new List<Vector2>();
            for (int i = 0; i < total_points; i++)
            {
                (
                    Vector2 pivot_pos,
                    Pivot_type pivot_type,
                    bool labeled
                ) cur_tuple;
                var point_pos =
                    Helper
                        .find_next_point(res.Select(x => x.pivot_pos).ToList(),
                        5f,
                        20f);
                cur_tuple.pivot_pos = point_pos;

                //rotation
                if (C_indexes.Contains(i))
                    cur_tuple.pivot_type = Pivot_type.ClockWise;
                else
                    cur_tuple.pivot_type = Pivot_type.CounterClockWise;

                if (Labeled_indexes.Contains(i))
                {
                    cur_tuple.labeled = true;
                }
                else
                {
                    cur_tuple.labeled = false;
                }
                res.Add (cur_tuple);
            }
            UnityEngine.Debug.Log("before orderise pivots: " + res.Count());

            // var result = FakeOrderise(res);
            var result = Orderise(res);
            UnityEngine.Debug.Log("After orderise pivots: " + result.Count());

            Pivots = result;
            this.Known_pivots = labeled_number;
            this.gamemode = game_mode;
        }

        //sets the order num for all pivots
        private List<(
                Vector2 pivot_pos,
                Pivot_type pivot_type,
                bool labeled,
                int order_num
            )
        >
        FakeOrderise(
            List<(Vector2 pivot_pos, Pivot_type pivot_type, bool labeled)> input
        )
        {
            return input
                .Select(x => (x.pivot_pos, x.pivot_type, x.labeled, -1000))
                .ToList();
        }
 private List<(
                Vector2 pivot_pos,
                Pivot_type pivot_type,
                bool labeled,
                int order_num
            )
        >
        Orderise(
            List<(Vector2 pivot_pos, Pivot_type pivot_type, bool labeled)> input
        )
        {
            UnityEngine
                .Debug
                .Log("input labelds1:============= " +
                input.Where(x => x.labeled).Count());

            var res =
                new List<(
                        Vector2 pivot_pos,
                        Pivot_type pivot_type,
                        bool labeled,
                        int order_num
                    )
                >();
            var tot = input.Count();
            var next_index = UnityEngine.Random.Range(0, tot);
            var total_steps = Mathf.Min(10, tot);
            var l1 = new Vector2(0, 1);
            int i = 1;
            List<int> seen = new List<int>();
            res
                .Add((
                    input[next_index].pivot_pos,
                    input[next_index].pivot_type,
                    input[next_index].labeled,
                    i
                ));

            //todo
            seen.Add (next_index);
            var Clocksign = (int) input[next_index].pivot_type;
            while (i < total_steps)
            {
                i++;

                var prev_point = input[next_index].pivot_pos;
                next_index =
                    next_order(input.Select(x => x.pivot_pos).ToList(),
                    next_index,
                    Clocksign,
                    l1);
                l1 = -input[next_index].pivot_pos + prev_point;

                Clocksign = (int) input[next_index].pivot_type;
                if (seen.Contains(next_index)) break;

                //todo
                seen.Add (next_index);

                res
                    .Add((
                        input[next_index].pivot_pos,
                        input[next_index].pivot_type,
                        input[next_index].labeled,
                        i
                    ));
                // UnityEngine.Debug.Log("next index: " + next_index);
            }
            var debug_labeleds = 0;
            for (int j = 0; j < tot; j++)
            {
                if (input[j].labeled)
                {
                    debug_labeleds++;
                }
                if (seen.Contains(j)) continue;
                res
                    .Add((
                        input[j].pivot_pos,
                        input[j].pivot_type,
                        input[j].labeled,
                        -1000
                    ));
            }

            // UnityEngine.Debug.Log("final labelds:============= " + debug_labeleds);
            //may cause some mistakes in future
            return res;
        }

        private int
        next_order(
            List<Vector2> positions,
            int start_index,
            int Clocksign,
            Vector2 l1
        )
        {
            //Clocksign=-Clocksign;
            l1 = new Vector2(l1.x , l1.y );
            var min_diff = 1f;

            var res = -180;
            for (int i = 0; i < positions.Count(); i++)
            {
                if (i == start_index) continue;

                //order of point 1 and 2 is important==direction of line
				var mapped_and_maybe_reflected= -positions[start_index] + positions[i];
			if (Vector2.SignedAngle(l1,mapped_and_maybe_reflected)*Clocksign<0)
			mapped_and_maybe_reflected=new Vector2(-mapped_and_maybe_reflected.x,-mapped_and_maybe_reflected.y);
                var AngelBetween =
                    Vector2
                        .SignedAngle(l1,
                       mapped_and_maybe_reflected);
UnityEngine.Debug.Log("new ang: "+AngelBetween);
                if (
                    AngelBetween != 0 &&
                    AngelBetween != 180 &&
                    AngelBetween != -180
                )
                {
                    if (/*AngelBetween * min_diff> 0 && */ Math.Abs(AngelBetween) > Math.Abs(min_diff)){
res=i;
min_diff=AngelBetween;
					}
                    // {
                    //     UnityEngine
                    //         .Debug
                    //         .Log($" same signs and {AngelBetween} > {min_diff}");
                    //     res = i;
                    //     min_diff = AngelBetween;
                    // }
                    // else if (AngelBetween * min_diff < 0 && AngelBetween < 0)
                    // {
                    //     UnityEngine
                    //         .Debug
                    //         .Log($" different signs and {AngelBetween} is better than {min_diff}");
                    //     res = i;
                    //     min_diff = AngelBetween;
                    // }
                }
            }
            UnityEngine
                .Debug
                .Log($"center is {start_index} and chosen diff is: " +
                min_diff.ToString() +
                " whose index is: " +
                res);
            return res;
        }
    }
}
