using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DoorCRTL : MonoBehaviour {
	[SerializeField] private GameObject selfObject = null;
	[SerializeField] private Animator selfAnimator = null;
	[SerializeField] private Animator[] minor_left, minor_right, major_left, major_right;


	private void Awake() {
		if (!selfObject) selfObject = this.gameObject;
		if (!selfAnimator) selfAnimator = this.gameObject.GetComponent<Animator>();
	}

	private void openMinorDoors() {
		foreach (Animator i in minor_left) if (i != null && i.name!="None") 
				i.GetComponent<Animator>().SetBool("isDoorLocked", false);

		foreach (Animator i in minor_right) if (i != null && i.name != "None") 
				i.GetComponent<Animator>().SetBool("isDoorLocked", false);
	}
	private void openMajorDoors() {
		foreach (Animator i in major_left) if (i != null && i.name != "None") 
				i.GetComponent<Animator>().SetBool("isDoorLocked", false);

		foreach (Animator i in major_right) if (i != null && i.name != "None") 
				i.GetComponent<Animator>().SetBool("isDoorLocked", false);
	}
	public void OpenDoor(string type) {
		if (type == ("Minor")) {
			openMinorDoors();
		}
		if (type == ("Major")) {
			openMajorDoors();
		}
	}

	void CheckDoorBool() {
		if (gameObject.tag.Contains("Door"))
			if (selfAnimator.GetBool("isDoorLocked") == false)
				selfAnimator.SetTrigger("trgDoorOpen");	// TEST THIS LINE
	}
	private void Update() {
		CheckDoorBool();
	}


	/* Test methods
	private void OpenMyself() {
		if (gameObject.tag.Contains("Door")) {
			selfAnimator.SetBool("isDoorLocked", false);
		}
	}
	public void UnlockAll() {
		//if(key was picked up) call OpenDoor
		left.GetComponentInChildren<Animator>().SetBool("isDoorLocked", false);

	}*/
}
