using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SBook_Script : MonoBehaviour {


	//public GameObject Spell1, Spell2, Spell3, Spell4;
  	public SpellList Sp;   
    public Player pl_Script;
	public SpriteRenderer Sp1, Sp2, Sp3, Sp4;
    public TextMesh pt;
    public GameObject[] icones;
    public Sprite[] lockedIcons;
    public Sprite[] normalIcons;
    // Use this for initialization

    void Start()
    {
        pt.text = pl_Script.getScore().ToString();
        UpdateLocked();
       
    }

	void Update() {

		if(Input.GetKeyDown(KeyCode.Return)) {
			StartGame();
		}
		pt.text = "Experiencia: "+pl_Script.getScore().ToString();
	}

    public void StartGame()
    {       
		pl_Script.ComJogo();
		Sp.clean();
        Destroy(gameObject);
    }   

	public void UpdateSpellIcons() {

		Sp1.sprite = Sp.getS1Icon ();
		Sp2.sprite = Sp.getS2Icon ();
		Sp3.sprite = Sp.getS3Icon ();
		Sp4.sprite = Sp.getS4Icon ();

        UpdateLocked();
    }

    void UpdateLocked()
    {
        for (int i = 0; i < icones.Length; i++)
        {
            switch (i)
            {
                case 0:
                    if (PlayerPrefs.GetInt("IceShard") == 0)
                    {
                        icones[0].GetComponent<Button>().image.overrideSprite = lockedIcons[0];
                    }
                    else icones[0].GetComponent<Button>().image.overrideSprite = normalIcons[0];
                    break;
                case 1:
                    if (PlayerPrefs.GetInt("VineWall") == 0)
                    {
                        icones[1].GetComponent<Button>().image.overrideSprite = lockedIcons[1];
                    }
                    else icones[1].GetComponent<Button>().image.overrideSprite = normalIcons[1];
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("FrozenPool") == 0)
                    {
                        icones[2].GetComponent<Button>().image.overrideSprite = lockedIcons[2];
                    }
                    else icones[2].GetComponent<Button>().image.overrideSprite = normalIcons[2];
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("Blizzard") == 0)
                    {
                        icones[3].GetComponent<Button>().image.overrideSprite= lockedIcons[3];
                    }
                    else icones[3].GetComponent<Button>().image.overrideSprite = normalIcons[3];
                    break;
            }
        }
    }
}
