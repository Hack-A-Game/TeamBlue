using UnityEngine;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

    public GameController controller;

    public CardPanel nextCardB;
    public CardPanel card1B;
    public CardPanel card2B;

    public List<Card> playerDeck;

    // Use this for initialization
    void Start () {

        controller = GameObject.Find("GameController").GetComponent<GameController>();

    }
	
	// Update is called once per frame
	void Update () {

	}

    //Method to be called at the start of every player turn
    public void updateCards()
    {
		Debug.Log (controller);

        playerDeck = controller.getPlayerHand();

        //CARDS
        Card nextCard = playerDeck[2];
        Card card1 = playerDeck[0];
        Card card2 = playerDeck[1];

        nextCardB.updatePanel(nextCard);
        card1B.updatePanel(card1);
        card2B.updatePanel(card2);

    }

    //Method to be called when the player plays a card
    void playedCard()
    {
        
    }

}
