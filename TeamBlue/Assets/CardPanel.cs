using UnityEngine;
using UnityEngine.UI;

public class CardPanel : MonoBehaviour {

    public Image charS;
    public Text costT;
    public Text healthT;
    public Text attackT;
    public Text typeT;
    public Image coverS;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updatePanel(Card card)
    {

        //TEXT SETTINGS
        costT.text = card.cost.ToString();
        healthT.text = card.health.ToString();
        attackT.text = card.attack.ToString();
        typeT.text = card.ele.ToString();

        //SPRITE SETTING (Card Texture will be Sprite)
        charS.sprite = card.cardTexture;

    }

    public void enableCard(Card card, int gold, CardPanel cardB)
    {
        if (card.cost > gold)
        {
            coverS.enabled = true;
            cardB.GetComponent<Button>().enabled = false;
        } else
        {
            coverS.enabled = false;
            cardB.GetComponent<Button>().enabled = true;
        }
    }

}
