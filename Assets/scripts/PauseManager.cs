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
    }

    bool Paused = false;

    bool Playing = false;

    public void Plays()
    {
        Playing = true;
    }

    public void PauseifPlaying()
    {
        if (!Playing) return;
        var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];
        Paused = true;
		if (cyl_parent!=null)
        cyl_parent.GetComponent<rotate>().stop();
    }

    public void ResumeifPaused()
    {
        if (!Paused) return;
        Paused = false;
        Playing = true;
        var cyl_parent = GameObject.FindGameObjectsWithTag("cylinderparent")[0];
		if (cyl_parent!=null)

        cyl_parent.GetComponent<rotate>().start();
    }
}
