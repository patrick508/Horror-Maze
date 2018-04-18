using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flashlight : MonoBehaviour {
    public GameObject flashlightObj;
    private Light flashlight;
    private float FlashBattery = 1f;
    public AudioClip flashswitch;
    private AudioSource audioSource;
    // Use this for initialization
    void Start() {
        flashlight = flashlightObj.GetComponent<Light>();
        flashlight.enabled = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        //If mouse1 is clicked turn flashlight on and off.
        if (Input.GetKeyDown(KeyCode.Mouse1) && flashlight.enabled == false) {
            AudioSource.PlayClipAtPoint(flashswitch, transform.position);
            flashlight.enabled = true;
        } else if (Input.GetKeyDown(KeyCode.Mouse1) && flashlight.enabled == true) {
            AudioSource.PlayClipAtPoint(flashswitch, transform.position);
            flashlight.enabled = false;
        }

        //If flashlight isnt active restore x amount of battery every frame.
        if (flashlight.enabled == false && FlashBattery <= 1) {
            FlashBattery = FlashBattery + 0.0040f;
            flashlight.intensity = 8f;
        }

        //If flashlight is active lower with x amount of battery every frame.
        if (flashlight.enabled == true && FlashBattery >= 0) {
            FlashBattery = FlashBattery - 0.00020f;
        }

        //If FlashBattery has a value of 0.
        if (FlashBattery <= 0) {
           // flashlight.intensity = 0;
            flashlight.enabled = false;
        }

        //When FlashBattery is lower than x amount start randomly blinking between giving values.
        else if (FlashBattery < 0.1f && Random.Range(0, 100) < map(FlashBattery, 0.1f, 0f, 70f, 1f)) {
            flashlight.intensity = Random.Range(2.0f, 8.0f);
        }

      //  print(FlashBattery);
    }

        //Needed for the random range intensity
   float map(float s, float a1, float a2, float b1, float b2) {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
