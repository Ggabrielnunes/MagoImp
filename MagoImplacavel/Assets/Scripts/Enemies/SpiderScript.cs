using UnityEngine;
using System.Collections;

public class SpiderScript : Enemy {

	float atkSpeed;
	float walkingTime;

	int Direction;

	bool pAtacar;

	public override void Start () {
		
		anim = GetComponent<Animator> ();
		rb2D = GetComponent<Rigidbody2D>();
        soundsource = GetComponent<AudioSource>();
		Pl = GameObject.FindWithTag ("Player");
		mur = Pl.gameObject.GetComponent<Player> ();
		
		Spw = GameObject.FindWithTag ("SpawnObj");
		Spw_Script = Spw.gameObject.GetComponent<Spawner>();

        bloodsp = Resources.Load("Enemies/blood") as GameObject;
        dmgToWall = Resources.Load("WallDamage") as GameObject;

        vida = 500.0f;
		walkingTime = 1.5f;
		Pont = 100.0f;
		attack = 40.0f;
		atkSpeed = 0f;	

		moving = true;
		pAtacar = true;

		Direction = 0;
		enemyPress = 20;
        isSlowed = false;

        if (Application.platform == RuntimePlatform.Android) StartingSpeed.Set(0.0f, 5f);
        else StartingSpeed.Set(0.0f, 10.0f);

        speed = StartingSpeed;

		Spw_Script.setPress(enemyPress);
	}
	
	public override void Update () {	

		anim.SetFloat ("Health", vida);	
		if(walkingTime <= 0) {
			Direction = Random.Range(0, 2);
			anim.SetInteger("Direction",Direction);
			switch(Direction) {
			case 0 :
                    if (Application.platform == RuntimePlatform.Android)
                        StartingSpeed.Set(0.0f, 5f);
                    else StartingSpeed.Set(0.0f, 30f);
				break;			
			case 1:
                    if (Application.platform == RuntimePlatform.Android)
                        StartingSpeed.Set(-5.0f, 5f);
                    else StartingSpeed.Set(-5.0f, 30f);
                    break;
			case 2:
                    if (Application.platform == RuntimePlatform.Android)
                        StartingSpeed.Set(5.0f, 5f);
                    else StartingSpeed.Set(5.0f, 30f);
                    break;
			}
			if(!isSlowed) speed = StartingSpeed;
			walkingTime =1.5f;

		} else walkingTime -= Time.deltaTime;


		if(vida <= 0) {			
			Kill ();
		} 
		
		if(vida > 0 && moving == true){
			rb2D.MovePosition(rb2D.position + speed *Time.deltaTime);		
		}	
		
		if (atkSpeed >= 0.0f && pAtacar == false) {		
			atkSpeed -= Time.deltaTime;
		} else {
			pAtacar = true;
			atkSpeed = 0.5f;
		}
		
		if (isSlowed)
		{
			slowTimer -= Time.deltaTime;
			if (slowTimer <= 0.0f)
			{
				walkNormal();
			}
		}
	}
	
	public void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.name == "Muralha") {
			anim.SetBool("Atacando", true);
			rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
			if(pAtacar == true && mur.taJogando()) {
				mur.RecDamage(attack);
                Instantiate(dmgToWall, transform.position, Quaternion.identity);
                soundsource.PlayOneShot(atacar);
				pAtacar = false;
			}
		}
		if(other.gameObject.name == "ParedeEsquerda") {
			Direction = 2;
			StartingSpeed.Set(5.0f,5f);
			if(!isSlowed) speed = StartingSpeed;
		}
		if(other.gameObject.name == "ParedeDireita") {
			Direction = 1;
			StartingSpeed.Set(-5.0f,5f);
			if(!isSlowed) speed = StartingSpeed;
		}
	}
}
