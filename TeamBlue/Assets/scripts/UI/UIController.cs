using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

    public GameController controller;

    public Button nextCardB;
    public Button card1B;
    public Button card2B;

    public List<Card> playerDeck;

    /*//TEST
    public GameObject nyu;
    public Button testB;*/

    // Use this for initialization
    void Start () {
        //controller = GameObject.Find("GameController").GetComponent<GameController>();

        //playerDeck = new List<Card>();
        //playerDeck = gameController.getPlayerHand();

        /*//TEST
        Card testC = nyu.GetComponent<Card>();
        Text testT = testB.GetComponentInChildren<Text>();
        string testS;
        testS = testC.unitName + "\n" + "Cost: " + testC.cost + "\n" + "Health: " + testC.health + "\n" + "Attack: " + testC.attack;
        testT.text = testS;
        Image testST = testB.GetComponent<Image>();
        testST.sprite = testC.cardTexture; //cardTexture sera un Sprite*/

    }
	
	// Update is called once per frame
	void Update () {

	}

    //Method to be called at the start of every player turn
    public void updateCards()
    {
		playerDeck = controller.getPlayerHand();

		//CARDS
		Card nextCard = playerDeck[2];
        Card card1 = playerDeck[0];
        Card card2 = playerDeck[1];

        //TEXT SETTING
        //Text nextCardT = nextCardB.GetComponentInChildren<Text>();
        Text card1T = card1B.GetComponentInChildren<Text>();
        Text card2T = card2B.GetComponentInChildren<Text>();
        string nextCardS = nextCard.unitName +"\n"+"Cost: "+nextCard.cost+"\n"+"Health: "+nextCard.health+"\n"+"Attack: "+nextCard.attack;
        string card1S = card1.unitName + "\n" + "Cost: " + card1.cost + "\n" + "Health: " + card1.health + "\n" + "Attack: " + card1.attack;
        string card2S = card2.unitName + "\n" + "Cost: " + card2.cost + "\n" + "Health: " + card2.health + "\n" + "Attack: " + card2.attack;
        //nextCardT.text = nextCardS;
        card1T.text = card1S;
        card2T.text = card2S;

        /*//SPRITE SETTING (Card Texture will be Sprite)
        Image nextCardST = nextCardB.GetComponent<Image>();
        Image card1ST = card1B.GetComponent<Image>();
        Image card2ST = card2B.GetComponent<Image>();
        nextCardST.sprite = nextCard.cardTexture;
        card1ST.sprite = card1.cardTexture;
        card2ST.sprite = card2.cardTexture;*/

        /*Texture nextCardST = nextCardB.GetComponent<Texture>();
        Texture card1ST = card1B.GetComponent<Texture>();
        Texture card2ST = card2B.GetComponent<Texture>();
        nextCardST = nextCard.cardTexture;
        card1ST = card1.cardTexture;
        card2ST = card2.cardTexture;*/
    }

    //Method to be called when the player plays a card
    void playedCard()
    {
        
    }

}
