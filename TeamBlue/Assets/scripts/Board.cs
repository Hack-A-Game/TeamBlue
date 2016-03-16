using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {



    public int maxCards = 8;

    // Board size in game units
    public float boardSize = 8;

    private GameObject[] slots;
    private int usedSlots;

    // Use this for initialization
    void Start () {
        usedSlots = 0;
        slots = new GameObject[maxCards];

        GameObject card = GameObject.Find("Card1");

        addCard(card, 7);

        repositionCards();

	}

    // Move cards to 
    public void repositionCards() {
        float step = boardSize / maxCards;

        float cardPos = 0;
        for (int i = 0; i < maxCards; i++) {
            if (slots[i] == null)
                continue;

            GameObject card = slots[i];            
            var xPos = transform.position.x;
            float yPos = transform.position.y - boardSize / 2 + cardPos;
            card.transform.position = new Vector3(xPos, yPos, 0);

            Debug.Log("Placed card" + card.ToString() + "at pos" + cardPos);

            cardPos += step;
        }
    }

    // Add a card to the board, player is 0 for player 1 and 1 for player 2
    public bool addCard(GameObject card, int pos) {

        if (usedSlots >= maxCards || slots[pos] != null) 
            return false;

        slots[pos] = card;
        return true;
    }

    // Removes a card at a certain position
    public bool removeCard(int pos) {
        if(slots[pos] != null) {
            slots[pos] = null;

            usedSlots -= 1;
            return true;
        }
        return false;
    }

    // Returns the card at a certain position
    public GameObject cardAt(int pos) {
        return slots[pos];
    }

    public GameObject[] getAllCards() {
        return slots;
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
