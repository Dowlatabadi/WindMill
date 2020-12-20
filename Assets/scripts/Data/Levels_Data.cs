using System.Collections;
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
"This game is based on a simple logic; The mill would rotate around its primary pivot.\n press Start button to run.",
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
"Well, as you saw new touched pivot will be the primary pivot.\n The mill only can have one primary pivot at a time, therefore the old one is not primary anymore.",
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
"In puzzles you need to find start pivot which would form the provided order (n should be met as the nth pivot)\n-Touch to choose which pivot is your chosen pivot to start from(1st pivot).\n-You always can drag up/down to change mill starting angle ",
"Well done! you got the basic idea.",
Helper.get_asymetric_poses(70,3).Select(t=>(t.x,t.y,true)).ToList(),3,
new Vector2(1,0),
0
,
"Lvl 1. Order guess"
),

(4,10,0,1f,game_mode.millCreataion_inaccessible_pivots,
"Remember the mill should never meet green points ","empty",
(Helper.get_asymetric_poses(30,4,8f))
.plus_points(Helper.get_asymetric_poses(30,3,4f))
.plus_points(Helper.get_asymetric_poses(10,3,2f))
.add_offset((0,0))


.Select(t=>(t.x,t.y,true)).ToList(),
0,
new Vector2(0,-1),
0
,
"Lvl 2. touch guess"
),

(5,5,0,.4f,game_mode.millCreataion_orderise,
"Sometimes to solve the order puzzle you can think in reverse rotation to guess the order...\n ","empty",
Helper.get_asymetric_poses(75,5,6,1.2f).Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(0,1),
2
,
"Lvl 3."
),
(6,5,0,.5f,game_mode.millCreataion_orderise,
"As you saw the when needed mill slows down to show collisions properly.\n ","empty",
new List<(int x, int y)>(){
	(100,90),
	(120,130),
	(200,60),
	(230,90),
	(240,30),
	

}
.add_offset((0,10))

.Select(t=>(t.x,t.y,true)).ToList()
,3,
new Vector2(-2,10),
2
,
"Lvl 4."
),



(7,5,0,.5f,game_mode.millCreataion_orderise,
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
"Lvl 5."
),


