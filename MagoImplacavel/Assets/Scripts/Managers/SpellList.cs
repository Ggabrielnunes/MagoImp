using UnityEngine;
using System.Collections;




public class SpellList : MonoBehaviour {

	public Spells[] escolhida;
	public GameObject Pl;
	public SBook_Script spellbook;
	Player plScript;

	float ComboTime;
    float spellCooldown;
	int[] liberada;
	int index1;
	int index2;
	bool sp2;
	bool sp3;
	bool usingAndSpells;

	GameObject spellText;
	GameObject buttonLiberar;

	Vector2 StartTouchPos;
	Vector3 StartMousePos;


	void Start () {

        usingAndSpells = false;//Bool usada para checar se o jogador está usando magia no Android
		escolhida = new Spells[4];	//cria novas magias
		
		//aloca a magia base em cada slot de magia:
		escolhida [0] = new Fireball();
		escolhida [1] = new Spectral ();
		escolhida [2] = new Explosion();
		escolhida[3] = new Meteor();
		
		spellbook.UpdateSpellIcons(); //Atualiza os icones das magias utilizadas
		//sp2 e sp3 usados para checar se está utilizando as magias 3 e 4. spellCooldown 
		sp2 = false;
		sp3 = false;
		spellCooldown = 0.0f;
		liberada = new int[10];       
		plScript = Pl.GetComponent<Player> ();

      }

	void Update() {	
		if(plScript.taJogando()) {

            if(usingAndSpells)
            {
                spellCooldown += Time.deltaTime;
                if(spellCooldown >= 0.5f)
                {
                    spellCooldown = 0.0f;
                    usingAndSpells = false;
                }
            }

			if (ComboTime > 0.0f) {
				ComboTime -= Time.deltaTime;
			} else {
				index1 = 0;
				index2 = 0;		
			}          

            if(Application.platform == RuntimePlatform.Android) {
                AndroidInputs();
            } else WindowsInputs ();


        }				
}

	void AndroidInputs() {
        
		if (Input.touchCount == 1)//checa se ouve somente um toque
		{
			Touch touch = Input.GetTouch(0);
			StartTouchPos = touch.position;//pega posição inicial do toque para testar se o usuário moveu o dedo

			//Utiliza magia 1 caso o usuário não tenha movido o dedo
			if (touch.phase == TouchPhase.Ended && escolhida[0].getCarg() >= escolhida[0].spellCost && touch.position == StartTouchPos) {
				escolhida [0].Usar ();
				escolhida[0].setCarga(-escolhida[0].spellCost);
                plScript.IsCasting();
			}
		
			//Utiliza magia 2 caso o usuário toque e arraste
			if(touch.phase == TouchPhase.Moved && escolhida[1].getCarg() >= 2.0f)
            {
				escolhida [1].Usar ();
				escolhida[1].setCarga (-(escolhida[1].spellCost * Time.deltaTime));
                plScript.IsCasting();
            }
            else escolhida[1].parar ();
		}

        if (Input.touchCount == 2)//checa se ouve dois toques
        {
            // Guarda dois toques.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Salva posições.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // checa tamanho entre os toques.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Calcula a diferença de tamanho quando usuário mexer os dedos.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			//por fim, usa magia 2 se o usuário afastou os dedos
            if(!usingAndSpells && deltaMagnitudeDiff < -2 && escolhida[2].getCarg() >= escolhida[2].spellCost)
            {
                escolhida[2].Usar();
                escolhida[2].setCarga(-(escolhida[2].spellCost));
                plScript.IsCasting();
                usingAndSpells = true;
            }
            if(!usingAndSpells && deltaMagnitudeDiff > 2 && escolhida[3].getCarg() >= escolhida[3].spellCost)
            {
                escolhida[3].Usar();
                escolhida[3].setCarga(-(escolhida[3].spellCost));
                plScript.IsCasting();
                usingAndSpells = true;
            }
        }

    }
	
