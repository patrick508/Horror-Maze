using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventController : MonoBehaviour {
    public GameObject skeleton;
    private bool Move = false;
    public AudioClip Scare;
    public GameObject Skeletwall;

    private AudioSource audioSource;

    public AudioClip Wall_Slide;
    public GameObject TP2Wall;
    public GameObject TP3Wall;
    public GameObject TP2WallExtra;
    public GameObject TP3WallExtra;
    public Text tp2text;
    public Text tp3text;

    public Light flickerlight;
    public Light flickerlight2;
    public Light flashlight;

    public GameObject Skull;
    private bool activateSkull = false;
    public AudioClip GhostCry;

    public AudioClip Footsteps;
    private bool PlaySteps = false;

    public AudioClip Wolf_Howl;
    private bool PlayWolf = false;

    public GameObject coin;
    public GameObject eyes;

    public GameObject wallscare;
    public GameObject wallscareslow;
    private bool wallscareready = false;
    public GameObject crawler;
    private bool Crawlerwalk = false;
    public AudioClip Crawlersound;

    public Text EndgameText;
    public GameObject Walleyes;
    private bool EndGame = false;
    public AudioClip Eye_Sound;

    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController FPScontroller;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        FPScontroller = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update() {
        SkeletMove();
        LightFlicker();
        SkullFly();
        if (Crawlerwalk == true) {
            crawler.transform.position += Vector3.forward * Time.deltaTime * 1.5f;
        }
        if (Input.GetKeyDown(KeyCode.E) && EndGame == true) {
            SceneManager.LoadScene("Game_Menu");
        }
    }

    #region Ontriggerenter
    //If i hit the wall, play sound and disable FPS controller
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("TriggerSkeleton")) {
            audioSource.volume = 1f;
            AudioSource.PlayClipAtPoint(Scare, transform.position);
            FPScontroller.StaminaCounter = 0;
            FPScontroller.m_WalkSpeed = 1.5f;
            Move = true;
        }

        // if tag is tag x do .....
        if (other.gameObject.CompareTag("wallscare")) {
            Destroy(wallscare);
            crawler.gameObject.SetActive(true);
            wallscareslow.gameObject.SetActive(true);
            Crawlerwalk = true;
            AudioSource.PlayClipAtPoint(Crawlersound, this.transform.position);
        }
        // if tag is tag x, destroy wall 1 and spawn wall 2
        if (other.gameObject.CompareTag("wallscareslow")) {
            FPScontroller.m_WalkSpeed = 1.5f;
            StartCoroutine(WaitforScrawler());
        }
        // if tag is tag x, destroy wall and play sound to unlock the second teleporter
        if (other.gameObject.CompareTag("Teleporter2wall")) {
            tp2text.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(Wall_Slide, TP2Wall.transform.position);
            Destroy(TP2Wall);
            Destroy(TP2WallExtra);
            StartCoroutine(TeleporterText2());
        }

        // if tag is tag x, destroy wall and play sound to unlock the second teleporter
        if (other.gameObject.CompareTag("Teleporter3wall")) {
            tp3text.gameObject.SetActive(true);
            Destroy(TP3WallExtra);
            Destroy(TP3Wall);
            AudioSource.PlayClipAtPoint(Wall_Slide, TP3Wall.transform.position);
            StartCoroutine(TeleporterText3());
        }

        // if tag is tag x, and you press E, game ends.
        if (other.gameObject.CompareTag("Chest")) {
            EndGame = true;
            EndgameText.gameObject.SetActive(true);
        }
            //turn the flashlight and its script off
            if (other.gameObject.CompareTag("Flashlight_Off")) {
            flashlight.enabled = false;
            this.GetComponent<Flashlight>().enabled = false;
        }
        //turn the flashlight and its script back on
        if (other.gameObject.CompareTag("Flashlight_On")) {
            flashlight.enabled = true;
            this.GetComponent<Flashlight>().enabled = true;
        }

        //Make the coin active so it falls
        if (other.gameObject.CompareTag("TriggerCoin")) {
            coin.gameObject.SetActive(true);
        }
            //Slow movement speed.
            if (other.gameObject.CompareTag("TriggerEyes")) {
            eyes.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(Eye_Sound, eyes.transform.position);
            FPScontroller.StaminaCounter = 0;
            FPScontroller.m_WalkSpeed = 1.5f;
            StartCoroutine(SpeedEyes());
        }
        if (other.gameObject.CompareTag("TriggerEyes2")) {
            eyes.gameObject.SetActive(false);
        }
        //Activate void SkullFly();
        if (other.gameObject.CompareTag("TriggerSkul")) {
                if (!activateSkull) {
                AudioSource.PlayClipAtPoint(GhostCry, transform.position);
                    activateSkull = true;
                }
            }

            //If you hit something with this tag, play sound than put bool to true so it cant play again
            if (other.gameObject.CompareTag("TriggerWolf")) {
                if (!PlayWolf) {
                    AudioSource.PlayClipAtPoint(Wolf_Howl, flickerlight.transform.position);
                    PlayWolf = true;
                }
            }
            //If you hit something with this tag, play sound than put bool to true so it cant play again
            if (other.gameObject.CompareTag("TriggerFootsteps")) {
                if (!PlaySteps) {
                    AudioSource.PlayClipAtPoint(Footsteps, transform.position);
                    PlaySteps = true;
                }
            }
        }

    #endregion Ontriggerenter
    //If i'm not next to this tagg do x
    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Chest")) {
            EndgameText.gameObject.SetActive(false);
        }
    }
    #region IEnumerators
    //wait for x seconds and destroy skeleton and wall and enable FPS Controller again
    IEnumerator Waitforskelet() {
        yield return new WaitForSeconds(3);
        Destroy(Skeletwall);
        Destroy(skeleton);
        audioSource.volume = 0.3f;
        FPScontroller.m_WalkSpeed = 5f;
        FPScontroller.StaminaCounter = 1f;

    }

    //wait for x seconds and destroy skeleton and wall and enable FPS Controller again
    IEnumerator TeleporterText2() {
        yield return new WaitForSeconds(4);
        Destroy(tp2text);
    }
    IEnumerator TeleporterText3() {
        yield return new WaitForSeconds(4);
        Destroy(tp3text);
    }

    IEnumerator WaitforScrawler() {
        yield return new WaitForSeconds(4);
        Destroy(crawler);
        Destroy(wallscareslow);
        Destroy(wallscare);
        FPScontroller.m_WalkSpeed = 5f;
        FPScontroller.StaminaCounter = 1f;

    }
    IEnumerator SpeedEyes() {
        yield return new WaitForSeconds(2);
        Destroy(eyes);
        Destroy(Walleyes);
        FPScontroller.m_WalkSpeed = 5f;
        FPScontroller.StaminaCounter = 1f;
    }
    #endregion

    //move skeleton forward and start Coroutine
    void SkeletMove() {
        if (Move == true) {
            skeleton.transform.position += Vector3.forward * Time.deltaTime * 2.2f;
            StartCoroutine(Waitforskelet());
        }
    }

    //Make 2 lights randomly flicker
    void LightFlicker() {
        if (Random.value > 0.9){
            if (flickerlight.enabled == true){
                flickerlight.enabled = false;
            }else {
                flickerlight.enabled = true;
            }
        }

        if (Random.value > 0.9){
            if (flickerlight2.enabled == true){
                flickerlight2.enabled = false;
            }else {
                flickerlight2.enabled = true;
            }
        }
    }

    //Make Skull fly toward player
    void SkullFly() {
        if (activateSkull == true) {
            Skull.transform.position += Vector3.back * Time.deltaTime * 25;
            Invoke("DeleteSkull", 3.0f);
        }
    }

    void DeleteSkull() {
       Destroy(Skull);
    }
}
