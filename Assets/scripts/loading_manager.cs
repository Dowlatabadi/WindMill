using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperBlur;

public class loading_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public SuperBlurFast SuperBlurFastScript;

    void Start()
    {
        SuperBlurFastScript = GetComponent<SuperBlurFast>();
		fade_out_blur();
    }

    public void fade_out_blur()
    {
		SuperBlurFastScript.enabled=true;

        SuperBlurFastScript.interpolation = 1f;
        final_interpolation = 0f;
        speed_factor=7;

        animating = true;
		
    }

    public void fade_in_blur()
    {
		SuperBlurFastScript.enabled=true;

        SuperBlurFastScript.interpolation = 0;
        final_interpolation = 1f;
        speed_factor=2;
		animating = true;

    }
public int speed_factor;
    bool animating = false;

   

    float final_interpolation = 0;

    // Update is called once per frame
    void Update()
    {
        if (animating)
        {
            SuperBlurFastScript.interpolation =
                Mathf
                    .Lerp(SuperBlurFastScript.interpolation,
                    final_interpolation,
                    Time.deltaTime*speed_factor);

            if (
                Mathf
                    .Abs(SuperBlurFastScript.interpolation -
                    final_interpolation) <
                .01
            )
            {
                animating = false;
                SuperBlurFastScript.interpolation = final_interpolation;
				if (final_interpolation<.1f)
				{
					SuperBlurFastScript.enabled=false;
				}
            }
        }
    }
}
