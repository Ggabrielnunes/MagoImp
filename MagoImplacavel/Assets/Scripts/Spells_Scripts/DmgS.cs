﻿using UnityEngine;
using System.Collections;

public class DmgS : MonoBehaviour {

	public float damg;


	public void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<IDmg<float>>().ApplyDamage(damg);
		}
	}
}
