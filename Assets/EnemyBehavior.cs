using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	[SerializeField] private GameObject player;
	private const float ONE_FRAME_TRANSRATION_DISTANCE = 0.2f;
	private float duration = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		duration += Time.deltaTime;

		if (duration > 3) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z), 5f * Time.deltaTime);
			transform.LookAt (player.transform);
			if (duration > 6) {
				duration = 0;
			}
		} else {

		}
	}
}
