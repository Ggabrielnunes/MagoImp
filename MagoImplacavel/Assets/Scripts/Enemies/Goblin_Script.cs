using UnityEngine;
using System.Collections;

public class Goblin_Script : Enemy {

		float atkSpeed;
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

        vida = 90.0f;
		attack = 30.0f;
		Pont = 10.0f;

		enemyPress = 10;

		atkSpeed = 0f;
        isSlowed = false;
        moving = true;
		pAtacar = true;

        if (Application.platform == RuntimePlatform.Android) StartingSpeed.Set(0.0f, 7f);
        else StartingSpeed.Set(0.0f, 30.0f);

        speed = StartingSpeed;

		Spw_Script.setPress(enemyPress);
	}
	
	public override void Update () {		
		anim.SetFloat ("Health", vida);		
		
		if(vida <= 0) {

			Kill ();
		} 
		
		if(vida > 0 && moving == true){
			rb2D.MovePosition(rb2D.position + speed *Time.deltaTime);
		}	

		if (atkSpeed >= 0.0f && pAtacar == false) {		
			atkSpeed -= 1.0f * Time.deltaTime;
		} else {
			pAtacar = true;
			atkSpeed = 1.0f;
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
			rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
			if(pAtacar == true && mur.taJogando()) {
				mur.RecDamage(attack);
                soundsource.PlayOneShot(atacar, 0.5f);
                Instantiate(dmgToWall, transform.position, Quaternion.identity);
				pAtacar = false;
			}
		}
	}
}
