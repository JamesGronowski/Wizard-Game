using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	[HideInInspector]
	public bool castingEffect = false;
	[HideInInspector]
	public bool castingAnimation = false;
    
    private enum StatusEffect { };//fill
    private int health;
    private List<Rune> runeBucket;
    private Turn turn;

	void Start () {
        health = 100;
        runeBucket = new List<Rune>();
	}

    public void addRunes()
    {
        runeBucket.AddRange(turn.runesAdded);
        turn.runesAdded.Clear();
    }

	public void addHealth(int damage) {
		health += damage;
	}
    
    public Turn getTurn() {
		return turn;
	}
}
