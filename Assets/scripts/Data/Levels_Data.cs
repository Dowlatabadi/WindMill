using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

public static class Levels_Data 
{
public static List<(int lvl_num,int c,int cc,float labeled_ratio ,game_mode gamemode, string welcome_info, string end_info)> levels_info=
new List<(int lvl_num, int c, int cc, float labeled_ratio, game_mode gamemode, string welcome_info, string end_info)>(){
(1,3,0,.5f,game_mode.pivotCreation_orderise,"This is the first level.\n ","This is the first level.\n "),
(2,2,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the second level.\n ","This is the second level.\n "),
(3,3,1,.5f,game_mode.millCreataion_orderise,"This is the third level.\n ","This is the third level.\n "),
(4,5,1,.5f,game_mode.pivotCreation_orderise,"This is the forth level.\n ","This is the forth level.\n "),
(5,6,1,.5f,game_mode.millCreataion_orderise,"This is the fifth level.\n ","This is the forth level.\n "),
(6,7,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the sixth level.\n ","This is the forth level.\n "),
(7,1,1,.5f,game_mode.pivotCreation_orderise,"This is the Seventh level.\n ","This is the forth level.\n "),
(8,1,1,.5f,game_mode.millCreataion_orderise,"This is the eightth level.\n ","This is the forth level.\n "),
(9,1,1,.5f,game_mode.pivotCreation_orderise,"This is the ninth level.\n ","This is the forth level.\n "),
(10,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 10th level.\n ","This is the forth level.\n "),
(11,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 11th level.\n ","This is the forth level.\n "),
(12,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 12th level.\n ","This is the forth level.\n "),
(13,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 13th level.\n ","This is the forth level.\n "),
(14,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 14th level.\n ","This is the forth level.\n "),
(15,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 15th level.\n ","This is the forth level.\n "),
(16,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 16th level.\n ","This is the forth level.\n "),
(17,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 17th level.\n ","This is the forth level.\n "),
(18,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 18th level.\n ","This is the forth level.\n "),
(19,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 19th level.\n ","This is the forth level.\n "),
(20,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 20th level.\n ","This is the forth level.\n "),
(21,1,1,.5f,game_mode.millCreataion_inaccessible_pivots,"This is the 21th level.\n ","This is the forth level.\n "),



};
}