	void WindowsInputs(){
		UsouSP2();
		UsouSP3();

		if(Input.GetMouseButtonDown(0))
			StartMousePos = Input.mousePosition;
		if (Input.GetMouseButtonUp (0) && escolhida [0].getCarg() >= escolhida[0].spellCost && Input.mousePosition == StartMousePos) {
			escolhida [0].Usar ();
            plScript.IsCasting();
            escolhida[0].setCarga(-escolhida[0].spellCost);
		} 
		
		if (Input.GetMouseButton(0) && escolhida [1].getCarg() > 2.0f  && Input.mousePosition != StartMousePos) {
			escolhida[1].setCarga (-(escolhida[1].spellCost * Time.deltaTime));
			escolhida [1].Usar ();
            plScript.IsCasting();
        } else escolhida[1].parar ();
		
		if (sp2 == true && escolhida [2].getCarg () >= escolhida [2].spellCost) {
			sp2 = false;
			escolhida [2].Usar ();
			escolhida [2].setCarga (-escolhida [2].spellCost);
            plScript.IsCasting();
        } else
			sp2 = false;
		
		if (sp3 == true && escolhida [3].getCarg () >= escolhida [3].spellCost) {
			sp3 = false;
			escolhida [3].Usar ();
			escolhida [3].setCarga (-escolhida [3].spellCost);
            plScript.IsCasting();
        } else
			sp3 = false;
	}



	void UsouSP2(){
		if(Input.GetKeyDown ("q") && index1 == 0) {
			ComboTime = 1.5f;
			index1++;
		} 
		if(Input.GetKeyDown ("w") && index1 == 1) {
			ComboTime = 1.5f;
			index1++;

		} 
		if(Input.GetKeyDown ("e") && index1 == 2) {
			sp2 = true;
			index1 = 0;
		} 
	}

	void UsouSP3() {
		if(Input.GetKeyDown("a") && index2 == 0) {
			ComboTime = 1.5f;
			index2++;
		}
		if(Input.GetKeyDown("s") && index2 == 1) {
			ComboTime = 1.5f;
			index2++;
		} 
		
		if(Input.GetKeyDown("d") && index2 == 2) {
			ComboTime = 1.5f;
			index2++;
		} 
		
		if (Input.GetKeyDown ("f") && index2 == 3) {
			sp3 = true;
			index2 = 0;
		}
	}
	public void SelectClickSpell(int s){
		clean ();
		switch(s){
		case 0:
			spellText = GameObject.Instantiate(Resources.Load("SpellTexts/FireballText")) as GameObject;
			Destroy(escolhida [0].icon);		
			escolhida[0] = new Fireball();
			spellbook.UpdateSpellIcons();
			break;

		case 1:
			spellText = GameObject.Instantiate(Resources.Load ("SpellTexts/IceShardText")) as GameObject;
			if (liberada [0] == 1) {
				Destroy (escolhida [0].icon);		
				escolhida [0] = new IceShard ();
				spellbook.UpdateSpellIcons ();
			} else {
				buttonLiberar = GameObject.Instantiate(Resources.Load("ButC")) as GameObject;
				buttonLiberar.GetComponent<CompItem>().setSpSelec(0);
			}
			break;
		}
	}

	public void SelectDragSpell(int s){
		clean();
		switch(s){
		case 0:
			spellText = GameObject.Instantiate(Resources.Load ("SpellTexts/SpectralSwordText")) as GameObject;
			Destroy(escolhida [1].icon);		
			escolhida[1] = new Spectral();
			spellbook.UpdateSpellIcons();
			break;
		case 1:
			spellText = GameObject.Instantiate(Resources.Load ("SpellTexts/VineWallText")) as GameObject;
			if (liberada [1] == 1) {
				Destroy(escolhida [1].icon);		
				escolhida [1] = new VineWall ();
				spellbook.UpdateSpellIcons();
			} else {
				buttonLiberar = GameObject.Instantiate(Resources.Load("ButC")) as GameObject;
				buttonLiberar.GetComponent<CompItem>().setSpSelec(1);
			}
			break;
		}
	}

