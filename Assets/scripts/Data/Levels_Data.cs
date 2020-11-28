using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

public static class Levels_Data 
{
public static List<(int lvl_num,int c,int cc,float labeled_ratio ,game_mode gamemode, string welcome_info, string end_info,List<(int x, int y, bool centerised)> predefined_locations )> levels_info=
new List<(int lvl_num, int c, int cc, float labeled_ratio, game_mode gamemode, string welcome_info, string end_info,List<(int x, int y, bool centerised)> predefined_locations )>(){
(1,2,1,.5f,game_mode.pivotCreation_orderise,
"This is the first level. The logic is simple; The mill would rotate around a pivot.\n If the mill meets another pivot, active pivot would switch to newly touched pivot.\n This level is only showing the logic.",
"\nMathematics is a game played according to certain simple rules with meaningless marks on paper. \n\n- David Hilbert.\n ",
new List<(int x, int y, bool centerised)>(){
	(6,4,true),
	(14,6,true),
	(8,8,true),

}
),
(2,2,1,.5f,game_mode.pivotCreation_orderise,
"This is the second level.\n ","This is the second level.\n ",
new List<(int x, int y, bool centerised)>(){
	(6,2,true),
	(14,4,true),
	(8,8,true),
}
),
(3,3,1,.5f,game_mode.millCreataion_orderise,
"This is the third level.\n ","This is the third level.\n ",
null
),
(4,5,1,.5f,game_mode.pivotCreation_orderise,
"This is the forth level.\n ","This is the forth level.\n ",
null
),
(5,6,1,.5f,game_mode.millCreataion_orderise,
"This is the fifth level.\n ","This is the forth level.\n ",
null
),
(6,7,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the sixth level.\n ","This is the forth level.\n ",
null
),
(7,1,1,.5f,game_mode.pivotCreation_orderise,
"This is the Seventh level.\n ","This is the forth level.\n ",
null
),
(8,1,1,.5f,game_mode.millCreataion_orderise,
"This is the eightth level.\n ","This is the forth level.\n ",
null
),
(9,1,1,.5f,game_mode.pivotCreation_orderise,
"This is the ninth level.\n ","This is the forth level.\n ",
null
),
(10,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 10th level.\n ","This is the forth level.\n ",
null
),

(11,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 11th level.\n ","This is the forth level.\n ",
null
),

(12,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 12th level.\n ","This is the forth level.\n ",
null
),

(13,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 13th level.\n ","This is the forth level.\n ",
null
),

(14,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 14th level.\n ","This is the forth level.\n ",
null
),

(15,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 15th level.\n ","This is the forth level.\n ",
null
),

(16,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 16th level.\n ","This is the forth level.\n ",
null
),

(17,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 17th level.\n ","This is the forth level.\n ",
null
),

(18,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 18th level.\n ","This is the forth level.\n ",
null
),

(19,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 19th level.\n ","This is the forth level.\n ",
null
),

(20,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 20th level.\n ","This is the forth level.\n ",
null
),

(21,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,
"This is the 21th level.\n ","This is the forth level.\n ",
null
),





};
}
