using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Classes;
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
			
			//Debug.Log("should fire");
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
			var gamemode=Camera.main.GetComponent<game1_manager>().gamemode;
			var blind_game=(gamemode == game_mode.millCreataion_inaccessible_pivots ||
            gamemode == game_mode.pivotCreation_inaccessible_pivots);;
			//var screen_pos=Camera.main.WorldToScreenPoint(pvt.transform.position);
			var fx_go=GameObject
                        .Instantiate(flash_go,Vector3.zero,Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform);
			 var rectTransform =fx_go.gameObject.GetComponent<RectTransform>();
		var screen_pos=Camera.main.WorldToScreenPoint(pvt.transform.position);
			rectTransform.position=new Vector2(screen_pos.x,screen_pos.y);
			if (pvt.GetComponent<pivotActions>().labled && !blind_game){
 fx_go.GetComponent<Image>().color=new Color32(0,255,0,48);
			}
			else if (pvt.tag=="clockwise"){

			 fx_go.GetComponent<Image>().color=new Color32(231,42,37,48);
			}
			else{
			 fx_go.GetComponent<Image>().color=new Color32(0,0,255,48);

			}
		//	Debug.Log($"<color=red>{screen_pos}</color>");
			//fx_go.GetComponent<RectTransform>().anchoredPosition=new Vector2(screen_pos.x,screen_pos.y);
		}
	}


    // Update is called once per frame
    void Update()
    {
    }
}
