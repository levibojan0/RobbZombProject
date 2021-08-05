using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleScene : MonoBehaviour {
	/* This script is utilised to switch between scenes when called for.
	 */
	[SerializeField] private int DestinationScene = 0; //TEST THIS LINE
	private void OnTriggerEnter(Collider player) {
		if (player.gameObject.tag.Contains("Player")) {
			SceneManager.LoadScene(DestinationScene);
		}
	}
	public void StartGame() {
		SceneManager.LoadScene(1);
	}
	public void ReturnToTitle() {
		SceneManager.LoadScene(0);
	}
	public void ExitGame() {
		Application.Quit();
	}
	

}
