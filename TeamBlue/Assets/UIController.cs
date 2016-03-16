using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

    GameController controller;

    Deck playerDeck;

	// Use this for initialization
	void Start () {
        controller = GameObject.Find("GameController").GetComponent<GameController>();

        //playerDeck = controller.getPlayerDeck();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
