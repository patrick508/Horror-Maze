using UnityEngine;
using System.Collections;

public class RandomAudio : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] clips;
    private int clipIndex;
    private bool audioPlaying = false;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySound());
    }
	
	// Update is called once per frame
	void Update () {

        }
    //Play random sound every between every x to x seconds.
    IEnumerator PlaySound() {
        yield return new WaitForSeconds(Random.Range(1f, 150f));
        int randomClip = Random.Range(0, clips.Length);
        audioSource.clip = clips[randomClip];
        audioSource.Play();

        StartCoroutine(PlaySound());
    }
}
