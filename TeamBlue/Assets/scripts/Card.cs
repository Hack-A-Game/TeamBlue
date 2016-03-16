using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
	public int ID;
	public int cost;
	public int health;
	public int attack;
	public element ele;
	public string unitName;
	public Sprite cardSprite;
	public GameObject prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public enum element { water, fire, earth, neutral };