using UnityEngine;
using System.Collections.Generic;

public class DeckBuilder : MonoBehaviour {
	public Dictionary<Card, int> deckDesign;

	public void initDeck(Deck deck)
	{
		foreach (KeyValuePair<Card, int> card in deckDesign) {
			for (int i = 0; i < card.Value; i++) deck.deck.Add(card.Key);
		}
	}
}
