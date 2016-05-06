using UnityEngine;
using System.Collections;

public class AndButScript : MonoBehaviour {

	Player pl;
	
	void Start () {
		pl = GameObject.FindWithTag ("Player").GetComponent<Player> ();
	}
	
	public void pause() {
		pl.PauseGame ();
	}
}
