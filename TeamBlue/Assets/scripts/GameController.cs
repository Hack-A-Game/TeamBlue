using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private ArrayList playerHand;
	private ArrayList cpuHand;

    private DeckBuilder deckBuilder;

    private UIController uiController;

    private Board board;

	// Use this for initialization
	void Start () {
        // Init the game
        uiController = GameObject.Find("GameUI").GetComponent<UIController>();
        board = GameObject.Find("Board").GetComponent<Board>();
        deckBuilder = GetComponent<DeckBuilder>();

        // Inint player hands
        playerHand = new ArrayList();
        cpuHand = new ArrayList();
        for (int i = 0; i < 3; i++) {
            playerHand.Add(deckBuilder.nextCard());
            cpuHand.Add(deckBuilder.nextCard());
        }

        //uiController.updateCards();
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
    public ArrayList getPlayerHand() {
        return playerHand;
    }

    // Plays a card from a player
    public void playCard(GameObject card, int player) {

        if (canPlayCard(player)) {
            switch (player) {
                case 0:
                    // player 1
                    board.addCard(card, 0);
                    break;
                case 1:
                    // player 2
                    board.addCard(card, board.maxCards-1);
                    break;
                default:
                    return;
            }
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
