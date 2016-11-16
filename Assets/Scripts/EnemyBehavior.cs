using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyBehavior : MonoBehaviour {
	
	private bool alive;
	public bool Alive { get { return alive; } set { alive = value; } }
	
	private GameObject player;
	public GameObject Player { set { player = value; } }

	
	// Use this for initialization
	void Start () {
		alive = true;
	}

	void Awake() {

	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			Vector3 newPosition = transform.position;
			if(player.transform.position.x >= transform.position.x + 0.06f ){
				newPosition.x = transform.position.x + 0.065f;
			}
			if(player.transform.position.x <= transform.position.x - 0.06f){
				newPosition.x = transform.position.x - 0.065f;
			}
			if(player.transform.position.z >= transform.position.z + 0.06f){
				newPosition.z = transform.position.z + 0.065f;
			}
			if(player.transform.position.z <= transform.position.z - 0.06f){
				newPosition.z = transform.position.z - 0.065f;
			}
			transform.position = newPosition;
		}
	}

	void OnTriggerEnter (Collider c){
		Debug.Log ("collision detected with " + c.gameObject.tag);
		RigidbodyFirstPersonController playerScript = player.GetComponent<RigidbodyFirstPersonController>();

		if (c.gameObject.tag == "bullet" && playerScript.Alive == true) {
			alive = false;
			Destroy(c.gameObject, 0.0f);
		}
		if (c.gameObject.tag == "playerTag") {

			playerScript.Alive = false;
		}
	}
}
