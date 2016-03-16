using UnityEngine;
using System.Collections.Generic;
using System;

public class DeckBuilder : MonoBehaviour {
	private System.Random rnd = new System.Random();
	public CardProbability[] cardProbabilities;
	private int sumProb;

	void Start()
	{
		sumProb = 0;
		for (int i = 0; i < cardProbabilities.Length; i++)
		{
			sumProb += cardProbabilities[i].prob;
		}
	}


	public Card nextCard()
	{
		int rng = rnd.Next(0, sumProb);
		int i = 0;
		Boolean notFound = true;
		while (notFound && i < cardProbabilities.Length)
		{
			if (cardProbabilities[i].prob < rng)
			{
				rng -= cardProbabilities[i].prob;
				i++;
			}
			else {
				notFound = false;
				return cardProbabilities[i].unit.GetComponent<Card>();
			}
		}
		return cardProbabilities[cardProbabilities.Length - 1].unit.GetComponent<Card>(); ;
	}
}

[Serializable]
public struct CardProbability
{
	public GameObject unit;
	public int prob;
}