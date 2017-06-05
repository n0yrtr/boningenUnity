using System.Collections;
using UnityEngine;
using SocketIO;

public class GameSocketControllerIO : MonoBehaviour
{
	[System.Serializable]
	public class mapData
	{
		public float playerPosX;
		public float playerPosY;
		public float enemyPosX;
		public float enemyPosY;
	}

	[SerializeField] private GameObject player;
	[SerializeField] private GameObject enemy;
	[SerializeField] private GameObject SocketIO;

	private SocketIOComponent socket;
	private float duration = 0;

	public void Start() 
	{
		socket = SocketIO.GetComponent<SocketIOComponent>();
		socket.On("message", TestBoop);
	}

	void Update () {
		//フレーム書き換えごとに経過時間を累積
		duration += Time.deltaTime;

		if (duration > 3) {
			duration = 0;

			//キャラの座標を計測
			mapData mapData = new mapData ();
			string mapDataStr = GetPoses(mapData);

			socket.Emit ("message", mapDataStr);
		}
	}

	string GetPoses(mapData mapData) {
		Vector3 playerNowPosition = player.transform.position;
		Vector3 enemyNowPosition = enemy.transform.position;

		mapData.playerPosX = Mathf.CeilToInt(playerNowPosition.x);
		mapData.playerPosY = Mathf.CeilToInt(playerNowPosition.z);
		mapData.enemyPosX = Mathf.CeilToInt(enemyNowPosition.x);
		mapData.enemyPosY = Mathf.CeilToInt(enemyNowPosition.z);

		string mapDataStr = mapData.playerPosX.ToString () + "," +
		                    mapData.playerPosY.ToString () + "," +
		                    mapData.enemyPosX.ToString () + "," +
		                    mapData.enemyPosY.ToString ();

		return mapDataStr;
	}

	public void TestBoop(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Boop received: " + e.name + " " + e.data);
		if (e.data == null) { return; }

		int actioni = int.Parse (e.data.ToString().Substring(3,1));
		Debug.Log ("=======================" + actioni.ToString());

		Vector3 playerNowPosition = player.transform.position;
		NewBehaviourScript anotherScript = player.GetComponent<NewBehaviourScript> ();
		//anotherScript.PlayerTranslation(playerNowPosition, actioni);	
		anotherScript.connectAction = actioni;
	}
}
