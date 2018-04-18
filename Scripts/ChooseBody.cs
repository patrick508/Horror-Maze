using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class ChooseBody : MonoBehaviour {

    public GameObject CubeStartRoom;
    public FirstPersonController FPC;
    public GameObject RandomBut;
    public GameObject EnterBut;
    public int speed;
    GameObject RandomHead;
    GameObject RandomBody;
    GameObject RandomFeet;

    public GameObject[] headParts;
    GameObject currentHead;
    int index;

    public GameObject[] bodyParts;
    GameObject currentBody;

    public GameObject[] feetParts;
    GameObject currentFeet;

    public GameObject CharCamera;
    public GameObject PlayerCam;
    void Start() {
        FPC.enabled = false;
        this.gameObject.GetComponent<Flashlight>().enabled = false;
        RandomHead = Instantiate(headParts[Random.Range(0, headParts.Length)], transform.position - Vector3.up, transform.rotation) as GameObject;
        RandomHead.transform.parent = transform;
        RandomBody = Instantiate(bodyParts[Random.Range(0, bodyParts.Length)], transform.position - Vector3.up, transform.rotation) as GameObject;
        RandomBody.transform.parent = transform;
        RandomFeet = Instantiate(feetParts[Random.Range(0, feetParts.Length)], transform.position - Vector3.up, transform.rotation) as GameObject;
        RandomFeet.transform.parent = transform;
    }

    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.down * speed * Time.deltaTime);
        }
    }
    public void EnterGame() {
        CharCamera.SetActive(false);
        this.gameObject.GetComponent<Flashlight>().enabled = true;
        FPC.enabled = true;
        PlayerCam.SetActive(true);
        this.transform.position = CubeStartRoom.transform.position;
        RandomBut.SetActive(false);
        EnterBut.SetActive(false);
    }

    public void RandomChar() {
        Destroy(RandomHead);
        Destroy(RandomBody);
        Destroy(RandomFeet);

        RandomHead = Instantiate(headParts[Random.Range(0, headParts.Length)], transform.position - Vector3.up, transform.rotation) as GameObject;
        RandomHead.transform.parent = transform;
        RandomBody = Instantiate(bodyParts[Random.Range(0, bodyParts.Length)], transform.position - Vector3.up, transform.rotation) as GameObject;
        RandomBody.transform.parent = transform;
        RandomFeet = Instantiate(feetParts[Random.Range(0, feetParts.Length)], transform.position - Vector3.up, transform.rotation) as GameObject;
        RandomFeet.transform.parent = transform;
    }
}
