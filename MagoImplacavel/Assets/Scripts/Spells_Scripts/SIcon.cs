using UnityEngine;
using System.Collections;

public class SIcon : MonoBehaviour {

	public float cargaAtual;
	private float cargaMaxima;
	private float barSize;
	public GameObject Sbar;



	// Use this for initialization
	void Start () {
		cargaAtual = 10.0f;
		cargaMaxima = 10.0f;

	}
	
	// Update is called once per frame
	void Update () {

		if (cargaAtual > cargaMaxima) {
			cargaAtual = cargaMaxima;	
		}

		if (cargaAtual < cargaMaxima) {
			setCargaS(1.0f*Time.deltaTime);
		}
	}

	public void setCargaS(float c) {
		cargaAtual += c;

		if (cargaAtual < 0)
			cargaAtual = 0;

		if (cargaAtual > cargaMaxima)
			cargaAtual = cargaMaxima;

		barSize = cargaAtual / cargaMaxima;

		Sbar.transform.localScale = new Vector3 (Sbar.transform.localScale.x, Mathf.Clamp (barSize, 0f, 1f), Sbar.transform.localScale.z);

	}

	public void setCargaMaxima(float ca) {
		cargaMaxima = ca;
	}

	public float getCargaS() {
		return cargaAtual;
	}
}
