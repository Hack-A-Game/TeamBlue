using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewGameButton(){
		Debug.Log ("NEW GAME");
		Application.LoadLevel("Game");

	}

	public void ExitGameButton(){
		Debug.Log ("EXIT");
		Application.Quit ();
	}
}
