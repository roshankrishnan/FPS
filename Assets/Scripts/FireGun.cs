using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {

	public float cooldown = 0.25f;
	private float cooldownRemaining = 0;
	public GameObject hitPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;
		if (Input.GetMouseButton(0) && cooldownRemaining <= 0) {
			Ray shot = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;
			if (Physics.Raycast (shot, out hitInfo)) {
				Vector3 hitPoint = hitInfo.point;
				GameObject hitObject = hitInfo.collider.gameObject;
				Debug.Log("Hit Object: " + hitObject.name);
				Debug.Log ("Hit Point: " + hitPoint);
				if (hitObject.tag == "Enemy") {
					Destroy (hitObject);
				}
				if (hitPrefab != null) {
					Instantiate (hitPrefab, hitPoint, Quaternion.identity);
				}
			}  
			cooldownRemaining = cooldown;
		}
	}
}
