using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;

public class Touch_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		
    }
  public void draw_cross(Vector3 v3)
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

	
        var offset = v3;
        var x = 2*4;
        var y = 2*7;
        lineRenderer
            .SetPosition(0, new Vector3(0 + offset.x, 0 + offset.y, 0.0f));
        lineRenderer
            .SetPosition(1, new Vector3(x + offset.x, 0 + offset.y, 0.0f));
        lineRenderer
            .SetPosition(2, new Vector3(-x + offset.x, 0 + offset.y, 0.0f));
        lineRenderer
            .SetPosition(3, new Vector3(0 + offset.x, 0 + offset.y, 0.0f));
        lineRenderer
            .SetPosition(4, new Vector3(0 + offset.x,y + offset.y, 0.0f));
        lineRenderer
            .SetPosition(5, new Vector3(0 + offset.x, -y + offset.y, 0.0f));
        lineRenderer
            .SetPosition(6, new Vector3(0 + offset.x, 0 + offset.y, 0.0f));
    
    }
    bool dragging = false;

    Vector3 drag_pos = Vector3.zero;

    

    void Update()
    {
        switch (Camera.main.GetComponent<game1_manager>().gamemode)
        {
            case game_mode.millCreataion_orderise:
            case game_mode.millCreataion_inaccessible_pivots:
                {
                    if (
                        Input.GetMouseButton(0) &&
                        !dragging &&
                        GameObject
                            .FindGameObjectsWithTag("cylinderparent")[0]
                            .GetComponent<rotate>()
                            .stopped
                    )
                    {
                        UnityEngine.Debug.Log("started");

                        dragging = true;
                        drag_pos = Input.mousePosition;
                    }
                    if (
                        Input.GetMouseButton(0) &&
                        dragging &&
                        GameObject
                            .FindGameObjectsWithTag("cylinderparent")[0]
                            .GetComponent<rotate>()
                            .stopped
                    )
                    //rotation phase
                    {
                        UnityEngine.Debug.Log("updown");

                        var mill =
                            GameObject
                                .FindGameObjectsWithTag("cylinderparent")[0];

                        var currpos = Input.mousePosition;
                        var amount = (currpos.y - drag_pos.y > 0) ? 1f : -1f;
                        mill.transform.eulerAngles =
                            new Vector3(mill.transform.eulerAngles.x,
                                mill.transform.eulerAngles.y,
                                mill.transform.eulerAngles.z + .3f * amount);
                    }
                    if (
                        Input.GetMouseButtonUp(0) &&
                        dragging &&
                        GameObject
                            .FindGameObjectsWithTag("cylinderparent")[0]
                            .GetComponent<rotate>()
                            .stopped
                    )
                    {
                        UnityEngine.Debug.Log("release");

                        dragging = false;
                        drag_pos = Vector3.zero;
                    }
                    break;
                }
            case game_mode.pivotCreation_orderise:
            case game_mode.pivotCreation_inaccessible_pivots:
                {
				



					//set cross single touch
					
                    if (
                        Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)
                    )
					{
						var Mousepos=Input.mousePosition;
						var Wpos=Camera.main.ScreenToWorldPoint(Mousepos);
						draw_cross(new Vector3(Wpos.x,Wpos.y,0));
					}
                    break;
                }
        }
    }
}
