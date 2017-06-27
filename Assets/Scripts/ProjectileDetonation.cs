using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDetonation : MonoBehaviour {
	private float lifespan = 3.0f;
	public GameObject fireParticles;
	public GameObject explosionParticles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		if (lifespan <= 0) {
			Explode ();
		}
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Enemy") {
			Instantiate (fireParticles, collision.transform.position, Quaternion.identity);
			collision.gameObject.tag = "Untagged"; 
			Explode ();
		}
	}
	void Explode() {
		//TODO: Clean up particle clones in Game Controller
		//AOE Damage with Physics.OverlapSphere
		GameObject particleSpawn = (GameObject) Instantiate(explosionParticles, gameObject.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
