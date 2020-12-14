using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class effect_mananger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public GameObject flash_go;

    public void flash_blue(GameObject pivot)
    {
		instantiate_in_all_pivots();
		var gos=GameObject.FindGameObjectsWithTag("flash_go");
		foreach (var flash_go in gos){
			 
			Debug.Log("should fire");
        flash_go.GetComponent<Animator>().SetBool("should_flash", true);
		}
       
    }
	void instantiate_in_all_pivots(){
		 var all_pivots =
            GameObject
                .FindGameObjectsWithTag("clockwise")
                .Union(GameObject.FindGameObjectsWithTag("counterclockwise"));
		
		foreach (var pvt in all_pivots)
		{
			//var screen_pos=Camera.main.WorldToScreenPoint(pvt.transform.position);
			var fx_go=GameObject
                        .Instantiate(flash_go,Vector3.zero,Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform);
			 var rectTransform =fx_go.gameObject.GetComponent<RectTransform>();
		var screen_pos=Camera.main.WorldToScreenPoint(pvt.transform.position);
			rectTransform.position=new Vector2(screen_pos.x,screen_pos.y);
			Debug.Log($"<color=red>{screen_pos}</color>");
			//fx_go.GetComponent<RectTransform>().anchoredPosition=new Vector2(screen_pos.x,screen_pos.y);
		}
	}


    // Update is called once per frame
    void Update()
    {
    }
}
