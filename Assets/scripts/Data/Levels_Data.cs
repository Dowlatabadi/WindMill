﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;
using LinePoint;
using System.Linq;


public static class Levels_Data 
{
public static List<(int lvl_num,int c,int cc,float labeled_ratio ,game_mode gamemode, string welcome_info, string end_info,List<(int x, int y, bool centerised)> predefined_locations ,int finish_delay,Vector2 start_vct,int pivot_creation_answer,string header_text)> levels_info=
new List<(int lvl_num, int c, int cc, float labeled_ratio, game_mode gamemode, string welcome_info, string end_info,List<(int x, int y, bool centerised)> predefined_locations ,int finish_delay,Vector2 start_vct,int pivot_creation_answer,string header_text)>(){
(1,1,0,0f,game_mode.millCreataion_orderise,
"This is the first level and only a show of about the simple logic which this game is working based on.\n The logic is simple; The mill would rotate around its primary pivot.",
"empty",
new List<(int x, int y, bool centerised)>(){
	(160,90,true),
	

},
1,
new Vector2(1,2),
0,
"Intro."
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
new Vector2(-1,2),
0
,
"Intro.."
),
(3,3,0,.35f,game_mode.millCreataion_orderise,
"You need to find start pivot which would form the provided order.\nTouch and choose which pivot is your choose to start from. ",
"Well done! you got the basic idea.",
Helper.get_asymetric_poses(65,3).Select(t=>(t.x,t.y,true)).ToList(),3,
new Vector2(0,1),
0
,
"Lvl 1. Order guess"
),
(4,3,0,.35f,game_mode.millCreataion_orderise,
"You always can change mill starting angle by draggin in vertical axis.\nTouch and choose which pivot is your choose to start from and then change starting angle if needed. ",
"Great! you can imagine what would happen.",
Helper.get_asymetric_poses(65,3).Select(t=>(t.x,t.y,true)).ToList(),3,
new Vector2(1,0),
0
,
"Lvl 2. Varible Angles"
),
(5,4,0,.5f,game_mode.millCreataion_orderise,
"You always can change mill starting angle by draggin in vertical axis.\n ","empty",
Helper.get_asymetric_poses(75,4,6,1.5f).Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(-1,-2),
0
,
"Lvl 3. "
),

(6,5,0,.4f,game_mode.millCreataion_orderise,
"This is the sixth level.\n ","This is the forth level.\n ",
Helper.get_asymetric_poses(75,5,6,1.5f).Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(0,1),
0
,
"Lvl 4."
),
(7,5,0,.5f,game_mode.millCreataion_orderise,
"This is the 10th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(100,90,true),
	(120,130,true),
	(200,60,true),
	(230,90,true),
	(240,30,true),
	

}
,3,
new Vector2(-2,10),
0
,
"Lvl 5."
),
(8,5,0,.6f,game_mode.millCreataion_orderise,
"This is the sixth level.\n ","This is the forth level.\n ",
Helper.get_asymetric_poses(85,5,6,1.5f).Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(-3,-2),
0
,
""
),
(9,6,0,.5f,game_mode.millCreataion_orderise,
"This is the sixth level.\n ","This is the forth level.\n ",
Helper.get_asymetric_poses(20,6,6,1.5f).Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(-1,-3),
0
,
"Lvl 6."
),



(10,5,0,.5f,game_mode.millCreataion_orderise,
"This is the 12th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(170,110,true),
	(90,150,true),
	(90,30,true),
	(170,70,true),
	(260,90,true),
}
,3,
new Vector2(6,-1),
0
,
"Lvl 7."
),

(11,5,0,.5f,game_mode.millCreataion_orderise,
"This is the 12th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(80,150,true),
	(90,110,true),
	(90,30,true),
	(80,70,true),
	(260,90,true),
}
,3,
new Vector2(6,-1),
0
,
"Lvl 8."
),

(12,6,0,.5f,game_mode.millCreataion_orderise,
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
new Vector2(1,0),
0
,
""
),

(13,5,0,.5f,game_mode.millCreataion_orderise,
"This is the 12th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(200,85,true),
	(250,103,true),
	(270,95,true),
	(140,110,true),
	(70,88,true),
	
}
,3,
new Vector2(.2f,1),
0
,
""
),

