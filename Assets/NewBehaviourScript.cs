using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public int connectAction = -1;

	[SerializeField] private GameObject player;
	[SerializeField] private GameObject enemy;
	private Animator animator;
	// 1ブロックの移動量
	private const int TRANSLATION_ONE_BLOCK_DISTANCE = 20;
	// 11 × 11 のマス
	private const int MAX_ONE_ROW_BLOCK = 11;
	private const float ONE_FRAME_TRANSRATION_DISTANCE = 1;
	private const float MAX_DISTANCE = (float) TRANSLATION_ONE_BLOCK_DISTANCE * ((float)MAX_ONE_ROW_BLOCK / 2);
	// 移動後次の移動を開始するまでのディレイ回数。
	private const int DelayTImes = 2;


	int turn = 0; 
	Vector3 playerBeforeTranslationPosition;
	bool playerTranslationNow = false;
	// 移動がおわったあと何回ディレイしたか。
	int nowDelayTimes = 0;
	int translationDirection = 0; // 0: stop , 1: left, 2: right, 3: up 4: down
	int stopCounter = 0;
	int moveDir = 0; //移動中の向き
	public float POSY = 0.01f;
	float t = 1;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		Vector3 playerNowPosition = player.transform.position;
		Debug.Log ("x:" + playerNowPosition.x + "  y:" + playerNowPosition.y + "  z:" + playerNowPosition.z);
		if (playerTranslationNow == false) {
			if (nowDelayTimes <= DelayTImes) {
				nowDelayTimes++;
				return;
			}
			// TODO 第二引数にenemypositionに入れる。
			InitBeforeTranslate (playerNowPosition, playerNowPosition);

		} else {
			PlayerTranslation (playerNowPosition, translationDirection);	
		}
	}


	void InitBeforeTranslate(Vector3 playerNowPositon, Vector3 enemyNowPosition) {
		if (connectAction == -1) {
			return;	
		}
		translationDirection = connectAction;
		nowDelayTimes = 0;
		playerTranslationNow = true;
		playerBeforeTranslationPosition = playerNowPositon;
		// Random クラスの新しいインスタンスを生成する
		//System.Random cRandom = new System.Random ();
		// 0 以上 5 未満の乱数を取得する
		// cRandom.Next (5);

	}

	// playerの移動
	public void PlayerTranslation (Vector3 playerNowPosition, int translationDirection) {

		moveDir = translationDirection;
		TurnUnityChan (translationDirection);

		switch (translationDirection) {
		case 0:
			Debug.Log ("stop");
			if (stopCounter < TRANSLATION_ONE_BLOCK_DISTANCE) {
				stopCounter++;
				animator.SetBool("is_running", false);
			} else {
				stopCounter = 0;
				playerTranslationNow = false;
			}	

			break;
		case 3:
			Debug.Log ("up");
			if (playerNowPosition.z < playerBeforeTranslationPosition.z + TRANSLATION_ONE_BLOCK_DISTANCE
				&& playerNowPosition.z < MAX_DISTANCE) {
				this.transform.position = new Vector3 (playerNowPosition.x, POSY, playerNowPosition.z + ONE_FRAME_TRANSRATION_DISTANCE);
				//transform.position -= transform.forward;
				animator.SetBool("is_running", true);
			} else {
				Debug.Log ("stop");
				playerTranslationNow = false;
			}
			break;
		case 2:
			Debug.Log ("right");
			if (playerNowPosition.x < playerBeforeTranslationPosition.x + TRANSLATION_ONE_BLOCK_DISTANCE
				&& playerNowPosition.x < MAX_DISTANCE) {
								this.transform.position = new Vector3 (playerNowPosition.x + ONE_FRAME_TRANSRATION_DISTANCE, POSY, playerNowPosition.z);
								Debug.Log ("trans");
				//transform.position -= transform.right;
				animator.SetBool("is_running", true);
			} else {
				Debug.Log ("stop");
				playerTranslationNow = false;
			}
			break;
		case 4:
			Debug.Log ("down");
			if (playerNowPosition.z > playerBeforeTranslationPosition.z - TRANSLATION_ONE_BLOCK_DISTANCE
				&& playerNowPosition.z > -MAX_DISTANCE) {
				this.transform.position = new Vector3 (playerNowPosition.x, POSY, playerNowPosition.z - ONE_FRAME_TRANSRATION_DISTANCE);
				//transform.position += transform.forward;
				animator.SetBool("is_running", true);
			} else {
				Debug.Log ("stop");
				playerTranslationNow = false;
			}
			break;
		case 1:
			Debug.Log ("left");
			if (playerNowPosition.x > playerBeforeTranslationPosition.x - TRANSLATION_ONE_BLOCK_DISTANCE
				&& playerNowPosition.x > -MAX_DISTANCE) {
				Debug.Log ("trans");
				this.transform.position = new Vector3 (playerNowPosition.x - ONE_FRAME_TRANSRATION_DISTANCE, POSY, playerNowPosition.z);
				//transform.position += transform.right;
				animator.SetBool("is_running", true);
			} else {
				Debug.Log ("stop");
				playerTranslationNow = false;
			}
			break;
		default:
			Debug.Log ("Default case error");
			break;
		}
	}

	public void TurnUnityChan(int dir) {
		//0: stop , 1: left, 2: right, 3: up 4: down
		if (dir == 1) {
			player.transform.rotation = Quaternion.RotateTowards (player.transform.rotation, Quaternion.Euler (0, 270, 0), 2700 * Time.deltaTime);

		} else if (dir == 2) {
			player.transform.rotation = Quaternion.RotateTowards (player.transform.rotation, Quaternion.Euler (0, 90, 0), 2700 * Time.deltaTime);
		
		} else if (dir == 3) {
			player.transform.rotation = Quaternion.RotateTowards (player.transform.rotation, Quaternion.Euler (0, 0, 0), 2700 * Time.deltaTime);

		} else if (dir == 4) {
			player.transform.rotation = Quaternion.RotateTowards (player.transform.rotation, Quaternion.Euler (0, 180, 0), 2700 * Time.deltaTime);

		} else if (dir == 0) {
			//ゾンビの方を見る
			transform.LookAt(enemy.transform);
			//player.transform.rotation = Quaternion.LookRotation(enemy.transform.position – player.transform.position);
		} 
	}
}


