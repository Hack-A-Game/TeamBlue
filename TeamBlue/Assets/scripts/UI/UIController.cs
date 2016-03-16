using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

    GameController controller;

    public Button nextCardB;
    public Button card1B;
    public Button card2B;

    List<Card> playerDeck;

	// Use this for initialization
	void Start () {
        controller = GameObject.Find("GameController").GetComponent<GameController>();

        playerDeck = new List<Card>();
        //playerDeck = gameController.getPlayerHand();

	}
	
	// Update is called once per frame
	void Update () {

	}

    void updateCards()
    {
        //CARDS
        Card nextCard = playerDeck[2];
        Card card1 = playerDeck[0];
        Card card2 = playerDeck[1];

        //TEXT SETTING
        GUIText nextCardT = nextCardB.GetComponent<GUIText>();
        GUIText card1T = card1B.GetComponent<GUIText>();
        GUIText card2T = card2B.GetComponent<GUIText>();
        string nextCardS = nextCard.unitName +"\n"+"Cost: "+nextCard.cost+"\n"+"Health: "+nextCard.health+"\n"+"Attack: "+nextCard.attack;
        string card1S = card1.unitName + "\n" + "Cost: " + card1.cost + "\n" + "Health: " + card1.health + "\n" + "Attack: " + card1.attack;
        string card2S = card2.unitName + "\n" + "Cost: " + card2.cost + "\n" + "Health: " + card2.health + "\n" + "Attack: " + card2.attack;
        nextCardT.text = nextCardS;
        card1T.text = card1S;
        card2T.text = card2S;

        //SPRITE SETTING
        Texture nextCardST = nextCardB.GetComponent<Texture>();
        Texture card1ST = card1B.GetComponent<Texture>();
        Texture card2ST = card2B.GetComponent<Texture>();
        nextCardST = nextCard.cardTexture;
        card1ST = card1.cardTexture;
        card2ST = card2.cardTexture;
    }

}
