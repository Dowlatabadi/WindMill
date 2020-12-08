using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool musixMuted = false;

    public AudioClip[] AudioClips;

    public void play_clickSound()
    {
        gameObject
            .GetComponent<AudioSource>()
            .PlayOneShot(AudioClips[2], 6f * fx_vol);
    }

    public void play_successSound()
    {
        gameObject
            .GetComponent<AudioSource>()
            .PlayOneShot(AudioClips[4], Mathf.Min(.3f * fx_vol,3));
    }

    public void play_ding()
    {
        gameObject
            .GetComponent<AudioSource>()
            .PlayOneShot(AudioClips[0], Mathf.Min(.4f * fx_vol,6));
    }

    public void play_failure()
    {
        gameObject
            .GetComponent<AudioSource>()
            .PlayOneShot(AudioClips[3],Mathf.Min(.3f * fx_vol,3) );
    }

    public float fx_vol = 1f;
public bool game_ground;
    public void AdjustSoundPreferences()
    {
        var music_name = gameObject.GetComponent<save_manager>().get_music();
		if (game_ground)
		music_name="Adrift";
        var music_vol = gameObject.GetComponent<save_manager>().get_music_vol();
        fx_vol = gameObject.GetComponent<save_manager>().get_effects_vol();
        switch (music_name)
        {
            case "Supersonic":
                gameObject.GetComponent<AudioSource>().clip = AudioClips[1];

                break;
            case "Morrow":
                gameObject.GetComponent<AudioSource>().clip = AudioClips[5];

                break;
				case "ForgottenLand":
                gameObject.GetComponent<AudioSource>().clip = AudioClips[7];

                break;
				case "Adrift":
                gameObject.GetComponent<AudioSource>().clip = AudioClips[8];
break;
            default:
                gameObject.GetComponent<AudioSource>().clip = AudioClips[1];

                break;
            
        }
		    gameObject.GetComponent<AudioSource>().volume = music_vol;

                if (!gameObject.GetComponent<AudioSource>().isPlaying)
                if (!musixMuted)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                }
    }

    // Start is called before the first frame update
    void Start()
    {
		
        AdjustSoundPreferences();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
