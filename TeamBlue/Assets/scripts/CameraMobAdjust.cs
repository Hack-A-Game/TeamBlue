using UnityEngine;
using System.Collections;

public class CameraMobAdjust : MonoBehaviour {

    public Camera Cam1;

	// Use this for initialization
	void Start () {

        Cam1.aspect = (Screen.currentResolution.width / Screen.currentResolution.height);
        //This would stretch the game scene in order to adjust it to the Device's screen

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
