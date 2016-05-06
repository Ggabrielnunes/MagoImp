using UnityEngine;
using System.Collections;

public class walld : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position += new Vector3 (0.5f,0.5f,0);
        Destroy(gameObject, 1);
	}
	
	
}
