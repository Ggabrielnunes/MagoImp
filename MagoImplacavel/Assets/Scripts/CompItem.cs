using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompItem : MonoBehaviour {

	int Selecionada;
	public Text button;
    Camera gamecam;

    void Start()
    {
        Canvas c = GetComponent<Canvas>();
        gamecam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        c.worldCamera = gamecam;

    }

	public void CompraSpell() {
		GameObject.FindWithTag ("Grimorio").GetComponent<SpellList> ().comprarSpell (Selecionada);
	}

	public void setSpSelec(int s) {
		Selecionada = s;
	switch(s){
		case 0:
			button.text = "Comprar - 100xp";
			break;
		case 1:
			button.text= "Comprar - 200xp";
			break;
		case 2:
			button.text= "Comprar - 300xp";
			break;
		case 3:
			button.text = "Comprar - 500xp";
			break;
		}
	}
}
