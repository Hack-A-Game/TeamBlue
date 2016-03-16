using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    private List<Card> playerHand;
	private List<Card> cpuHand;

    private DeckBuilder deckBuilder;

    public UIController uiController;
    public Board board;

	// Use this for initialization
	void Start () {
        // Init the game
        deckBuilder = GetComponent<DeckBuilder>();

        // Inint player hands
        playerHand = new List<Card>();
        cpuHand = new List<Card>();
        for (int i = 0; i < 3; i++) {
            playerHand.Add(deckBuilder.nextCard());
            cpuHand.Add(deckBuilder.nextCard());
        }

        uiController.updateCards();
	}

    // Returns true if a player can play a card
    public bool canPlayCard(int player) {
        switch (player) {
            case 0:
                return board.cardAt(0) == null;
            case 1:
                return board.cardAt(board.maxCards-1) == null;
            default:
                return false;
        }
    }

    // Returns the Human Player hand
    public List<Card> getPlayerHand() {
        return playerHand;
    }

    // Plays a card from the player hands
    public void playPlayerCard(int cardIndex) {

        if (canPlayCard(0)) {
			GameObject unit = (GameObject)Instantiate(playerHand[cardIndex].prefab, Vector3.zero, Quaternion.identity);
			unit.transform.localScale = new Vector3(5, 5, 1);
			board.addCard(unit, 0);
        }

        board.repositionCards();
    }
	

    // Advance to the next turn
    public void advanceTurn() {
        GameObject[] cards = board.getAllCards();      
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
