using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.5f;
	public float nextFire = 0.5f;


	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

}
