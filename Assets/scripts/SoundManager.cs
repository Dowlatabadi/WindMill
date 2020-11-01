using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool musixMuted = false;

    public AudioClip[] AudioClips;

    public void play_clickSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(AudioClips[2], 3f);
    }

    public void play_ding()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(AudioClips[0], 1f);
    }

    // Start is called before the first frame update
    void Start()
    {

		   if (!musixMuted)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
