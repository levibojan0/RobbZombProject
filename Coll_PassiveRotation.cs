using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_PassiveRotation : MonoBehaviour {
	[SerializeField] private Vector3 RotationSpeed = new Vector3(1.5f, 0f, 0f);
	private bool runScript = true;

	void Update() {
		if (runScript)
			gameObject.transform.Rotate(RotationSpeed);
	}
}
