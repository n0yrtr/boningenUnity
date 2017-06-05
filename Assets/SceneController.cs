using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

	GameObject buttonA;

	// Use this for initialization
	void Start () {
		GameObject unityChan = GameObject.Find ("ImageTarget/unitychan");
		unityChan.SetActive(false);
		GameObject enemy = GameObject.Find ("ImageTarget/z@walk");
		enemy.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//buttonA.SetActive(false);
	}

//	void OnGUI () {
//		if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 200, 100), "Unityちゃんと遊ぶ"))
//			print("Reset This Game");
//		
//	}
}
