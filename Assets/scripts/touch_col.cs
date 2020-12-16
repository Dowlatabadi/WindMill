using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;
public class touch_col : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit =
                Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null && hit.collider.transform == this.transform
            )
            {
				var gamemode = Camera.main.GetComponent<game1_manager>().gamemode;
        var AccessModeGame =
            (
            gamemode == game_mode.pivotCreation_inaccessible_pivots ||
            gamemode == game_mode.millCreataion_inaccessible_pivots
            );
                if (
                    !gameObject.GetComponentInParent<pivotActions>().labled ||
                    (
                    gameObject.GetComponentInParent<pivotActions>().labled &&
                    (gameObject
                        .GetComponentInParent<pivotActions>()
                        .get_my_num() ==
                    1 || (gameObject
                        .GetComponentInParent<pivotActions>()
                        .get_my_num() !=999 && AccessModeGame))
                    )
                )
                {
                    var cyl_parent =
                        GameObject.FindGameObjectsWithTag("cylinderparent")[0];
                    cyl_parent
                        .GetComponent<rotate>()
                        .set_pivot(this.transform.parent.gameObject, false);
                    cyl_parent.transform.eulerAngles =
                        new Vector3(cyl_parent.transform.eulerAngles.x,
                            cyl_parent.transform.eulerAngles.y,
                            0);
                    // raycast hit this gameobject}
                }
            }
			else {
//close if showing dialogue
		
		// Camera.main.GetComponent<DialogueManager>().unshow_dialogues();


			}
        }
    }
}
