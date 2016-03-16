using UnityEngine;
using System.Collections.Generic;
using System;

public class DeckBuilder : MonoBehaviour {
	private System.Random rnd = new System.Random();
	public CardProbability[] cardProbabilitiesSP;
	public CardProbability[] cardProbabilitiesSF;
	private int sumProbSP;
	private int sumProbSF;

	void Start()
	{
		sumProbSP = 0;
		for (int i = 0; i < cardProbabilitiesSP.Length; i++)
		{
			sumProbSP += cardProbabilitiesSP[i].prob;
		}
		sumProbSF = 0;
		for (int i = 0; i < cardProbabilitiesSF.Length; i++)
		{
			sumProbSF += cardProbabilitiesSF[i].prob;
		}
	}


	public Card nextCardSP()
	{
		int rng = rnd.Next(0, sumProbSP);
		int i = 0;
		Boolean notFound = true;
		while (notFound && i < cardProbabilitiesSP.Length)
		{
			if (cardProbabilitiesSP[i].prob < rng)
			{
				rng -= cardProbabilitiesSP[i].prob;
				i++;
			}
			else {
				notFound = false;
				return cardProbabilitiesSP[i].unit.GetComponent<Card>();
			}
		}
		return cardProbabilitiesSP[cardProbabilitiesSP.Length - 1].unit.GetComponent<Card>(); ;
	}

	public Card nextCardSF()
	{
		int rng = rnd.Next(0, sumProbSF);
		int i = 0;
		Boolean notFound = true;
		while (notFound && i < cardProbabilitiesSF.Length)
		{
			if (cardProbabilitiesSF[i].prob < rng)
			{
				rng -= cardProbabilitiesSF[i].prob;
				i++;
			}
			else {
				notFound = false;
				return cardProbabilitiesSF[i].unit.GetComponent<Card>();
			}
		}
		return cardProbabilitiesSF[cardProbabilitiesSF.Length - 1].unit.GetComponent<Card>(); ;
	}
}

[Serializable]
public struct CardProbability
{
	public GameObject unit;
	public int prob;
}