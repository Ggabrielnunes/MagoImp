using UnityEngine;
using System.Collections;

public class Pause_Script : MonoBehaviour {

	GameObject Pl;
	Player pl_Script;

	public TextMesh pt;

	// Use this for initialization
	void Start () {
		Pl = GameObject.FindWithTag ("Player");
		pl_Script = Pl.gameObject.GetComponent<Player> ();
	
        
		pt.text = "Pontuaçao Atual: 0";	
	}

	void Update() {
		pt.text = "Pontuaçao Atual: " + pl_Script.getScore ().ToString();	
	}
}
