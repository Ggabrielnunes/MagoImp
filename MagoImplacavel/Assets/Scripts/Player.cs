using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float vida;
	float Score;
    float castingTime;
	bool jogando;
    bool castingSpell;
	int onda;
	public GameObject PMenu;
	public GameObject pt;
    public GameObject AndBut;
    public AudioSource battleTheme;
    public AudioClip death;
    public Sprite[] magoStates;

    SpriteRenderer mageRenderer;   
    AudioSource soundsource;      
 

	void Start () {
        Score =  PlayerPrefs.GetFloat("Score");
		vida = 1000.0f;		
		jogando = false;
		PMenu.SetActive(false);
        castingSpell = false;
        Time.timeScale = 1.0f;
        castingTime = 1.0f;
        pt = GameObject.Find("VD");
        mageRenderer = GameObject.FindWithTag("Implacavel").GetComponent<SpriteRenderer>();
		pt.GetComponent<TextMesh>().text = "100";
        soundsource = GetComponent<AudioSource>();      

	

        
	}
	
	void Update () {	

        if(vida >= 0 && jogando == true && castingSpell)
        {
            castingTime -= Time.deltaTime;
            if(castingTime <= 0)
            {
                castingSpell = false;
                mageRenderer.sprite = magoStates[0];
            }
        }
		if (vida <= 0 && jogando == true) {
			jogando = false;
            battleTheme.Stop();
            soundsource.PlayOneShot(death);
            mageRenderer.sprite = magoStates[2];
            GameObject.Instantiate(Resources.Load("GameOver"));
            PlayerPrefs.SetFloat("Score", Score);
		}	

		if (Application.platform != RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Backspace)) {
			PauseGame();
		}
	}



	public void RecDamage(float d) {
		vida -= d;
		float VAtual = vida/10;
		pt.GetComponent<TextMesh>().text = VAtual.ToString();
	}

	public void setScore(float s) {
		Score += s;
	}

	public float getScore() {
		return Score;
	}

	public bool taJogando() {
		return jogando;
	}
	public void ComJogo() {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndBut.SetActive(true);
        }
        jogando = true;
	}

    public void IsCasting()
    {        
        mageRenderer.sprite = magoStates[1];
        castingSpell = true;
        castingTime = 1.0f;   
    }

	public void PauseGame() {

		if(jogando == true) {
			Time.timeScale = 0.0f;
			jogando = false;
			PMenu.SetActive(true);
            battleTheme.Pause();
		}
		else {
			Time.timeScale = 1.0f;
			jogando = true;
			PMenu.SetActive(false);
            battleTheme.UnPause();
		}
	}	
}
