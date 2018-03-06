using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour {

    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;
    bool triggerDown = false;

    public GameObject Player;
    public float Speed;

    // Use this for initialization
    void Start () {
        trackedObject = GetComponentInChildren<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
	}
	
	// Update is called once per frame
	void Update () {
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Triggered");
            triggerDown = true;
            device.TriggerHapticPulse(2000);
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Axis0))
        {
            triggerDown = false;
        }

        if (triggerDown)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + Speed * Time.deltaTime);
        }
	}
}
