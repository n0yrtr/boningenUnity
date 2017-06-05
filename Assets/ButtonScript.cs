using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	[SerializeField] private GameObject player;
	[SerializeField] private GameObject enemy;

	public void ClickTest () {
		Debug.Log ("Clicked.");

		GameObject buttonA = GameObject.Find ("Canvas/ButtonA");
		buttonA.SetActive(true);

		//GameObject unitychan = GameObject.Find ("ImageTarget/unitychan");
		player.SetActive(true);
		player.transform.position = new Vector3 (0f, 0.01f, 0f);
		//GameObject enemy = GameObject.Find ("ImageTarget/z@walk");
		enemy.SetActive(true);
		enemy.transform.position = new Vector3 (1.15f, 0.01f, 0f);


	}
}
