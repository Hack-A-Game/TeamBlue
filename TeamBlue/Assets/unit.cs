using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	private int attack;
	private int hp;
	private int maxHp;
	private element ele;

	// Use this for initialization
	void Start () {
		Card card = GetComponent<Card>();
		attack = card.attack;
		maxHp = card.health;
		hp = maxHp;
		ele = card.ele;
	}

	public int getDamageAgainst(GameObject enemy)
	{
		Card enemyCard = enemy.GetComponent<Card>();
		float multiplier = 1f;
		if (ele == element.earth)
		{
			if (enemyCard.ele == element.fire) multiplier = 0.5f;
			if (enemyCard.ele == element.water) multiplier = 2;
		}
		if (ele == element.fire)
		{
			if (enemyCard.ele == element.water) multiplier = 0.5f;
			if (enemyCard.ele == element.earth) multiplier = 2;
		}
		if (ele == element.water)
		{
			if (enemyCard.ele == element.earth) multiplier = 0.5f;
			if (enemyCard.ele == element.fire) multiplier = 2;
		}
		return (int)Mathf.Ceil(attack * multiplier);
	}

	public bool damage(int damage)
	{
		hp -= damage;
		if (hp < 0)
		{
			return true;
		}
		else return false;
	}
}
