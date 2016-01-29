using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    
    private enum StatusEffect { };//fill
    private int health;
    private List<Rune> runeBucket;
    private Turn turn;

	// Use this for initialization
	void Start () {
        health = 100;
        runeBucket = new List<Rune>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addRunes()
    {
        runeBucket.AddRange(turn.runesAdded);
        turn.runesAdded.Clear();
    }
    
    
}
