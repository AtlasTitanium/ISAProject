using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {   
    void OnTriggerEnter(Collider collision){
		if(collision.gameObject.tag == "Player"){
			var hit = collision.gameObject;
			var health = hit.GetComponent<Health>();
			if (health  != null){
				health.TakeDamage(10);
			}

			Destroy(gameObject);
		}	
    }
}
