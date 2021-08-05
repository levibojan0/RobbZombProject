using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
	[SerializeField] private float PlayerHealth = 100f;
	[SerializeField] private float TotalScore = 0f;

	[SerializeField] private Camera selfCamera = null;
	[SerializeField] private Rigidbody selfRigidBody = null;
	[SerializeField] private NavMeshAgent selfAgent = null;
	[SerializeField] private Animator selfAnimator = null;

	[SerializeField] private float RotationSpeed;
	[SerializeField] private GameObject arrow;

	private float rayhit_Distance;
	private float horizontalInput;

	private RaycastHit rayhit;
	private Quaternion newRotation;

	public void HealthBoost(float amount) {
		PlayerHealth += amount;
		if (PlayerHealth > 125f)
			PlayerHealth = 125f;
	}
	public float GetHP() {
		return PlayerHealth;
	}
	public void ScoreBoost(float amount) {
		TotalScore += amount;
	}
	public float GetScore() {
		return TotalScore;
	}

	private void Awake() {
		if (!selfCamera) { selfCamera = this.gameObject.GetComponent<Camera>(); }
		if (!selfRigidBody) { selfRigidBody = this.gameObject.GetComponent<Rigidbody>(); }
		if (!selfAgent) { selfAgent = this.gameObject.GetComponent<NavMeshAgent>(); }
		if (!selfAnimator) { selfAnimator = this.gameObject.GetComponent<Animator>(); }
	}
	private void Update() {
		//PlayerRotation();
		PlayerMovement();
		AnimationControl();
		//Debug.Log(transform.rotation);
	}
	void AnimationControl() {
		if (rayhit_Distance < 0.2f || selfAgent.velocity.magnitude < 0.2f) {
			this.gameObject.GetComponentInChildren<AudioSource>().volume=0f;
			selfAnimator.SetBool("isMoving", false);
		}
		else {//if moving
			this.gameObject.GetComponentInChildren<AudioSource>().volume=0.033f;
			selfAnimator.SetBool("isMoving", true);
		}
	}
	void RayHitDistance() {
		rayhit_Distance = Vector3.Distance(rayhit.point, transform.position);
		rayhit_Distance -= rayhit_Distance % 0.01f; // leave out some digits
	}

	void PlayerMovement() {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray0 = selfCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray0, out rayhit)) {
				RayHitDistance();
				if (rayhit_Distance >= 0.2f) {
					selfAgent.SetDestination(rayhit.point);
					//GameObject Arrow = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
					//arrow.transform.position.MoveTowards(arrow.transform.position, rayhit.transform.position, 10000f);
					//Transform target = arrow.transform;
					//target.transform.localScale = new Vector3(0.15f, 0.4f, 0.15f);
					//target.transform.position = rayhit.transform.position;
				}
			}
		}
	}
	//PlayerRotation() disabled 
	void PlayerRotation() {
		//Vector3 relativePos = rayhit.point - transform.position;

		horizontalInput = Input.GetAxisRaw("Horizontal");
		float skew = 10f;
		Vector3 v3 = new Vector3(0f, skew, 0f);
		Quaternion v4 = new Quaternion(0f, skew, 0f, 1f);

		//Quaternion v4 =transform.rotation, angleAmount = new Quaternion(20f,20f,20f,1f);
		if (horizontalInput != 0) {
			transform.rotation = Quaternion.Euler(v3);
		}



	}

}

