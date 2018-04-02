using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SetPlayerMovement : MonoBehaviour {

    void Awake()
    {
        VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
    }
    protected virtual void OnEnable()
    {
        var activeCameraRig = GameObject.FindGameObjectWithTag("CameraRig");
    }
    protected virtual void OnDestroy()
    {
        VRTK_SDKManager.instance.RemoveBehaviourToToggleOnLoadedSetupChange(this);
    }
}
