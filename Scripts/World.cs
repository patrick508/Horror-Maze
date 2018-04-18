using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class World : MonoBehaviour {

    public static World Instance;
    public GameObject Player;
    public static int Pages = 0;
    public Text PagesCollected;
    public static bool BringupScroll = false;
    public Image ScrollBackground;
    public Text ScrollText;
    void Awake() {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //Als bringupscroll true is, activeer note met de text
	        if (BringupScroll == true) {
               ScrollBackground.gameObject.SetActive(true);
               ScrollText.gameObject.SetActive(true);
#region ScrollText
            if (Pages == 1) {
                ScrollText.text = " I think I’m lost…. I have no idea how long I’m in here.\n" +
 " I hear weird sounds and I’ve been seeing weird things.\n" +
 " I’ve heard walls moving and I’ve seen strange creatures.\n" +
 "\n" +
 " Is it real? Or am I just slowly turning insane? \n" +
 " I don’t know… But it’s too late to go back! \n" +
 " I must continue to search for George his treasure!\n";
            }

            if (Pages == 2) {
                ScrollText.text = " I just wish George was here right now….\n" +
 " I haven’t had food or water in ages. \n" +
 " How much longer will my body be able to survive? \n" +
 " How much longer do I have to be here? \n" +
 " Will I ever find a way out? \n" +
 " So many questions, yet no answers.\n";
            }

            if (Pages == 3) {
                ScrollText.text = " They say those who get to greedy for the treasure will never find it.\n" +
 " They will get so caught up in their own greed they will never find an exit. \n" +
 " But i.. I just need this treasure… \n" +
 " George has been robbed by his family, friends and merchants so many times… Poor man must’ve been so paranoid. \n" +
 "\n" +
 " At this point I’m just hoping this treasure is worth searching for. What if it’s one big disappointment?  \n" +
 " What if there’s no treasure at all?!\n" +
 " No… ofcourse there’s a treasure! there must be!\n" +
 " Let’s just keep searching…\n";
            }
            #endregion
            //Als je op escape klikt, sluit de note af en zet bringupscroll weer op false
            if (Input.GetKeyDown(KeyCode.Escape)){
                    ScrollBackground.gameObject.SetActive(false);
                    ScrollText.gameObject.SetActive(false);
                    BringupScroll = false;
            }
        } 
	}

    void OnGUI() {
        if (Papers.ClickPaper) {
            PagesCollected.gameObject.SetActive(true);
            PagesCollected.text = Pages + "/3 pages collected";
        }
        else {
            PagesCollected.gameObject.SetActive(false);
        }
    }
}