(14,6,0,.5f,game_mode.millCreataion_orderise,
"This is the 12th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	(135,90,true),
	(65,25,true),
	(135,25,true),
	(220,90,true),
	(220,155,true),
	
	(280,155,true),
	
}
,3,
new Vector2(-.2f,1),
0
,
""
),


(15,5,0,1f,game_mode.pivotCreation_orderise,
"Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
new List<(int x, int y, bool centerised)>(){
		(100,90,true),
	(120,130,true),
	(200,60,true),
	(230,90,true),
	(240,30,true),
}
,3,
new Vector2(-1,20),
0
,
""
),

(16,4,0,1f,game_mode.pivotCreation_orderise,
"Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
new List<(int x, int y, bool centerised)>(){
		(240,40,true),
	(240,120,true),
	(80,80,true),
	(120,70,true),

}
,3,
new Vector2(3,-20),
3
,
""
),

(17,4,0,1f,game_mode.pivotCreation_orderise,
"Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
new List<(int x, int y, bool centerised)>(){
		(240,40,true),
	(70,120,true),
	(260,70,true),
	(240,100,true),

}
,3,
new Vector2(1,-.2f),
2
,
""
),

(18,5,0,1f,game_mode.pivotCreation_orderise,
"Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
new List<(int x, int y, bool centerised)>(){
		(70,80,true),
	(95,30,true),
	(80,110,true),
	(70,150,true),
	(240,110,true),

}
,3,
new Vector2(-4,3),
4
,
""
),
(19,7,0,.6f,game_mode.pivotCreation_orderise,
"Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
new List<(int x, int y, bool centerised)>(){
	(160-64,64,true),
	(160,32-16,true),
	(160+64,64,true),
	(160+50,80+16,true),
	(165,105+10,true),
	(160-64,128+16,true),
	(160+64,128+16,true),

}
,3,
new Vector2(2,1),
4
,
""
),
(20,12,0,.5f,game_mode.millCreataion_orderise,
"This is the 21th level.\n ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	
	(60,40,true),
	(96,40,true),
	(132,40,true),
	(168,40,true),
	(204,40,true),

	(240,40,true),


	(260,60,true),
	(260,80,true),
	(260,100,true),
	(260,120,true),
	(260,140,true),


	(60,140,true),

}
,3,
new Vector2(.2f,4),
0
,
""
),

(21,0,3,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
Helper.get_asymetric_poses(95,3,6).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(1,-1),
0
,
""
),

(22,0,5,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
Helper.get_asymetric_poses(100,5,6).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(1,-1),
0
,
""
),

(23,2,4,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(180,2,6).plus_points(Helper.get_asymetric_poses(45,4,6))).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(1,-1),
0
,
""
),
(24,4,4,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(180,4,3).plus_points(Helper.get_asymetric_poses(45,4,8))).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(1,-1),
0
,
""
),
(25,4,4,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(225,4,4.5f).plus_points(Helper.get_asymetric_poses(180,4,8))).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(3,-1),
0
,
""
),
(26,6,2,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(30,6,6.5f).plus_points(Helper.get_asymetric_poses(0,2,7.5f))).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(-3,3),
0
,
""
),

(27,4,5,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	
	(320-70,50,true),
	(320-110,50,true),
	(320-150,50,true),
	(320-190,50,true),
	

	(320-50,110,true),
	(320-90,115,true),
	(320-130,110,true),
	(320-170,115,true),
	(320-210,110,true),


},
20,
new Vector2(6,2),
0
,
""
),
(28,5,5,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	
	(320-80,60,true),
	(320-120,55,true),
	(320-160,60,true),
	(320-200,55,true),
	(320-240,60,true),
	

	(320-60,120,true),
	(320-100,125,true),
	(320-140,120,true),
	(320-180,125,true),
	(320-220,120,true),


},
40,
new Vector2(6,2),
0
,
""
),



(29,3,2,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	
	(320-80,110,true),
	(320-80,70,true),
	(320-220,90,true),
	
	(320-240,50,true),
	(320-240,130,true),


},
40,
new Vector2(1,-1),
0
,
""
),


