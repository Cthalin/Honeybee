using UnityEngine;
using VRTK;
using System.Collections;

public class TouchTile : MonoBehaviour {

    [SerializeField] private GameObject SceneManager;

    void Start()
    {
        //make sure the object has the VRTK script attached... 
        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            Debug.LogError("TouchTile is required to be attached to an Object that has the VRTK_InteractableObject script attached to it");
            return;
        }

        //subscribe to the event.  NOTE: the "ObectGrabbed"  this is the procedure to invoke if this objectis grabbed.. 
        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += new InteractableObjectEventHandler(ObjectUsed);
    }

   //this object has been grabbed.. so do what ever is in the code.. 
    private void ObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("I feel so used");
        SceneManager.GetComponent<TileScript>().OnControllerTouchInteractableObject(this.gameObject);
    }
}
