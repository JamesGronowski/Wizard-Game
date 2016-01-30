using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private Phase currentPhase;
    public enum Phase {Results, Player1, Player2};

	public Player player1, player2;
	[HideInInspector]
	public Player currentCaster;

	public static GameController instance;


    void Start()
    {
		if (instance == null) {
			instance = new GameController();
		} else {
			Destroy(this);
		}
    }

	public GameController() {
		currentPhase = Phase.Player1;
		TriggerPhaseObjects();
	}

    public void EndTurn()
    {
        
        if (currentPhase == Phase.Player2)
        {
            currentPhase = Phase.Results;
        }
        else
        {
            currentPhase++;
        }

        Debug.Log(currentPhase.ToString());
		Debug.Log(Ritual.FIREBALL.Castable(new Rune[] {Rune.a}));
		Debug.Log(Ritual.FIREBALL.Castable(new Rune[] {Rune.a, Rune.f}));
        
        TriggerPhaseObjects();

        if (currentPhase == Phase.Results) {
            RunResults();
        }
    }

    void TriggerPhaseObjects()
    {
        PhaseButton[] phaseObjects = FindObjectsOfType(typeof(PhaseButton)) as PhaseButton[];
        foreach (PhaseButton p in phaseObjects)
        {
            p.OnPhase(currentPhase);
        }
    }

    void RunResults()
    {
        Player[] players = FindObjectsOfType(typeof(Player)) as Player[];
        foreach (Player p in players)
        {
            p.addRunes();
        }

		currentCaster = player1;
		currentCaster.castingEffect = true;
		RitualEffect.Invoke(currentCaster.getTurn().ritualCast);
		while (currentCaster.castingEffect == true) {
			yield return null;
		}
		currentCaster = player2;
		currentCaster.castingEffect = true;
		RitualEffect.Invoke(currentCaster.getTurn().ritualCast);
		while (currentCaster.castingEffect == true) {
			yield return null;
		}
    }

}
