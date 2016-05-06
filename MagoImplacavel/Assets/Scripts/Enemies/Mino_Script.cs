using UnityEngine;
using System.Collections;

public class Mino_Script : Enemy {

    public float atkSpeed;
    public bool pAtacar;

    public override void Start()
    {

		anim = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
        soundsource = GetComponent<AudioSource>();

		Pl = GameObject.FindWithTag("Player");
		mur = Pl.gameObject.GetComponent<Player>();
		
		Spw = GameObject.FindWithTag("SpawnObj");
		Spw_Script = Spw.gameObject.GetComponent<Spawner>();

        bloodsp = Resources.Load("Enemies/blood") as GameObject;
        dmgToWall = Resources.Load("WallDamage") as GameObject;

        vida = 1000.0f;
		attack = 100.0f; 
		Pont = 200.0f;

		atkSpeed = 0f;
		enemyPress = 33;
        isSlowed = false;
        moving = true;		
		pAtacar = true;

        if (Application.platform == RuntimePlatform.Android) StartingSpeed.Set(0.0f, 5f);
        else StartingSpeed.Set(0.0f, 15.0f);

        speed = StartingSpeed;   

		Spw_Script.setPress(enemyPress);
      
	}


    public override void Update()
    {
        anim.SetFloat("Health", vida);
        if (vida <= 0)
        {
            Kill();
        }

        if (vida > 0 && moving == true)
        {
            rb2D.MovePosition(rb2D.position + speed * Time.deltaTime);
        }

        if (atkSpeed >= 0.0f && pAtacar == false)
        {
            atkSpeed -= Time.deltaTime;
        }
        else
        {
            pAtacar = true;
            atkSpeed = 2.0f;
        }

        if(isSlowed)
        {
            slowTimer -= Time.deltaTime;
            if(slowTimer <= 0.0f)
            {
                walkNormal();
            }
        }
    }
    public override void Kill()
    {
        rb2D.isKinematic = true;

        if (!soundsource.isPlaying)
            soundsource.PlayOneShot(death);

        Destroy(gameObject, 3.0f);


    }
    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "Muralha")
        {
			rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            anim.SetBool("Atacando", true);
            if (pAtacar == true && mur.taJogando())
            {
                soundsource.PlayOneShot(atacar);
                Instantiate(dmgToWall, transform.position, Quaternion.identity);
                mur.RecDamage(attack);
                pAtacar = false;
            }
        }
    }
}
