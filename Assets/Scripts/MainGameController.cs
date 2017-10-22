using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour {

    public static MainGameController instance;

    private int _currentScore;
    private void Awake()
    {
        instance = this;
    }

    public void AdjustScore(int number) {
        _currentScore = _currentScore + number;
    }

    private void OnGUI()
    {

        GUI.Label(new Rect(10, 10, 100, 100), "Score = " + _currentScore.ToString());

    }
}
