using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour {
    public Light flickerlight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        LightFlicker();
	}
    //Load world
    public void LoadGame() {
        SceneManager.LoadScene("Game_World");
    }

    //Quit game
    public void ExitGame() {
        Application.Quit();
    }
    //Make 2 lights randomly flicker
    void LightFlicker() {
        if (Random.value > 0.9) {
            if (flickerlight.enabled == true) {
                flickerlight.enabled = false;
            }
            else {
                flickerlight.enabled = true;
            }
        }
    }
}
