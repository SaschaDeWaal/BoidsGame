using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private int score = 0;

    public int Socre {
        get {
            return score;
        }
    }

	public void AddScore(int amount) {
        score++;
    }

    public void Reset() {
        score = 0;
    }
}
