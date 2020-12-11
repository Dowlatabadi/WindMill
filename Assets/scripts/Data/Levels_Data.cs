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

(6,5,0,.4f,game_mode.millCreataion_orderise,
"This is the sixth level.\n ","This is the forth level.\n ",
Helper.get_asymetric_poses(75,5,6,1.5f).Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(0,1)

),
(7,5,0,.7f,game_mode.millCreataion_orderise,
"This is the sixth level.\n ","This is the forth level.\n ",
Helper.get_asymetric_poses(75,5,6,1.5f).Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(1,1)

),
(8,5,0,.6f,game_mode.millCreataion_orderise,
"This is the sixth level.\n ","This is the forth level.\n ",
Helper.get_asymetric_poses(85,5,6,1.5f).Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(-3,-2)

),
(9,6,0,.5f,game_mode.millCreataion_orderise,
"This is the sixth level.\n ","This is the forth level.\n ",
Helper.get_asymetric_poses(20,6,6,1.5f).Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(-1,-3)

),
(10,5,0,.5f,game_mode.millCreataion_orderise,
"This is the 10th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(100,90,true),
	(120,130,true),
	(200,60,true),
	(230,90,true),
	(240,30,true),
	

}
,3,
new Vector2(-2,10)

),

(11,5,0,.5f,game_mode.millCreataion_orderise,
"This is the 10th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(100,130,true),
	(100,50,true),
	(140,130,true),
	(140,50,true),
	(250,90,true),
	

}
,3,
new Vector2(-2,10)

),

(12,5,0,.5f,game_mode.millCreataion_orderise,
"This is the 12th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(170,110,true),
	(90,150,true),
	(90,30,true),
	(170,70,true),
	(260,90,true),
}
,3,
new Vector2(6,-1)

),

(13,5,0,.5f,game_mode.millCreataion_orderise,
"This is the 12th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(80,150,true),
	(90,110,true),
	(90,30,true),
	(80,70,true),
	(260,90,true),
}
,3,
new Vector2(6,-1)

),

(14,6,0,.5f,game_mode.millCreataion_orderise,
"This is the 12th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(250,30,true),
	(120,80,true),
	(60,80,true),
	(220,100,true),
	(280,100,true),
	(90,150,true),
}
,3,
new Vector2(1,0)

),

(15,5,0,.5f,game_mode.millCreataion_orderise,
"This is the 12th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(260,102,true),
	(280,97,true),
	(220,97,true),
	(160,102,true),
	(80,97,true),
	
}
,3,
new Vector2(1,0)

),

(16,5,0,.5f,game_mode.millCreataion_orderise,
"Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
new List<(int x, int y, bool centerised)>(){
	(260,102,true),
	(280,97,true),
	(220,97,true),
	(160,102,true),
	(80,97,true),
	
}
,3,
new Vector2(1,0)

),

(17,5,0,1f,game_mode.pivotCreation_orderise,
"Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
new List<(int x, int y, bool centerised)>(){
		(100,90,true),
	(120,130,true),
	(200,60,true),
	(230,90,true),
	(240,30,true),
}
,3,
new Vector2(-1,20)

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
