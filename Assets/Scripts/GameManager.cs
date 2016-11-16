using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private List<GameObject> lampEnemies;
	private int enemiesKilled;
	private int prevCount;
	private float elapsedTime;
	private bool gameActive = false;
	public bool GameActive { get { return gameActive; } }

	[SerializeField] private GameObject player;
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private Text youLose;
	[SerializeField] private Text score;

	private AudioSource hitSound;

	void Start(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Use this for initialization
	public void StartGame () {
		lampEnemies = new List<GameObject> ();
		enemiesKilled = 0;
		elapsedTime = 0;
		prevCount = lampEnemies.Count;
		gameActive = true;
		youLose.text = "";
		score.text = "Score: " + 0;
		hitSound  = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameActive)
			return;

		elapsedTime += Time.deltaTime;

		if (lampEnemies.Count < prevCount) {
			enemiesKilled++;
			score.text = "Score: " + enemiesKilled;
			hitSound.Play ();
		}
		prevCount = lampEnemies.Count;

		if (lampEnemies.Count < (elapsedTime / 10)) {
			GameObject newEnemy = Instantiate(enemyPrefab);
			Transform enemyTransform = newEnemy.GetComponent<Transform>();
			int x = Random.Range(42,82);
			int z = Random.Range(13,70);
			enemyTransform.position = new Vector3(x, 0, z);
			EnemyBehavior eb = newEnemy.GetComponent<EnemyBehavior>();
			eb.Alive = true;
			eb.Player = player;
			lampEnemies.Add(newEnemy);
		}

		RigidbodyFirstPersonController playerScript = player.GetComponent<RigidbodyFirstPersonController> ();
		if (playerScript.Alive == false){
			youLose.text = "YOU LOSE";
		}

		for (int i = 0; i < lampEnemies.Count; i++) {
			GameObject enemy = lampEnemies[i];
			EnemyBehavior eb = enemy.GetComponent<EnemyBehavior>();
			if ( eb.Alive == false){
				lampEnemies.Remove(enemy);
				Destroy(enemy, 0.0f);
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
