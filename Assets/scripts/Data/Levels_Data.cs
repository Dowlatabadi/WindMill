using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;
using LinePoint;
using System.Linq;


public static class Levels_Data 
{
public static List<(int lvl_num,int c,int cc,float labeled_ratio ,game_mode gamemode, string welcome_info, string end_info,List<(int x, int y, bool centerised)> predefined_locations ,int finish_delay,Vector2 start_vct)> levels_info=
new List<(int lvl_num, int c, int cc, float labeled_ratio, game_mode gamemode, string welcome_info, string end_info,List<(int x, int y, bool centerised)> predefined_locations ,int finish_delay,Vector2 start_vct)>(){
(1,1,0,0f,game_mode.millCreataion_orderise,
"This is the first level and only a show of about the simple logic which this game is working based on.\n The logic is simple; The mill would rotate around its primary pivot.",
"empty",
new List<(int x, int y, bool centerised)>(){
	(160,90,true),
	

},
1,
new Vector2(1,2)
//Helper.get_asymetric_poses(0,4).Select(t=>(t.x,t.y,true)).ToList()//triangle
),
(2,2,0,1f,game_mode.millCreataion_orderise,
"Let's see what happens when mill meets another pivot\n ",
"Well, as you saw new touched pivot will be the primary pivot.\n The mill only can have one primary pivot at a time, therefor the old one is not primary anymore.",
// new List<(int x, int y, bool centerised)>(){
// 	(12,4,true),
// 	(28,8,true),
// 	(16,16,true),
// }
Helper.get_asymetric_poses(95,2,8).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(-1,2)

),
(3,3,0,.35f,game_mode.millCreataion_orderise,
"You need to find start pivot which would form the provided order.\nTouch and choose which pivot is your choose to start from. ",
"Well done! you got the basic idea.",
Helper.get_asymetric_poses(65,3).Select(t=>(t.x,t.y,true)).ToList(),3,
new Vector2(0,1)

),
(4,3,0,.35f,game_mode.millCreataion_orderise,
"You always can change mill starting angle by draggin in vertical axis.\nTouch and choose which pivot is your choose to start from and then change starting angle if needed. ",
"Great! you can imagine what would happen.",
Helper.get_asymetric_poses(65,3).Select(t=>(t.x,t.y,true)).ToList(),3,
new Vector2(1,0)

),
(5,4,0,.5f,game_mode.millCreataion_orderise,
"You always can change mill starting angle by draggin in vertical axis.\n ","empty",
Helper.get_asymetric_poses(75,4,6,1.5f).Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(-1,-2)

),

(6,7,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the sixth level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),
(7,1,3,.5f,game_mode.pivotCreation_orderise,
"This is the Seventh level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),
(8,1,3,.5f,game_mode.millCreataion_orderise,
"This is the eightth level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),
(9,1,3,.5f,game_mode.pivotCreation_orderise,
"This is the ninth level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),
(10,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 10th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(11,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 11th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(12,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 12th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(13,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 13th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(14,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 14th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(15,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 15th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(16,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 16th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(17,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 17th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(18,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 18th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(19,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 19th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(20,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 20th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),

(21,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 21th level.\n ","This is the forth level.\n ",
null,3,
new Vector2(0,1)

),





};
}
