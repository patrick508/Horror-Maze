using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Papers : MonoBehaviour {
    public Text ReadPaper;
    private bool Paper_Read = false;
    public static bool ClickPaper = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Als paper_read true is en je klikt op E, activeer bringupscroll van het World script, en zet de teller op van pages op 1
        if (Input.GetKeyDown(KeyCode.E) && Paper_Read == true) {
            ClickPaper = true;
            World.BringupScroll = true;
            StartCoroutine(WaitForPaper());
            World.Pages += 1;
            ReadPaper.gameObject.SetActive(false);
        }

    }
    //If i'm next to the paper, do x
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {

            ReadPaper.gameObject.SetActive(true);
            Paper_Read = true;
        }
    }
    //If i'm not next to the paper, do x
    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {

            ReadPaper.gameObject.SetActive(false);
            Paper_Read = false;

        }
    }

    //wait for x seconds and destroy paper
    IEnumerator WaitForPaper() {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(3);
        ClickPaper = false;
        Destroy(this.gameObject);
    }
}