(30,3,1,1f,game_mode.millCreataion_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	
	(320-80,70,true),
	(320-80,110,true),
	(320-220,90,true),
	(320-100,90,true),
	
	


},
5,
new Vector2(2,-1),
0
,
""
),



(31,6,0,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(30,5,6.5f).plus_points(new List<(int,int)>(){(160,90)}).Select(t=>(t.x,t.y,true))).ToList(),
5,
new Vector2(0,1),
0
,
""
),



(32,10,0,0f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(30,9,6.5f).plus_points(new List<(int,int)>(){(160,90)}).Select(t=>(t.x,t.y,true))).ToList(),
5,
new Vector2(0,1),
0
,
""
),


(33,1,9,0f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(new List<(int,int)>(){(160,90)}).plus_points(Helper.get_asymetric_poses(30,9,6.5f)).Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(0,1),
0
,
""
),



(34,8,0,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(90,2,10.5f))
.plus_points(Helper.get_asymetric_poses(55,2,3f))
.plus_points(Helper.get_asymetric_poses(70,2,5.5f))
.plus_points(Helper.get_asymetric_poses(80,2,8f))
// .plus_points(Helper.get_asymetric_poses(50,2,2.5f))


.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(1,-1),
0
,
""
),




(35,3,3,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(55,3,4f))
.plus_points(Helper.get_asymetric_poses(30,3,8f))



.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(0,1),
0
,
""
),


(36,0,6,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(50,3,6f))
.plus_points(Helper.get_asymetric_poses(30,3,8f))



.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(0,1),
0
,
""
),
(37,6,0,1f,game_mode.millCreataion_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(50,3,8f))
.plus_points(Helper.get_asymetric_poses(30,3,4f))



.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(1,0),
0
,
""
)
,
(38,2,0,1f,game_mode.millCreataion_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(0,2,8f))
.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(1,0),
0
,
""
)
,
(39,1,3,1f,game_mode.pivotCreation_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{ (220,132),(321,138),(313,200),(212,118) }
.Select(t=>(t.x-160,t.y-80,true)).ToList(),

5,
new Vector2(1,0),
0
,
""
)
,
(40,1,5,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(135,118),(157,60),(131,38),(250,102),(75,71),(250,40)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,0),
0
,
""
)
,
(41,5,2,1f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(154,118),(219,67),(263,114),(253,47),(134,99),(73,75),(56,44)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,0),
0
,
""
)

,
(42,5,2,1f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(39,82),(84,37),(195,79),(171,103),(96,64),(102,108),(57,118)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,0),
0
,
""
)
,
(43,3,1,1f,game_mode.millCreataion_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(184,40),(163,52),(241,93),(67,79)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,0),
0
,
""
)
,
(44,4,1,1f,game_mode.millCreataion_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(107,78),(172,38),(85,88),(174,97),(236,75)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,0),
0
,
""
)
,
(45,1,7,1f,game_mode.millCreataion_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(160,33),(140,117),(133,53),(161,82),(249,121),(83,56),(82,91),(250,54)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,0),
0
,
""
)
,
(46,5,3,1f,game_mode.millCreataion_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(185,25),(141,91),(84,48),(215,112),(250,87),(51,57),(92,117),(235,51)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,0),
0
,
""
)
,
(47,5,5,1f,game_mode.millCreataion_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(184,109),(223,73),(221,103),(268,42),(262,65),(65,88),(48,69),(73,65),(163,45),(170,38)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,0),
0
,
""
)
,
(48,10,0,1f,game_mode.millCreataion_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(39,60),(262,41),(271,89),(224,121),(56,109),(237,94),(181,64),(186,59),(110,94),(211,58)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,0),
0
,
""
)
,
(49,3,4,1f,game_mode.pivotCreation_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(207,77),(51,117),(84,58),(213,106),(255,38),(127,53),(260,113)}.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(1,0),
3
,
""
)
,
(50,3,4,1f,game_mode.pivotCreation_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
null
,
5,
new Vector2(1,0),
3
,
""
)
};
}
