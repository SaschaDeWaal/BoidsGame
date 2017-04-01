//variables:
//[score] 
//[timeLeft]

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatsText : MonoBehaviour {

    private string scoreText = "";

    private ScoreManager scoreManager;
    private GameManager  gameManager;
    private Text         text;

	private void Start () {
        scoreManager = ManagerObject.Find<ScoreManager>();
        gameManager  = ManagerObject.Find<GameManager>();
        text         = GetComponent<Text>();

        scoreText = text.text;
    }
	
	private void Update () {
        text.text = scoreText.Replace("[score]", scoreManager.Socre.ToString())
                             .Replace("[timeLeft]", gameManager.GameTimeLeft.ToString());
    }
}
