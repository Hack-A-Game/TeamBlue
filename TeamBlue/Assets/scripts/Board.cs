using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
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

	
	// Update is called once per frame
	void Update () {
	
	}
}
