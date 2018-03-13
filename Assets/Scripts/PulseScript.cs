using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PulseScript : MonoBehaviour {

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "testTag")
                {
                    hit.collider.GetComponent<Animator>().enabled = true;
                }
            }
        }
    }
}
