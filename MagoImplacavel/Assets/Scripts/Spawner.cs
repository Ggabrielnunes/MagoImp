using UnityEngine;
//using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] enemy;

	public Transform[] spawnPoints; 

	public float spawnTime = 4.5f;            
	public float gameTime = 0.0f;

	public int pressao;
	public int pressaoMaxima;

	GameObject pla;

	Player scrip;

	int maxEnemies;
	int currentEnemies;

    public int r;
	// Use this for initialization
	void Start () {
		pla = GameObject.FindWithTag("Player");
		scrip = pla.gameObject.GetComponent<Player> ();

       
		maxEnemies = 10;
		currentEnemies = 0;
		gameTime = 10;
		pressao = 0;
		pressaoMaxima = 100;
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	

	void Update () {
        if(gameTime <= 20 && scrip.taJogando() == true)
		    gameTime -= Time.deltaTime;
	}

	void Spawn() {

		if (currentEnemies < maxEnemies && scrip.taJogando() == true) {
			
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
            int enemySpawned = Random.Range(0, 100);
         
            
            if(spawnTime >= 4.5f)
                Instantiate(enemy[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

			if(spawnTime > 3 && spawnTime <= 4.0f) {
				if(enemySpawned >= 50 && (pressao + 20) <= pressaoMaxima)
					Instantiate(enemy[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
				if(enemySpawned < 50 && (pressao + 10) <= pressaoMaxima)
					Instantiate(enemy[1], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                return;
			}

			if(spawnTime > 2 && spawnTime <= 3.0f) {
				if(enemySpawned >= 70 && (pressao + 20) <= pressaoMaxima)
					Instantiate (enemy [0], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				if(enemySpawned > 30 && enemySpawned < 70 && (pressao + 10) <= pressaoMaxima)
					Instantiate (enemy [1], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				if(enemySpawned > 10 && enemySpawned <= 30 && (pressao + 20) <= pressaoMaxima)
					Instantiate (enemy [2], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);				
			}

			if(spawnTime > 1 && spawnTime <= 2.0f) {
				if(enemySpawned >= 70 && (pressao + 20) <= pressaoMaxima)
					Instantiate (enemy [0], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				if(enemySpawned > 50 && enemySpawned < 70 && (pressao + 10) <= pressaoMaxima)
					Instantiate (enemy [1], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				if(enemySpawned > 20 && enemySpawned <= 50 && (pressao + 20) <= pressaoMaxima)
					Instantiate (enemy [2], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
                if (enemySpawned <= 20 && (pressao + 33) <= pressaoMaxima)
                    Instantiate(enemy[3], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }

			if(spawnTime <= 1) {
				if(enemySpawned >= 80 && (pressao + 20) <= pressaoMaxima)
					Instantiate (enemy [0], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				if(enemySpawned > 50 && enemySpawned < 80 && (pressao + 10) <= pressaoMaxima)
					Instantiate (enemy [1], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				if(enemySpawned > 30 && enemySpawned <= 50 && (pressao + 20) <= pressaoMaxima)
					Instantiate (enemy [2], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				if(enemySpawned <= 30 && (pressao+33) <= pressaoMaxima)
					Instantiate (enemy [3], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			}

            currentEnemies ++;
		}



		if(gameTime <= 0 && scrip.taJogando()){

            if (spawnTime == 4.5f)
                spawnTime = 4.0f;

            if (spawnTime >= 1f && spawnTime != 4.5f)
				spawnTime--;

			if(spawnTime < 1)
                pressaoMaxima += 20;

            gameTime = 10;
		}

	}

	public void setEn() {
		if (currentEnemies > 0) {
			currentEnemies --;		
		}
	}
	public void setPress(int i) {
		pressao += i;
	}
	public void setME(int me){
		maxEnemies = me;
	}
}
