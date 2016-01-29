using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    
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
    
    public Turn getTurn() {
		return turn;
	}
}
