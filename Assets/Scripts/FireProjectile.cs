using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {
	public GameObject projectilePrefab;
	public float projectileSpeed = 50f;
	public float projectileCooldown = 4.0f;
	private float cooldownRemaining;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;
		if (Input.GetButtonDown ("Fire3") && cooldownRemaining <= 0) {
			cooldownRemaining = projectileCooldown;
			Camera cam = Camera.main;
			GameObject projectile = (GameObject)Instantiate (projectilePrefab, cam.transform.position + cam.transform.forward, cam.transform.rotation);
			projectile.GetComponent<Rigidbody>().AddForce (cam.transform.forward * projectileSpeed, ForceMode.Impulse);

		}
	}
}
