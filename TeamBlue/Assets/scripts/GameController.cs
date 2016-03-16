using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private ArrayList playerHand;
	private ArrayList cpuHand;

    private DeckBuilder deckBuilder;

    private Board board;

	// Use this for initialization
	void Start () {

        board = GameObject.Find("Board").GetComponent<Board>();
        deckBuilder = GetComponent<DeckBuilder>();

        // Inint player hands
        playerHand = new ArrayList();
        cpuHand = new ArrayList();
        for (int i = 0; i < 3; i++) {
            playerHand.Add(deckBuilder.newCard());
            cpuHand.Add(deckBuilder.newCard());
        }


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

    public ArrayList getPlayerHand() {
        return playerHand;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
