using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {

	[SerializeField] private GameObject lampOnShrine;
	[SerializeField] private GameObject lampWeapon;
	[SerializeField] private GameObject gm;

	// Use this for initialization
	void Start () {
		lampWeapon.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "playerTag") {
			lampOnShrine.SetActive (false);
			lampWeapon.SetActive (true);
			GameManager gameManager = gm.GetComponent<GameManager>();
			if(!gameManager.GameActive)
				gameManager.StartGame();
		}
	}
}
