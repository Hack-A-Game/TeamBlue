using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public int maxCards = 8;

    private Object[] slots;
    private int usedSlots;

    // Use this for initialization
    void Start () {
        slots = new Object[maxCards];
	}

    // Add a card to the board, player is 0 for player 1 and 1 for player 2
    public bool addCard(Object card, int player) {

        if (usedSlots >= maxCards)
            return false;

        if(player == 0) {
            // Player 1
            int i = 0;
            while (slots[i] != null)
                i++;
            slots[i] = card;
        }
        else if (player == 1) {
            // Player 1
            int i = maxCards-1;
            while (slots[i] != null)
                i--;
            slots[i] = card;
        }

        return true;
    }

    // Removes a card at a certain position
    public bool removeCard(int pos) {
        if(slots[pos] != null) {
            slots[pos] = null;
            return true;
        }
        return false;
    }

    // Returns the card at a certain position
    public Object cardAt(int pos) {
        return slots[pos];
    }

    public Object[] getAllCards() {
        return slots;
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
