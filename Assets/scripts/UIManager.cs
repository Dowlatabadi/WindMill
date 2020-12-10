using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    void Start()
    {
    }

    // Start is called before the first frame update
    void set_ui_elements(bool left_side)
    {
        if (left_side) return;
        var canvas = GameObject.FindGameObjectWithTag("Canvas");
        var width = Screen.width;
        var height = Screen.height;

        foreach (Transform uigo in canvas.transform)
        {
            var rectTransform = uigo.gameObject.GetComponent<RectTransform>();
            if (rectTransform.position.y < height / 2)
                rectTransform.position =
                    new Vector3(width - rectTransform.position.x,
                        rectTransform.position.y,
                        0);
        }
    }

    // Update is called once per frame
    public void AdjustUI()
    {
        var uistr = Camera.main.GetComponent<save_manager>().get_ui_direction();
        if (uistr == "Lefties")
            set_ui_elements(true);
        else
            set_ui_elements(false);
    }
}
