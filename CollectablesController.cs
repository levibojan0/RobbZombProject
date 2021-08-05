//using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectablesController : MonoBehaviour {

	[SerializeField] float defaultHealthValue = 15f, defaultPointValue = 100f;
	public CollectablesData[] 
		collData_Keys = new CollectablesData[2], 
		collData_Coins = new CollectablesData[3], 
		collData_Food = new CollectablesData[5];


	public void OutputCount(CollectablesData[] Coll_Type) {
		Debug.Log("You've Collected: ");
		for (int i = 0; i < Coll_Type.Length; i++) {
			Debug.Log(Coll_Type[i].name + " " + Coll_Type[i].num + "\n");
		}
	}

	/*IncrementCount() is the script's centerpiece method, 
		held by the Collectable_Group object 
		and called upon by CollectablePickUps.cs upon collision. */
	public void IncrementCount(GameObject obj, GameObject player) {

		switch (obj.tag) {
			case "Collectable_Food":
				player.gameObject.GetComponent<PlayerController>().HealthBoost(collData_Food[0].HealthMultiplier * defaultHealthValue);
				player.gameObject.GetComponent<PlayerController>().ScoreBoost(collData_Food[0].PointMultiplier * defaultPointValue);
				if (obj.name.Contains("Chicken"))
					collData_Food[0].num++;
				else if (obj.name.Contains("Banana"))
					collData_Food[1].num++;
				else if (obj.name.Contains("Cheese"))
					collData_Food[2].num++;
				else if (obj.name.Contains("Hamburger"))
					collData_Food[3].num++;
				else if (obj.name.Contains("Watermelon"))
					collData_Food[4].num++;

				OutputCount(collData_Food);
				break;

			case "Collectable_Coin":
				player.gameObject.GetComponent<PlayerController>().HealthBoost(collData_Keys[0].HealthMultiplier * defaultHealthValue);
				
				if (obj.name.Contains("Coin_Copper")) {
					collData_Coins[0].num++;
					player.gameObject.GetComponent<PlayerController>().ScoreBoost(collData_Coins[0].PointMultiplier * defaultPointValue);
				}
				else if (obj.name.Contains("Coin_Silver")) {
					collData_Coins[1].num++;
					player.gameObject.GetComponent<PlayerController>().ScoreBoost(collData_Coins[1].PointMultiplier * defaultPointValue);
				}
				else if (obj.name.Contains("Coin_Gold")) {
					collData_Coins[2].num++;
					player.gameObject.GetComponent<PlayerController>().ScoreBoost(collData_Coins[2].PointMultiplier * defaultPointValue);
				}

				OutputCount(collData_Coins);
				break;

			case "Collectable_Key":
				player.gameObject.GetComponent<PlayerController>().HealthBoost(collData_Keys[0].HealthMultiplier * defaultHealthValue);
				player.gameObject.GetComponent<PlayerController>().ScoreBoost(collData_Keys[0].PointMultiplier * defaultPointValue);
				if (obj.name.Contains("Key_Silver"))
					collData_Keys[0].num++;
				else if (obj.name.Contains("Key_Golden"))
					collData_Keys[1].num++;

				OutputCount(collData_Keys);
				break;


			default:
				Debug.Log("<sc_CollCTRL>: unknown__collectable_tag.");
				break;
		}
	}

	private void InitializeKeys() {
		collData_Keys[0].name = "Silver Key";
		collData_Keys[0].num = 0;
		collData_Keys[0].HealthMultiplier = 2f;
		collData_Keys[0].PointMultiplier = 2f;

		collData_Keys[1].name = "Golden Key";
		collData_Keys[1].num = 0;
		collData_Keys[1].HealthMultiplier = 2f;
		collData_Keys[1].PointMultiplier = 2f;
	}
	private void InitializeCoins() {
		collData_Coins[0].name = "Copper Coins";
		collData_Coins[0].num = 0;
		collData_Coins[0].HealthMultiplier = 0.5f;
		collData_Coins[0].PointMultiplier = 1f;

		collData_Coins[1].name = "Silver Coins";
		collData_Coins[1].num = 0;
		collData_Coins[1].HealthMultiplier = 0.5f;
		collData_Coins[1].PointMultiplier = 1.25f;

		collData_Coins[2].name = "Golden Coins";
		collData_Coins[2].num = 0;
		collData_Coins[2].HealthMultiplier = 0.5f;
		collData_Coins[2].PointMultiplier = 1.5f;
	}
	private void InitializeFood() {

		collData_Food[0].name = "Chicken";
		collData_Food[0].num = 0;
		collData_Food[0].HealthMultiplier = 1f;
		collData_Food[0].PointMultiplier = 0.5f;

		collData_Food[1].name = "Banana";
		collData_Food[1].num = 0;
		collData_Food[1].HealthMultiplier = 1f;
		collData_Food[1].PointMultiplier = 0.5f;

		collData_Food[2].name = "Cheese";
		collData_Food[2].num = 0;
		collData_Food[2].HealthMultiplier = 1f;
		collData_Food[2].PointMultiplier = 0.5f;

		collData_Food[3].name = "Hamburger";
		collData_Food[3].num = 0;
		collData_Food[3].HealthMultiplier = 1f;
		collData_Food[3].PointMultiplier = 0.5f;

		collData_Food[4].name = "Watermelon";
		collData_Food[4].num = 0;
		collData_Food[4].HealthMultiplier = 1f;
		collData_Food[4].PointMultiplier = 0.5f;
	}
	private void InitializeAll() {
		InitializeKeys();
		InitializeCoins();
		InitializeFood();

		if (defaultHealthValue == 0f) defaultHealthValue = 15f;
		if (defaultPointValue == 0f) defaultPointValue = 100f;

	}//upon play, set data values of all data sets


	/*This section communicates with the Door_Group gameController and informs it of key acquisition*/
	GameObject hermes;
	DoorCRTL hermes_doorControl;

	public void CheckKeys() {
		if (collData_Keys[0].num > 0) {
			hermes_doorControl.OpenDoor("Minor");
		}
		if (collData_Keys[1].num > 0) {
			hermes_doorControl.OpenDoor("Major");
		}
	}
	private void CallHermes() {
		hermes = GameObject.Find("Doors_Group");
		hermes_doorControl = hermes.GetComponent<DoorCRTL>();
	}

	
	private void KeyAssist() {
		collData_Keys[0].num += 773;
		collData_Keys[1].num += 973;
	}
	
	private void Start() {
		InitializeAll();
		CallHermes();
		//KeyAssist(); //Test method. keep disabled
	}
	private void Update() {
		CheckKeys();
	}

}

/* this was in Start()
DontDestroyOnLoad(gameObject);
if (FindObjectsOfType(GetType()).Length > 1) {
	//Destroy(gameObject);
}*/
