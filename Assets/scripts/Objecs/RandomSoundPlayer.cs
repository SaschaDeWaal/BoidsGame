using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour {

    public AudioClip[] clips;
    public int minSecTime = 3;
    public int maxSecTime = 8;

    private AudioSource auidoSource;

    private void Start () {
        auidoSource = GetComponent<AudioSource>();

        if(clips.Length > 0) {
            StartCoroutine(AudioLoop());
        } else {
            Debug.LogWarning("RandomSoundPlayer -> " + gameObject.name + ": Doesn't have any audio clips listed");
        }
    }

    private IEnumerator AudioLoop() {

        //The range can start on 0 sec. So the game won't be silence for the first 3 seconds.
        int time = Random.Range(0, maxSecTime);

        while(gameObject.activeSelf) {

            yield return new WaitForSeconds(time);

            auidoSource.clip = clips[Random.Range(0, clips.Length)];
            auidoSource.Play();
            time = Random.Range(minSecTime, maxSecTime);
        }
    }
	
	
}
