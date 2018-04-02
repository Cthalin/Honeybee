using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("s"))
        {
            EventManager.TriggerEvent("playClip");
        }

        if (Input.GetKeyDown("w"))
        {
            EventManager.TriggerEvent("nextClip");
        }
    }
}
