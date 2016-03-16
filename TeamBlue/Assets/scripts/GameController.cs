using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    // Human player
    public const int PLAYER1 = 0;
    // CPU Player
    public const int PLAYER2 = 1;

    // Gold each player has
    private int[] goldPerPlayer;

    private List<Card> playerHand;
	private List<Card> cpuHand;

    private DeckBuilder deckBuilder;
    public UIController uiController;
    public Board board;

	// Use this for initialization
	void Start () {
        // Init the game
        deckBuilder = GetComponent<DeckBuilder>();

        goldPerPlayer = new int[2];
        goldPerPlayer[PLAYER1] = 100;
        goldPerPlayer[PLAYER2] = 100;

        // Inint player hands
        playerHand = new List<Card>();
        cpuHand = new List<Card>();
        for (int i = 0; i < 3; i++) {
            playerHand.Add(deckBuilder.nextCard());
            cpuHand.Add(deckBuilder.nextCard());
        }
        
        uiController.updateCards();
	}

    public int getPlayerGold(int player) {
        return goldPerPlayer[player];
    }

    // Returns true if a player can play a card
    public bool canPlayCard(int player) {
        switch (player) {
            case PLAYER1:
                return board.getCardAt(0) == null;
            case PLAYER2:
                return board.getCardAt(board.maxCards-1) == null;
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

        if(playCard(cardIndex, PLAYER1)) {

            playCard(cardIndex, PLAYER1);
            playCard(0, PLAYER2);
            advanceTurn();

            uiController.updateCards();


            board.repositionCards();
        }

    }

	public bool playCard(int cardIndex, int playerID) {

        if (!canPlayCard(playerID))
            return false;

        // Player plays card, new card drawn from deck
        // TODO Check gold cost
        GameObject unit = null;
        int cardPos = 0;

        // Different units and 
        switch (playerID){
            case PLAYER1:
                unit = (GameObject)Instantiate(playerHand[cardIndex].prefab, Vector3.zero, Quaternion.identity);
                cardPos = 0;
                
                // Delete card from hand and draw new card
                playerHand.RemoveAt(cardIndex);
                playerHand.Add(deckBuilder.nextCard());
                break;
            case PLAYER2:
                unit = (GameObject)Instantiate(cpuHand[cardIndex].prefab, Vector3.zero, Quaternion.identity);
                cardPos = board.maxCards - 1;

                // Delete card from hand and draw new card
                cpuHand.RemoveAt(cardIndex);
                cpuHand.Add(deckBuilder.nextCard());
                break;
        }
        

        unit.transform.localScale = new Vector3(3, 3, 1);
        board.putCard(unit, cardPos, playerID);

        return true;
    }

    public void passTurn() {
        playCard(0, PLAYER2);
        advanceTurn();

        board.repositionCards();
    }

    // Advance to the next turn
    public void advanceTurn() {
        GameObject[] units = board.getAllCards();

        bool hasMoved = true;
        List<int> moved = new List<int>();

        while (hasMoved) {
            hasMoved = false;
            for (int i = 0; i < units.Length; i++) {
                // TODO Check for enemy

                if (units[i] == null || moved.Contains(i))
                    continue;

                int unitPlayerID = board.getPlayerIDAt(i);

                int dir = 1;
                if (unitPlayerID == PLAYER2)
                    dir = -1;
                
                if(units[i + dir] == null) {
                    GameObject cardobj = board.popCard(i);
                    board.putCard(cardobj, i + dir, unitPlayerID);
                    // Tag the newly moved card as moved
                    moved.Add(i + dir);
                    // reset loop frag and restart loop
                    hasMoved = true;
                    break;
                }
            }
        }
        


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
