using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Teleporters : MonoBehaviour {
    public GameObject Target;
    public Text PressButton;
    private bool On_TP = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //If i'm on the teleporter and press E, teleport my location to the target position
        if (Input.GetKeyDown(KeyCode.E) && On_TP == true) {
            World.Instance.Player.transform.position = Target.transform.position + new Vector3(0, .5f, 0); ;
        }
        }

    //If i'm on the teleporter, activate text PressButton
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {

            PressButton.gameObject.SetActive(true);
            On_TP = true;

        }     
    }

    //If i'm not on the teleporter, de-activate text PressButton
    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {

            PressButton.gameObject.SetActive(false);
            On_TP = false;

        }
    }
}
