using UnityEngine;
using System.Collections;

public class MeoR : MonoBehaviour {

	public float mSpeed;
	public Vector3 dir;
	public Vector3 dir2;
	public DmgS Scri;
	GameObject MtExp;

	// Use this for initialization
	void Start () {


		mSpeed = 10.0f;
		dir = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
		dir2 = new Vector3(Input.mousePosition.x, 500, 10);
		dir = Camera.main.ScreenToWorldPoint(dir);
		dir2 = Camera.main.ScreenToWorldPoint(dir2);
		transform.position = dir2;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, dir, mSpeed*Time.deltaTime);
			if (transform.position == dir)
			{
				MtExp = (GameObject)GameObject.Instantiate(Resources.Load("Magias/Meteor_Explosion"));
				MtExp.transform.position = dir;

				MtExp.gameObject.GetComponent<DmgS>().damg = 90.0f;

				Destroy(MtExp, 1.0f);
				Destroy(gameObject);
			}
	}
}
