using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Paused || !Playing)
        {
            //time passes in seconds!!
            thinking_duration += (int)(Time.deltaTime * 1000);
            if (thinking_duration > 20000)
            {
                GetComponent<game1_manager>().info_charged();
                Reset_Thinking();
            }
        }
    }

    public void Reset_Thinking()
    {
        thinking_duration = 0;
    }

    float thinking_duration = 0;

    bool Paused = false;

    bool Playing = false;

    public void Plays()
    {
        Playing = true;
    }

    public void Stops()
    {
        Playing = false;
        Paused = false;
    }

    public void PauseifPlaying()
    {
        if (!Playing)
        {
            UnityEngine.Debug.Log("not playin");
            return;
        }
        var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];
        Paused = true;
        if (cyl_parent != null) cyl_parent.GetComponent<rotate>().stop();
    }

    public void ResumeifPaused()
    {
        if (!Paused) return;
        Paused = false;
        Playing = true;
        var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];
        if (cyl_parent != null) cyl_parent.GetComponent<rotate>().start();
    }
}
