using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu_Manager : MonoBehaviour
{
    public GameObject Start_button;

    // Start is called before the first frame update
    void Start()
    {
        if (Camera.main.GetComponent<save_manager>().get_progress_lvl() > 1)
        {
			Start_button.GetComponentInChildren<TextMeshProUGUI>().fontSize=75;
			Start_button.GetComponentInChildren<TextMeshProUGUI>().text="Continue";
        }
        //change to continue
    }

    // Update is called once per frame
    void Update()
    {
    }
}
