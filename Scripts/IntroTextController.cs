using UnityEngine;
using System.Collections;

public class IntroTextController : MonoBehaviour {
    private float castRange = 8f;

    public GameObject FirstText;
    public GameObject Secondtext;
    private AudioSource audioSource;
    private bool TextChange = false;
    private bool WallChange = false;

    public GameObject Wall_Down;
    public AudioClip woosh;
    public AudioClip wall_slide;

    private bool FirstWallCheck;

    // Use this for initialization
    void Awake () {
        audioSource = GetComponent<AudioSource>();
    }
    void Update() {

        //If TextChange is false, cast a ray and check if it hits tag "TriggerWall" 
        //Set FirstwallCheck on true if you look at the first wall.
        if (TextChange == false) {
            RaycastHit hit = new RaycastHit();
            Debug.DrawRay(transform.position, this.transform.forward * 8, Color.red);
            if (Physics.Raycast(transform.position, this.transform.forward, out hit, castRange)) {
                if (hit.collider.tag == "TriggerWall") {
                    FirstWallCheck = true;
                }
            }
        }

        //If TextChange is false en FirstWallCheck is true, cast a ray and check if it hits tag "TriggerText" 
        //If yes, change First and Second Text and play sound.
        if (TextChange == false && FirstWallCheck == true) {
            RaycastHit hit = new RaycastHit();
           Debug.DrawRay(transform.position, this.transform.forward * 8, Color.red);
            if (Physics.Raycast(transform.position, this.transform.forward, out hit, castRange)) {
                if (hit.collider.tag == "TriggerText") {
                    Debug.Log("Text, Change!");
                    FirstText.gameObject.SetActive(false);
                    Secondtext.gameObject.SetActive(true);
                    AudioSource.PlayClipAtPoint(woosh, this.transform.position);
                    TextChange = true;
                }
            }
        }
        //If Textchange is true and the raycast hits the tagg TriggerWall make the wall move
        if (TextChange == true && WallChange == false) {
            RaycastHit hit = new RaycastHit();
          //  Debug.DrawRay(transform.position, this.transform.forward * 8, Color.red);
            if (Physics.Raycast(transform.position, this.transform.forward, out hit, castRange)) {
                Debug.Log("Almost....");
                if (hit.collider.tag == "TriggerWall") {
                    Debug.Log("Muur omlaag!");
                    WallChange = true;
                    AudioSource.PlayClipAtPoint(wall_slide, this.transform.position);
                    iTween.MoveTo(Wall_Down, iTween.Hash("path", iTweenPath.GetPath("MoveDown"), "Time", 10));
                    StartCoroutine(Waitfortext());
                    //iTween.MoveTo(Wall_Down, iTween.Hash("x", 3, "time", 10, "delay", 1, "onupdate", "myUpdateFunction", "looptype", iTween.LoopType.pingPong));
                    //Wall_Down.transform.Translate(Wall_Down.transform.position.x, Wall_Down.transform.position.y -0.5f * Time.deltaTime, Wall_Down.transform.position.z);
                }
            }
        }
    }
    IEnumerator Waitfortext() {
        yield return new WaitForSeconds(3);
        Secondtext.gameObject.SetActive(false);
    }
}
