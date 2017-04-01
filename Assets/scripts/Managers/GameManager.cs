using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private const int GAME_TIME = 60;

    private BoidsManager boidsManager;
    private ScoreManager scoreManager;
    private GameObject   menu;
    private GameObject   player;

    private float startTime = 0;

	private void Start () {
        boidsManager = ManagerObject.Find<BoidsManager>();
        scoreManager = ManagerObject.Find<ScoreManager>();
        menu         = GameObject.FindGameObjectWithTag("Menu");
        player       = GameObject.FindGameObjectWithTag("Player");

        startTime    = Time.time;
    }

    public void StartNewGame(int sheepsAmount) {
        player.SetActive(true);
        scoreManager.Reset();
        boidsManager.Create(sheepsAmount);
        menu.SetActive(false);
        

        Cursor.visible = false;
        startTime      = Time.time;

        StartCoroutine(GameLoop());
    }

    public int GameTimeLeft {
        get {
            return Mathf.RoundToInt(GAME_TIME - (Time.time - startTime));
        }
    }

    public void StopGame() {
        StopCoroutine("GameLoop");
        boidsManager.Clear();
        menu.SetActive(true);
        Cursor.visible = true;
        player.SetActive(false);
    }

    private IEnumerator GameLoop() {
        yield return new WaitForSeconds(GAME_TIME);
        StopGame();
    }
}