(8,5,0,.5f,game_mode.millCreataion_orderise,
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

(9,5,0,.5f,game_mode.millCreataion_orderise,
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



(10,6,0,.5f,game_mode.millCreataion_orderise,
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
(11,6,0,.5f,game_mode.millCreataion_orderise,
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



(12,12,0,.5f,game_mode.millCreataion_orderise,
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
(13,8,0,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(90,2,10.5f))
.plus_points(Helper.get_asymetric_poses(55,2,3f))
.plus_points(Helper.get_asymetric_poses(70,2,5.5f))
.plus_points(Helper.get_asymetric_poses(80,2,8f))
// .plus_points(Helper.get_asymetric_poses(50,2,2.5f))


.Select(t=>(t.x,t.y,true)).ToList(),
1,
new Vector2(1,-1),
0
,
""
),

(14,0,7,.5f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rotate counter clockwise! ","empty",
Helper.get_asymetric_poses(95,6,6)
.plus_points(new List<(int,int)>(){(160,90)})
.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(1,-1),
0
,
""
),

(15,2,4,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(180,2,6).plus_points(Helper.get_asymetric_poses(45,4,6))).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(1,-1),
0
,
""
),
(16,1,3,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(268,56),(152,46),(71,86),(215,107)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,-3),
3
,
""
),
(17,3,2,.5f,game_mode.millCreataion_orderise,
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
(18,4,1,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(88,126),(162,117),(166,40),(255,118),(190,103)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,-3),
3
,
""
),

(19,0,6,.5f,game_mode.millCreataion_orderise,
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
(20,3,1,1f,game_mode.millCreataion_inaccessible_pivots,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	
	(320-80,60,true),
	(320-80,120,true),
	(320-220,90,true),
	(320-130,90,true),
	
	


},
5,
new Vector2(2,-1),
0
,
""
),

(21,4,4,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(180,4,3).plus_points(Helper.get_asymetric_poses(45,4,8))).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(1,-1),
0
,
""
),

(22,3,3,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(101,136),(184,48),(215,115),(64,57),(171,58),(259,92)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,0),
3
,
""
),
(23,1,5,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",

(new List<(int x,int y)>(){(160,90)})
.plus_points(Helper.get_arc_poses(-40,5,30,5f))
.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(3,2),
8
,
""
),
(24,1,7,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(new List<(int x,int y)>(){(190,90)})
.plus_points(Helper.get_asymetric_poses(0,7,7f))
.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,1),
8
,
""
),
(25,3,3,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(172,40),(210,97),(61,103),(127,51),(244,38),(260,105)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(-1,-3),
3
,
""
),
(26,5,2,1f,game_mode.millCreataion_orderise,
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

(27,0,10,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",

// (new List<(int x,int y)>(){(170,70),(150,100)})
Helper.get_arc_poses(0,1,36,2f)
.plus_points(Helper.get_arc_poses(36*1,1,36,4f))
.plus_points(Helper.get_arc_poses(36*2,1,36,5f))
.plus_points(Helper.get_arc_poses(36*3,1,36,5.5f))
.plus_points(Helper.get_arc_poses(36*4,1,36,6f))
.plus_points(Helper.get_arc_poses(36*5,1,36,6.5f))
.plus_points(Helper.get_arc_poses(36*6,1,36,7f))
.plus_points(Helper.get_arc_poses(36*7,1,36,7.5f))
.plus_points(Helper.get_arc_poses(36*8,1,36,8f))
.plus_points(Helper.get_arc_poses(36*9,1,36,8.5f))
.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(2,-2),
5
,
""
),
(28,4,2,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(67,71),(121,114),(142,38),(57,83),(238,96),(164,66)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,-3),
3
,
""
),

(29,14,0,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",

// (new List<(int x,int y)>(){(170,70),(150,100)})
Helper.get_arc_poses(-45,7,15,9f).add_offset((0,-100))
.plus_points(Helper.get_arc_poses(-45,7,15,9f).add_offset((0,-70)))

.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(0.1f,1),
2
,
""
),

(30,5,5,1f,game_mode.millCreataion_inaccessible_pivots,
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
(31,1,4,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(251,27),(134,66),(53,49),(67,104),(150,42)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,4),
3
,
""
),
(32,5,5,.3f,game_mode.millCreataion_orderise,
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
(33,8,1,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(107,151),(107,33),(168,95),(218,70),(274,117),(217,118),(165,41),(165,142),(275,72)}.Select(t=>(t.x,t.y,true)).ToList()

,
5,
new Vector2(3,2),
8
,
""
),


(34,1,4,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(274,93),(73,53),(152,108),(270,46),(256,109)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,4),
3
,
""
),
(35,2,8,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",

(new List<(int x,int y)>(){(170,70),(150,100)})
.plus_points(Helper.get_arc_poses(0,4,30,7f))
.plus_points(Helper.get_arc_poses(180,4,30,7f))
.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(3,2),
8
,
""
),

(36,4,4,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(225,4,4.5f).plus_points(Helper.get_asymetric_poses(180,4,8))).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(3,-1),
0
,
""
),

(37,7,3,.3f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x, int y, bool centerised)>(){
	
	(320-160,60,true),
	(320-80,60,true),
	(320-120,55,true),
	(320-200,55,true),
	(320-240,60,true),
	(320-100,125,true),
	(320-180,125,true),
	

	(320-60,120,true),
	(320-140,120,true),
	(320-220,120,true),


},
40,
new Vector2(1,3),
0
,
""
),
(38,1,4,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(217,132),(130,64),(66,73),(189,100),(247,53)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,-3),
3
,
""
),




