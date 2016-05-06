using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button : MonoBehaviour {

	GameObject Pl;
	Player pl_script;

	// Use this for initialization
	void Start () {
		Pl = GameObject.FindWithTag ("Player");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void StartGame()
	{
		Application.LoadLevel(2);
	}

	public void VoltarMainMenu() {
		Application.LoadLevel(0);
	}

	public void despausar() {
		Pl.GetComponent<Player>().PauseGame();

	}

	public void Reset()
	{
		PlayerPrefs.SetFloat("Score", 0.0f);
		PlayerPrefs.SetInt("IceShard", 0);
		PlayerPrefs.SetInt("VineWall", 0);
		PlayerPrefs.SetInt("FrozenPool", 0);
		PlayerPrefs.SetInt("Blizzard", 0);
	}
}

