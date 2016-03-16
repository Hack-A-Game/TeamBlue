using UnityEngine;
using UnityEngine.UI;

public class CardPanel : MonoBehaviour {

    public Image charS;
    public Text costT;
    public Text healthT;
    public Text attackT;
    public Text typeT;

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

}
