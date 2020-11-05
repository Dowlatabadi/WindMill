using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unshow_dialogues()
    {
        //close other messages
        var dia = GameObject.FindGameObjectWithTag("DialogueBox");

        if (dia != null)
        {
            dia.GetComponent<Dialogue_script>().destroy();
        }
    }
}