	public void SelectOutSpell(int s){
		clean ();
		switch(s){
		case 0:		
			spellText = GameObject.Instantiate(Resources.Load ("SpellTexts/ExplosionText")) as GameObject;
			Destroy(escolhida [2].icon);		
			escolhida[2] = new Explosion();
			spellbook.UpdateSpellIcons();
			break;
		case 1:
			spellText = GameObject.Instantiate(Resources.Load ("SpellTexts/IcePoolText")) as GameObject;
			if (liberada [2] == 1) {
				Destroy(escolhida [2].icon);		
				escolhida [2] = new IcePool ();
				spellbook.UpdateSpellIcons();
			} else {
				buttonLiberar = GameObject.Instantiate(Resources.Load("ButC")) as GameObject;
				buttonLiberar.GetComponent<CompItem>().setSpSelec(2);
			}
			break;
		}

	}

	public void SelectInSpell(int s){
		clean();
		switch(s){
		case 0:
			spellText = GameObject.Instantiate(Resources.Load ("SpellTexts/MeteorText")) as GameObject;
			Destroy(escolhida [3].icon);		
			escolhida[3] = new Meteor();
			spellbook.UpdateSpellIcons();
			break;
		case 1:
			spellText = GameObject.Instantiate(Resources.Load ("SpellTexts/BlizzardText")) as GameObject;
			if (liberada [3] == 1) {
				Destroy(escolhida [3].icon);		
				escolhida [3] = new Blizzard ();
				spellbook.UpdateSpellIcons();
			} else {

				buttonLiberar = GameObject.Instantiate(Resources.Load("ButC")) as GameObject;
				buttonLiberar.GetComponent<CompItem>().setSpSelec(3);
			}
			break;
		}
	}



	public Sprite getS1Icon(){
		return escolhida[0].icon.GetComponent<SpriteRenderer>().sprite;
	}

	public Sprite getS2Icon(){
		return escolhida[1].icon.GetComponent<SpriteRenderer>().sprite;
	}

	public Sprite getS3Icon(){
		return escolhida[2].icon.GetComponent<SpriteRenderer>().sprite;
	}

	public Sprite getS4Icon(){
		return escolhida[3].icon.GetComponent<SpriteRenderer>().sprite;
	}

	public void comprarSpell(int s) {
		switch (s) {
		case 0:
			if(plScript.getScore() >= 100.0f) {
				liberada[0] = 1;
				plScript.setScore(-100.0f);
				PlayerPrefs.SetFloat("Score", plScript.getScore());
				PlayerPrefs.SetInt("IceShard", 1);
				SelectClickSpell(1);				;
			}
			break;
		case 1:
			if(plScript.getScore() >= 200.0f) {
				liberada[1] = 1;
				plScript.setScore(-200.0f);
				PlayerPrefs.SetFloat("Score", plScript.getScore());
				PlayerPrefs.SetInt("VineWall", 1);
				SelectDragSpell(1);
			}
			break;
		case 2:
			if(plScript.getScore() >= 300.0f) {
				liberada[2] = 1;
				plScript.setScore(-300.0f);
				PlayerPrefs.SetFloat("Score", plScript.getScore());
				PlayerPrefs.SetInt("FrozenPool", 1);
				SelectOutSpell(1);
			}
			break;
		case 3:
			if(plScript.getScore() >= 500.0f) {
				liberada[3] = 1;
				plScript.setScore(-500.0f);
				PlayerPrefs.SetFloat("Score", plScript.getScore());
				PlayerPrefs.SetInt("Blizzard", 1);
				SelectInSpell(1);
			}
			break;
		}
	}

	public void clean() {
		Destroy (spellText);
		Destroy (buttonLiberar);
	}

}

