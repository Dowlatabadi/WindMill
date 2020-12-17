using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

using System.Diagnostics;
using System.Linq;
using Classes;
using LinePoint;
using TMPro;
using UnityEngine;

public class creator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void get_coordinations(){

var all_pvts= 
            GameObject
                .FindGameObjectsWithTag("clockwise")
                .Union(GameObject.FindGameObjectsWithTag("counterclockwise"));
var gen=$"new List<(int x,int y)>{{{System.String.Join(",", all_pvts.Select(tt=>Helper.get_grid_pos(new Vector2(tt.transform.position.x,tt.transform.position.y))).Select(pv=>$"({pv.y},{pv.x})"))}}}.Select(t=>(t.x,t.y,true)).ToList()";
			UnityEngine.Debug.Log
			(gen)
			;
 GUIUtility.systemCopyBuffer = gen;

}
    // Update is called once per frame
    void Update()
    {
        
    }
}
