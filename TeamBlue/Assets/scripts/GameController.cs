using UnityEngine;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour
{
	private int turn;
	public int maxTurns = 20;

	// Human player
	public const int PLAYER1 = 0;
	// CPU Player
	public const int PLAYER2 = 1;


	public const int ACTION_PLAY_CARD = 3;
	public const int ACTION_SKIP = 4;
	public const int ACTION_SWITCH = 5;



    // Gold each player has
    private int[] goldPerPlayer;

	private List<Card> playerHand;
	private List<Card> cpuHand;

	private DeckBuilder deckBuilder;
	public UIController uiController;
	public Board board;

	public int action;

	private System.Random rnd;

	// Use this for initialization
	void Start()
	{
		rnd = new System.Random();
		// Init the game
		deckBuilder = GetComponent<DeckBuilder>();
		
		turn = 1;

		goldPerPlayer = new int[2];
		goldPerPlayer[PLAYER1] = 3;
		goldPerPlayer[PLAYER2] = 3;

		// Inint player hands
		playerHand = new List<Card>();
		cpuHand = new List<Card>();
		for (int i = 0; i < 3; i++)
		{
			playerHand.Add(deckBuilder.nextCardSF());
			cpuHand.Add(deckBuilder.nextCardSP());
		}

		uiController.updateCards();
		uiController.updateGold();
	}

	public int getPlayerGold(int player) {
		return goldPerPlayer[player];
	}
	
	public void setAction(int action){
		this.action = action;
	}
	
	
	public void doAction(int opt){
		

		
		if (advanceTurn() != -1) Application.LoadLevel("demo/MainScene");;

		board.attackPhase (0);

		/**
		* Player 1 turn
		*/
		switch(this.action){
		case ACTION_PLAY_CARD:
			playCard (opt, PLAYER1);
			
			break;
		case ACTION_SKIP:
			skipTurn ();
			
			break;
		case ACTION_SWITCH:
			
			break;
		default:
			// Shouldn't come into here
			return;
		}
		
		/**
		* Player 2 turn
		*/
		if (rnd.NextDouble() > 0.5)playCard(0, PLAYER2);
		
		/**
		*  PostTurn Actions
		*/
		
		// Repaint the cards
		uiController.updateCards();

		board.repositionCards();
		
		
	}

	// Returns the Human Player hand
	public List<Card> getPlayerHand() {
		return playerHand;
	}
	
	
	// Returns true if a player can play a card
	public bool canPlayCard(int cardIndex, int player)
	{
		if (player == PLAYER2 && goldPerPlayer[PLAYER2] < cpuHand[cardIndex].cost) return false;
		switch (player)
		{
		case PLAYER1:
			return board.getCardAt(0) == null;
		case PLAYER2:
			return board.getCardAt(board.maxCards - 1) == null;
		default:
			return false;
		}
	}
	
	

	
	
	public bool playCard(int cardIndex, int playerID)
	{
		
		if (!canPlayCard(cardIndex, playerID))
			return false;
		
		// Player plays card, new card drawn from deck
		// TODO Check gold cost
		GameObject unit = null;
		int cardPos = 0;
		goldPerPlayer[playerID] -= playerHand[cardIndex].cost;
		
		// Different units and 
		switch (playerID)
		{
		case PLAYER1:
			unit = (GameObject)Instantiate(playerHand[cardIndex].prefab, Vector3.zero, Quaternion.identity);
			cardPos = 0;

                unit.GetComponent<Animator>().SetTrigger("change");
			
			// Delete card from hand and draw new card
			playerHand.RemoveAt(cardIndex);
			playerHand.Add(deckBuilder.nextCardSF());
			break;
		case PLAYER2:
			unit = (GameObject)Instantiate(cpuHand[cardIndex].prefab, Vector3.zero, Quaternion.identity);
			cardPos = board.maxCards - 1;
			
			// Delete card from hand and draw new card
			cpuHand.RemoveAt(cardIndex);
			cpuHand.Add(deckBuilder.nextCardSP());
			break;
		}
		
		
		unit.transform.localScale = new Vector3(3, 3, 1);
		board.putCard(unit, cardPos, playerID);
		
		uiController.updateGold();
		return true;
	}
	
	public void skipTurn()
	{
		goldPerPlayer[PLAYER1]++;
	}
	public int advanceTurn() {
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
		return board.finish();
	}
	private void endGame(int v)
	{
		print(v);
	}
	
	public bool lastTurn()
	{
		return turn >= maxTurns;
	}
}
