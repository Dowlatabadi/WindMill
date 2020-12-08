﻿using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.UI;

public class Touch_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public float aim_higher_offset;

    public void draw_cross(Vector3 v3)
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        var offset = v3 + (new Vector3(0, aim_higher_offset, 0));
        var x = 2 * 4;
        var y = 2 * 7;
        lineRenderer
            .SetPosition(0, new Vector3(0 + offset.x, 0 + offset.y, 0.0f));
        lineRenderer
            .SetPosition(1, new Vector3(x + offset.x, 0 + offset.y, 0.0f));
        lineRenderer
            .SetPosition(2, new Vector3(-x + offset.x, 0 + offset.y, 0.0f));
        lineRenderer
            .SetPosition(3, new Vector3(0 + offset.x, 0 + offset.y, 0.0f));
        lineRenderer
            .SetPosition(4, new Vector3(0 + offset.x, y + offset.y, 0.0f));
        lineRenderer
            .SetPosition(5, new Vector3(0 + offset.x, -y + offset.y, 0.0f));
        lineRenderer
            .SetPosition(6, new Vector3(0 + offset.x, 0 + offset.y, 0.0f));
    }

    bool dragging = false;

    Vector3 drag_pos = Vector3.zero;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var canvas = GameObject.FindGameObjectWithTag("Canvas");
            if (is_mouse_in_ui(canvas))
            {
                Debug.Log("ignored!!!!!!!!!00 ui");
                return;
            }
        }
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
                    if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
                    {
                        var Mousepos = Input.mousePosition;

                        //UnityEngine.Debug.Log("posssssssssssssssssss: "+Mousepos);
                        var Wpos = Camera.main.ScreenToWorldPoint(Mousepos);
                        draw_cross(new Vector3(Wpos.x, Wpos.y, 0));
                    }
                    break;
                }
        }
    }

    bool is_mouse_in_ui(GameObject parent)
    {
        var m_pos = Input.mousePosition;
        foreach (Transform uigo in parent.transform)
        {
            try
            {
                var rectTransform =
                    uigo.gameObject.GetComponent<RectTransform>();
                var width = rectTransform.rect.width;
                var height = rectTransform.rect.height;
                var pos = rectTransform.position;
                if (
                    m_pos.x < pos.x + (width / 2) &&
                    m_pos.x > pos.x - (width / 2) &&
                    m_pos.y > pos.y - (height / 2) &&
                    m_pos.y < pos.y + (height / 2)
                ) return true;
            }
            catch
            {
            }
            try
            {
                foreach (Transform sub_uigo in uigo.transform)
                {
                    if (is_mouse_in_ui(sub_uigo.gameObject)) return true;
                }
            }
            catch
            {
            }
        }
        return false;
    }
}
