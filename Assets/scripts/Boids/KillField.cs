using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillField : MonoBehaviour {

    private const string SHEEP_TAG = "sheep";

    private ScoreManager scoreManager;
    private AudioSource audioSource;

    private void Start() {
        scoreManager = ManagerObject.Find<ScoreManager>();
        audioSource  = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == SHEEP_TAG) {
            collision.gameObject.SetActive(false);
            scoreManager.AddScore(1);
            audioSource.Play();
        }
    }

}
