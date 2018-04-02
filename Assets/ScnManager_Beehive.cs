using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScnManager_Beehive : MonoBehaviour {

	public CanvasGroup canvasGroup;
	public GameObject canvasFadeIn;

	// Use this for initialization
	void Start () {
		canvasFadeIn.SetActive (true);
		canvasGroup.GetComponent<FadeScript>().FadeOut ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
