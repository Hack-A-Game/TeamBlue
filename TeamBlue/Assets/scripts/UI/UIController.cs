using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameController controller;

    public CardPanel nextCardB;
    public CardPanel card1B;
    public CardPanel card2B;

    public Text goldT;
    public Text turnT;

    public List<Card> playerDeck;

    // Use this for initialization
    void Start () {

        controller = GameObject.Find("GameController").GetComponent<GameController>();
        //updateTurn(20, 30);
        //updateGold();

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

        updateGold();

    }

    //Method to update the gold
    public void updateGold()
    {
        goldT.text = controller.getPlayerGold(0).ToString();

        playerDeck = controller.getPlayerHand();

        //CARDS
        Card nextCard = playerDeck[2];
        Card card1 = playerDeck[0];
        Card card2 = playerDeck[1];

        card1B.enableCard(card1, controller.getPlayerGold(0), card1B);
        card2B.enableCard(card2, controller.getPlayerGold(0), card2B);
    }

    public void updateTurn(int turn, int maxTurn)
    {
        turnT.text = turn.ToString()+"/"+maxTurn.ToString();
    }

}
