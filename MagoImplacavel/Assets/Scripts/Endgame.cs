
using UnityEngine;
using System.Collections;

public class Endgame : MonoBehaviour {

	GameObject Pl;
	float PAtual;
	Player pl_Script;

	public TextMesh pt;

	// Use this for initialization
	void Start () {
		Pl = GameObject.FindWithTag ("Player");
		pl_Script = Pl.gameObject.GetComponent<Player>();
		PAtual = pl_Script.getScore();
		pt.text = "Pontos: " + PAtual.ToString();
	}
}
