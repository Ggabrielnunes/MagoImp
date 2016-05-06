using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IEnemy, IDmg<float> {

	public Animator anim;
	public Player mur;
	public Spawner Spw_Script;
    public AudioSource soundsource;
   
    public AudioClip atacar, death;

	public GameObject Spw;
	public GameObject Pl;
    public GameObject bloodsp;
    public GameObject dmgToWall;
	public Rigidbody2D rb2D;

	public Vector2 speed;
	public Vector2 StartingSpeed;

	public bool moving;
    public bool isSlowed;

	public float vida;
	public float Pont;
	public float attack;
    public float slowTimer;

	public int enemyPress;

	public virtual void Start() {
	
	}

	public virtual void Update() {

	}

	public void Slow() {
        slowTimer = 5.0f;
		speed = StartingSpeed/2;
        isSlowed = true;
	}   

	public virtual void Kill() {
		rb2D.isKinematic = true;
      
        if (!soundsource.isPlaying)
            soundsource.PlayOneShot(death);

		Destroy(gameObject, 1.0f);
	}
	
	public void ApplyDamage(float Dmg) {
		vida -= Dmg;
        Instantiate(bloodsp, transform.position, Quaternion.identity);
	}

	void OnDestroy() {
		mur.setScore (Pont);
		Spw_Script.setEn ();
		Spw_Script.setPress(-enemyPress);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "FrozenPool" || other.gameObject.tag == "Blizzard")
			Slow();
		if(other.gameObject.tag == "Blizzard"){
			ApplyDamage(30.0f*Time.deltaTime);
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "FrozenPool" || other.gameObject.tag == "Blizzard")
			walkNormal();
	}
	public void walkNormal(){
		speed = StartingSpeed;
        isSlowed = false;
        slowTimer = 0.0f;
	}



}

public interface IEnemy {
	void Kill();
	void Slow();
}

public interface IDmg<T> {
	void ApplyDamage(T Dmg);
}