(39,6,2,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
(Helper.get_asymetric_poses(30,6,6.5f).plus_points(Helper.get_asymetric_poses(0,2,7.5f))).Select(t=>(t.x,t.y,true)).ToList(),
3,
new Vector2(-3,3),
0
,
""
),


(40,3,3,.5f,game_mode.millCreataion_orderise,
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


(41,3,2,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(243,40),(110,68),(215,115),(202,44),(53,69)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,4),
3
,
""
),



(42,1,5,.5f,game_mode.millCreataion_orderise,
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

(43,5,2,1f,game_mode.millCreataion_orderise,
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




(44,7,7,.6f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",

// (new List<(int x,int y)>(){(170,70),(150,100)})
Helper.get_arc_poses(-45,7,15,9f).add_offset((0,-100))
.plus_points(Helper.get_arc_poses(135,7,15,9f).add_offset((0,100)))

.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(2,-2),
5
,
""
),



(45,7,10,.6f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",

// (new List<(int x,int y)>(){(170,70),(150,100)})
Helper.get_arc_poses(-45,7,15,9f).add_offset((0,-100))
.plus_points(Helper.get_arc_poses(135,7,15,9f).add_offset((0,100)))
.plus_points(Helper.get_arc_poses(70,3,20,9f).add_offset((20,0)))

.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(-2,-2),
2
,
""
),

(46,5,1,.4f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
new List<(int x,int y)>{(67,29),(252,112),(120,84),(50,114),(212,82),(120,45)}.Select(t=>(t.x,t.y,true)).ToList()
,
5,
new Vector2(1,-3),
3
,
""
),

(47,9,6,1f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
Helper.get_asymetric_poses(160,9,6f).add_offset((40,0))
.plus_points(Helper.get_arc_poses(180,6,40,4f).add_offset((-40,0)))
.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(1,5),
0
,
""
),
(48,9,1,1f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
Helper.get_asymetric_poses(160,9,6f).add_offset((40,0))
.plus_points(Helper.get_arc_poses(270,1,40,6f).add_offset((-40,0)))
.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(1,5),
0
,
""
),


(49,9,2,1f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
Helper.get_asymetric_poses(160,9,5f).add_offset((0,0))
.plus_points(Helper.get_arc_poses(270,1,40,8f))
.plus_points(Helper.get_arc_poses(40,1,40,8f))
.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(1,5),
0
,
""
),
(50,7,4,1f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",

Helper.get_arc_poses(270,7,30,6f).add_offset((30,0))
.plus_points(Helper.get_arc_poses(150,4,30,4f).add_offset((-70,0)))
.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(1,5),
6
,
""
),
(51,9,1,.3f,game_mode.millCreataion_orderise,
"Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
Helper.get_arc_poses(252,2,36,6f)
.plus_points(Helper.get_arc_poses(0,7,36,6f))
.plus_points(Helper.get_arc_poses(-36,1,36,6f))
.Select(t=>(t.x,t.y,true)).ToList(),
5,
new Vector2(0,5),
6
,
""
),
// (32,1,3,1f,game_mode.pivotCreation_orderise,
// "Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
// new List<(int x,int y)>{ (220,132),(321,138),(313,200),(212,118) }
// .Select(t=>(t.x-160,t.y-80,true)).ToList(),

// 5,
// new Vector2(1,0),
// 0
// ,
// ""
// )
// ,

// (42,5,0,1f,game_mode.pivotCreation_orderise,
// "Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
// new List<(int x, int y, bool centerised)>(){
// 		(100,90,true),
// 	(120,130,true),
// 	(200,60,true),
// 	(230,90,true),
// 	(240,30,true),
// }
// ,3,
// new Vector2(-1,20),
// 0
// ,
// ""
// ),

// (43,4,0,1f,game_mode.pivotCreation_orderise,
// "Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
// new List<(int x, int y, bool centerised)>(){
// 		(240,40,true),
// 	(240,120,true),
// 	(80,80,true),
// 	(120,70,true),

// }
// ,3,
// new Vector2(3,-20),
// 3
// ,
// ""
// ),

// (44,4,0,1f,game_mode.pivotCreation_orderise,
// "Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
// new List<(int x, int y, bool centerised)>(){
// 		(240,40,true),
// 	(70,120,true),
// 	(260,70,true),
// 	(240,100,true),

// }
// ,3,
// new Vector2(1,-.2f),
// 2
// ,
// ""
// ),

// (45,5,0,1f,game_mode.pivotCreation_orderise,
// "Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
// new List<(int x, int y, bool centerised)>(){
// 		(70,80,true),
// 	(95,30,true),
// 	(80,110,true),
// 	(70,150,true),
// 	(240,110,true),

// }
// ,3,
// new Vector2(-4,3),
// 4
// ,
// ""
// ),
// (46,7,0,.6f,game_mode.pivotCreation_orderise,
// "Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
// new List<(int x, int y, bool centerised)>(){
// 	(160-64,64,true),
// 	(160,32-16,true),
// 	(160+64,64,true),
// 	(160+50,80+16,true),
// 	(165,105+10,true),
// 	(160-64,128+16,true),
// 	(160+64,128+16,true),

// }
// ,3,
// new Vector2(2,1),
// 4
// ,
// ""
// ),
// (47,5,0,1f,game_mode.pivotCreation_orderise,
// "Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
// new List<(int x, int y, bool centerised)>(){
// 		(100,90,true),
// 	(120,130,true),
// 	(200,60,true),
// 	(230,90,true),
// 	(240,30,true),
// }
// ,3,
// new Vector2(-1,20),
// 0
// ,
// ""
// ),

// (48,4,0,1f,game_mode.pivotCreation_orderise,
// "Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
// new List<(int x, int y, bool centerised)>(){
// 		(240,40,true),
// 	(240,120,true),
// 	(80,80,true),
// 	(120,70,true),

// }
// ,3,
// new Vector2(3,-20),
// 3
// ,
// ""
// ),

// (49,4,0,1f,game_mode.pivotCreation_orderise,
// "Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
// new List<(int x, int y, bool centerised)>(){
// 		(240,40,true),
// 	(70,120,true),
// 	(260,70,true),
// 	(240,100,true),

// }
// ,3,
// new Vector2(1,-.2f),
// 2
// ,
// ""
// ),

// (50,5,0,1f,game_mode.pivotCreation_orderise,
// "Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
// new List<(int x, int y, bool centerised)>(){
// 		(70,80,true),
// 	(95,30,true),
// 	(80,110,true),
// 	(70,150,true),
// 	(240,110,true),

// }
// ,3,
// new Vector2(-4,3),
// 4
// ,
// ""
// ),
// (51,7,0,.6f,game_mode.pivotCreation_orderise,
// "Mode of the current level is pivot creation.\n In this mode you need to create a pivot in a certain area which would cause the order happen.\n Simply choose your desired location to pivot spawn on. ","This was the 16 level.\n ",
// new List<(int x, int y, bool centerised)>(){
// 	(160-64,64,true),
// 	(160,32-16,true),
// 	(160+64,64,true),
// 	(160+50,80+16,true),
// 	(165,105+10,true),
// 	(160-64,128+16,true),
// 	(160+64,128+16,true),

// }
// ,3,
// new Vector2(2,1),
// 4
// ,
// ""
// ),

// (52,3,4,1f,game_mode.pivotCreation_inaccessible_pivots,
// "Did you ever ask yourself why all the time mill rotates clockwise?\n Well, it is not a must at all, the blue pivots cause mill rottae counter clockwise! ","This is the forth level.\n ",
// new List<(int x,int y)>{(207,77),(51,117),(84,58),(213,106),(255,38),(127,53),(260,113)}.Select(t=>(t.x,t.y,true)).ToList(),
// 5,
// new Vector2(1,0),
// 3
// ,
// ""
// )
// ,

};
}
