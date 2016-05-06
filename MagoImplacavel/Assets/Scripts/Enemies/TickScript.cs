using UnityEngine;
using System.Collections;

public class TickScript : Enemy {  

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
        
 
        vida = 80.0f;
		attack = 100.0f;        
		Pont = 50.0f;

		enemyPress = 10;
        isSlowed = false;
        moving = true;

        if(Application.platform == RuntimePlatform.Android) StartingSpeed.Set(0.0f, 8f);
        else StartingSpeed.Set(0.0f, 45.0f);

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
      
        if (isSlowed)
        {
            slowTimer -= Time.deltaTime;
            if (slowTimer <= 0.0f)
            {
                walkNormal();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Muralha")
        {
            mur.RecDamage(attack);
            Pont = 0;
        }
        ApplyDamage(100);
    }
}
