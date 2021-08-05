using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionBuffer : MonoBehaviour {
	//If camera has collided with an object, then temporarily hide object mesh as to not obstruct view.
	private void OnTriggerEnter(Collider other) {
		HideMeshRender(other.gameObject);
	}

	private void OnTriggerExit(Collider other) {
		RevealMeshRender(other.gameObject);
	}

	/* There are exceptions to this rule.
	 * a collectable item's mesh 
	 * and a certain type of wall's mesh (test based)
	 * will never be hidden
	 */
	void HideMeshRender(GameObject obj) {
		if (!obj.gameObject.tag.Contains("Coll") && !obj.gameObject.name.Contains("Basement_Var")) {
			obj.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
		}
	}
	void RevealMeshRender(GameObject obj) {
		if (!obj.gameObject.tag.Contains("Coll") && !obj.gameObject.name.Contains("Basement_Var")) {
			obj.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		}
	}


}
