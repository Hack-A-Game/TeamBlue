using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(0, 0, 120, 140), "CHOOSE ACTION");

        // Make the Card1 button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(10, 30, 100, 20), "Card 1"))
        {
            //Application.LoadLevel(1);
        }

        // Make the Card2 button.
        if (GUI.Button(new Rect(10, 55, 100, 20), "Card 2"))
        {
            //Application.LoadLevel(2);
        }

        // Make the Swap button.
        if (GUI.Button(new Rect(10, 80, 100, 20), "Swap"))
        {
            //Application.LoadLevel(3);
        }

        // Make the Pass button. If it is pressed, Application.Loadlevel (4) will be executed
        if (GUI.Button(new Rect(10, 105, 100, 20), "Pass"))
        {
            //Application.LoadLevel(4);
        }
    }

}
