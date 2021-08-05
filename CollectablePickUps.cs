using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickUps : MonoBehaviour {
	[SerializeField] public AudioClip collectSound;
	[SerializeField] public GameObject collectableGroup;

	GameObject hermes = GameObject.Find("Collectables_Group");
	CollectablesController hermes_Collectables_Group;
	private void CallHermes() {
		hermes = GameObject.Find("Collectables_Group");
		hermes_Collectables_Group = hermes.GetComponent<CollectablesController>();
	}

	private void PlaySound(Collider other, AudioClip clip) {
		other.gameObject.GetComponentInChildren<AudioSource>().PlayOneShot(collectSound, 1f);
	}

	private void OnTriggerEnter(Collider player) {
		if (player.gameObject.tag.Contains("Player")) {
			hermes_Collectables_Group.IncrementCount(this.gameObject, player.gameObject);

			PlaySound(player, collectSound);

			this.gameObject.SetActive(false);

			Debug.Log(player.gameObject.GetComponent<PlayerController>().GetHP());
			Debug.Log(player.gameObject.GetComponent<PlayerController>().GetScore());

		}

	}
	private void Start() {
		CallHermes();//Connect To <CollectablesController>;
	}

}
