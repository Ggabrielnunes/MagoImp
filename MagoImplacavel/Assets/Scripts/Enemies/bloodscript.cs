using UnityEngine;
using System.Collections;

public class bloodscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position += new Vector3(0, 0, 1);
        Destroy(gameObject, 2.5f);
	}	
}
