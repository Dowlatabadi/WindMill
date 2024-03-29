﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed = 20f;

    int rotationSign;

    public GameObject pivot;

    Transform child_transform;

    public void blink()
    {
        GetComponent<Animator>().SetBool("should_blibk", true);
    }

    public void blink_off()
    {
        GetComponent<Animator>().SetBool("should_blibk", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        child_transform = this.gameObject.transform.GetChild(0);

        rotationSign = 1;
    }

    public bool stopped;

    public void stop()
    {
        stopped = true;
    }

    public void start()
    {
        rotationSign = 1;
        stopped = false;
        pivot
            .GetComponent<pivotActions>()
            .OnTriggerEnter2D(this.gameObject.GetComponent<BoxCollider2D>());
        Camera.main.GetComponent<PauseManager>().Plays();
        this.enabled = true;
    }

    public void SPAWN_pivot(GameObject pivot1)
    {
        pivot = pivot1;
if (!pivot1.GetComponent<pivotActions>().intro)
            {
				if (pivot1.tag=="clockwise")
				{
transform
                    .Find("mill")
                    .gameObject
                    .GetComponent<SpriteRenderer>()
                    .color = clockwise_color;

				}
				else
				{
					 transform.Find("mill")
                    .gameObject
                    .GetComponent<SpriteRenderer>()
                    .color = counterclockwise_color;
				}
                
            }
        var pivot_pos = pivot.transform.position;
        transform.position = pivot_pos;
    }
public Color clockwise_color;
public Color counterclockwise_color;
    public void set_pivot(GameObject pivot1, bool clockwise)
    {
        pivot = pivot1;
        var pivot_pos = pivot.transform.position;
        var saved_child_pos = child_transform.position;

        var dis = child_transform.position - transform.position;
        transform.position = pivot_pos;
        child_transform.position = pivot_pos + dis;
        if (clockwise)
        {
            if (!pivot1.GetComponent<pivotActions>().intro)
            {
                transform
                    .Find("mill")
                    .gameObject
                    .GetComponent<SpriteRenderer>()
                    .color = clockwise_color;
					Debug.Log("should be red");
            }
            rotationSign = 1;
        }
        else
        {
            if (!pivot1.GetComponent<pivotActions>().intro)
            {
                transform
                    .Find("mill")
                    .gameObject
                    .GetComponent<SpriteRenderer>()
                    .color =counterclockwise_color;

            }
            rotationSign = -1;
            // pivot.GetComponent<SpriteRenderer>().color = new Color(0, 82f/255f, 1); // Set to opaque bla
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pivot == null || stopped)
        {
            // UnityEngine
            //     .Debug
            //     .Log($"rotate condition faile {pivot == null} || {stopped}");
            return;
        }
        transform.Rotate(Vector3.back * speed * Time.deltaTime * rotationSign);
        //UnityEngine.Debug.Log($"rotates! {pivot == null} || {stopped}");
    }
}
