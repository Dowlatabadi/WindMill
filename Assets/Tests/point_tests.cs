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
		public void unlock_40(){
			 PlayerPrefs.SetInt("Progress_lvl", 70);
		}
    }
}
