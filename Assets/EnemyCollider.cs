using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

	// 衝突した瞬間に呼ばれる  
	void OnTriggerEnter(Collider other) {  
		Debug.Log ("Game Over");
	}  
	// 衝突している間呼ばれ続ける  
	void OnTriggerStay(Collider other) {  
	}  
	// 衝突から離れた瞬間に呼ばれる  
	void OnTriggerExit(Collider other) {  
	}  
	void OnCollisionEnter(Collision collision){  
		foreach(ContactPoint point in collision.contacts){  
			Vector3 hitPos = point.point;  
			// hitPosの座標を使ってエフェクトなどを生成  
		}  
	} 
}
