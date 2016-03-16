using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
    

	// Human player
	public const int PLAYER1 = 0;
	// CPU Player
	public const int PLAYER2 = 1;



	public int maxCards = 8;

    // Board size in game units
    public float boardSize = 8;

    private GameObject[] slots;
    private int[] cardPlayerID;

    private int usedSlots;

    // Use this for initialization
    void Start () {
        usedSlots = 0;
        slots = new GameObject[maxCards];
        cardPlayerID = new int[maxCards];
		for (int i = 0; i < maxCards; i++)
			cardPlayerID[i] = -1;
	}

    // Move cards to 
    public void repositionCards() {
        float step = boardSize / maxCards;

        //float cardPos = 0;
        for (int i = 0; i < maxCards; i++) {
           
            if (slots[i] == null)
                continue;

            GameObject card = slots[i];            
            var xPos = transform.position.x;
            float yPos = transform.position.y - boardSize / 2 + i * step;
            card.transform.position = new Vector3(xPos, yPos, 0);

            //Debug.Log("Placed card" + card.ToString() + "at pos" + ypos);

        }
    }

    // Add a card to the board, player is 0 for player 1 and 1 for player 2
    public bool putCard(GameObject card, int pos, int playerID) {

        if (slots[pos] != null) 
            return false;

        slots[pos] = card;
        cardPlayerID[pos] = playerID;

        print(slots);

        return true;

        
    }

    // Removes a card at a certain position
    public GameObject popCard(int pos) {
        if(slots[pos] != null) {
            GameObject card = slots[pos];
            slots[pos] = null;
            cardPlayerID[pos] = -1;

            usedSlots -= 1;
            return card;
        }
        return null;
    }

    // Returns the card at a certain position
    public GameObject getCardAt(int pos) {
        return slots[pos];
    }

    public int getPlayerIDAt(int pos) {
        return cardPlayerID[pos];
    }

    public GameObject[] getAllCards() {
        return slots;
    }


	public bool canAttack(int player, int pos){
		if (player == PLAYER1 && cardPlayerID[pos] == PLAYER1 && pos + 1 < cardPlayerID.Length && cardPlayerID [pos + 1] == PLAYER2) {
			return true;
		}
		if (player == 1 && cardPlayerID[pos] == PLAYER2 && pos - 1 > 0 && cardPlayerID [pos - 1] == 0) {
			return true;
		}
		return false;
	}


	public bool attack(GameObject attacker, GameObject defender){
		int dmg = (defender.GetComponent<Unit>()).getDamageAgainst (attacker);
		if ((defender.GetComponent<Unit> ()).damage (dmg)) {
			Destroy (defender);
			return true;
		}
		return false;

	}

	public void killPosition(int position){
		popCard (position);

	}


	public void findPossibleAttaks(int attacker){
		for (int i = 0; i < cardPlayerID.Length; i++) {
			if (canAttack(attacker, i)){
				int offset = (attacker == PLAYER1) ? 1 : -1;
				Debug.Log ("Player " + attacker + " attacking with unit in pos: "+i);
				if (attack (slots [i], slots [i + offset])) {
					killPosition (i+offset);
				};
				break;
			}
		}
	}

	public void attackPhase(int attacker){

		findPossibleAttaks (attacker);
		attacker = (attacker == 0) ? 1:0;
		findPossibleAttaks (attacker);

	}

	public int finish(){
		int last = slots.Length - 1;
		return (slots [last] != null && cardPlayerID[last] == PLAYER1) ?
			PLAYER1 : (slots [0] != null  && cardPlayerID[0] == PLAYER2) ? PLAYER2 : -1;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
