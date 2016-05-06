using UnityEngine;
using System.Collections;

public class FireB : MonoBehaviour {

	private float mSpeed;
	private Vector3 dir;
	private Vector3 startPos;

	// Use this for initialization
	void Start () {

		mSpeed = 2.0f;
		dir = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
		dir = Camera.main.ScreenToWorldPoint(dir);
		startPos = transform.position;
		Destroy (gameObject, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (dir - startPos) * mSpeed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Enemy") {
			GameObject.Destroy (gameObject);
		}
	}
}
