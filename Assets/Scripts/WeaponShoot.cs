using UnityEngine;
using System.Collections;

public class WeaponShoot : MonoBehaviour {

	[SerializeField] private GameObject lamppost;
	private AudioSource shootSound;
	// Use this for initialization
	void Start () {
		shootSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			GameObject bullet = Instantiate(lamppost);
			Transform bulletTransform = bullet.GetComponent<Transform>();
			Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
			bulletTransform.position = transform.position;
			bulletTransform.rotation = transform.rotation;
			bulletTransform.localScale.Scale(new Vector3(0.5f,0.5f,0.5f));
			bulletRB.AddForce(transform.up * 5000);
			shootSound.Play ();
			Destroy(bullet, 10.0f);
		}
	}
}
