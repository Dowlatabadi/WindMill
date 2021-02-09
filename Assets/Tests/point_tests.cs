using System.Collections;
using System.Collections.Generic;
using LinePoint;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;
using Classes;


namespace Tests
{
    public class point_tests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void point_testsSimplePasses()
        {
            var points = Helper.get_asymetric_poses(0, 2).Select(t=>(t.x,t.y,true)).ToList();

            //Assert.AreEqual(x,0);
            //Assert.IsTrue(points.Count == 2);

			// new Level(game_mode.pivotCreation_orderise,
            //         2,
            //         2,
            //         .5f,
            //         "sddsds",
            //         "dffdd",
            //         points);
        }
		[Test]
		public void delete_prefs(){
			 PlayerPrefs.DeleteAll();
		}
		[Test]
		public void unlock_70(){
			 PlayerPrefs.SetInt("Progress_lvl",1);
		}
		[Test]
		public void helper_point(){
			var x= Helper.get_grid_pos(new Vector2(-2.8f,-5f));
			var y= Helper.get_squared_pos(0,0);
			// UnityEngine.Debug.Log($"<color=blue>the grid is P{x} </color>");
			// Debug.Log($"<color=blue>160,80 P{y} </color>");
		}
		[Test]
		public void test_dist(){
var x=Helper.FindNearestPointOnLine(new Vector2(1,1),new Vector2(1,0),new Vector2(0,0));
			// Debug.Log($"<color=blue>distance is {x} </color>");
			// Debug.Log($"<color=blue>sin(30) {Mathf.Sin(30)} </color>");
	var bet_ang= Vector2.SignedAngle(new Vector2(0,1f),new Vector2(1f,1f));

			Debug.Log($"<color=blue> {bet_ang} </color>");

		}
		[Test]
		public void next_test(){

var go1= new GameObject("go1");
go1.transform.position=new Vector3(0,0,0);
var go2= new GameObject("go2");
go2.transform.position=new Vector3(-1.2f,-5,0);
var go3= new GameObject("go3");
go3.transform.position=new Vector3(1,5,0);
var go4= new GameObject("go4");
go4.transform.position=new Vector3(-1,5,0);

var pvts=new List<GameObject>(){go1,go2,go3,go4};

			var (next_pvt,angle_dist) =Helper.next_order(
            pvts,
            go1,
            1,
            new Vector2(0,-1)
        );
		
			Debug.Log($"<color=blue> {next_pvt.transform.position} </color>");

		}
    }
}
