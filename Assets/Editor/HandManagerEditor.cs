using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CustomEditor(typeof(HandManager))]
public class HandManagerEditor : Editor {

	public override void OnInspectorGUI(){

		HandManager myHandManager = (HandManager)target;
		if (GUILayout.Button ("Fill out")) {

			// Hand Manager

			if (!myHandManager.leftcontroller) {
				myHandManager.leftcontroller = GameObject.Find ("[VRTK_Scripts]/LeftController");
			}
			if (!myHandManager.rightcontroller) {
				myHandManager.rightcontroller = GameObject.Find ("[VRTK_Scripts]/RightController");
			}
			if (!myHandManager.leftTool) {
				myHandManager.leftTool = myHandManager.GetComponent<Tool_Menu> ();
			}

			// Tool Laser

			if (myHandManager.GetComponent<Tool_Laser> () && !myHandManager.GetComponent<Tool_Laser> ().laserEmittingObject) {
				myHandManager.GetComponent<Tool_Laser> ().laserEmittingObject = GameObject.Find ("[VRTK_Scripts]/RightController");
			}

			// Tool Measure

			if (myHandManager.GetComponent<Tool_Measure> () && !myHandManager.GetComponent<Tool_Measure> ().laserEmittingObject) {
				myHandManager.GetComponent<Tool_Measure> ().laserEmittingObject = GameObject.Find ("[VRTK_Scripts]/RightController");
			}

		}

		DrawDefaultInspector ();

	}
}
