using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour
{
    private Phase currentPhase;
    public enum Phase {Results, Player1, Player2};
    private Phase currentView;

    public CameraBehaviour cam;

    // Use this for initialization
    void Start()
    {
        currentPhase = Phase.Player1;
        TriggerPhaseObjects();

        currentView = Phase.Player1;
        TriggerCameraView();
    }

    

    // Update is called once per frame
    void Update()
    {

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

        if (currentView == Phase.Player2)
        {
            currentView = Phase.Results;
        }
        else
        {
            currentView++;
        }

        Debug.Log(currentPhase.ToString());
		Debug.Log(Ritual.FIREBALL.Castable(new Rune[] {Rune.a}));
		Debug.Log(Ritual.FIREBALL.Castable(new Rune[] {Rune.a, Rune.f}));
        
        TriggerPhaseObjects();
        TriggerCameraView();

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
    }

    void TriggerCameraView()
    {
        cam.OnViewChange(currentView);
    }

}
