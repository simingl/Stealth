using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float turnSmoothing = 15f;
	public float speedDampTime = 0.1f;
	public float moveSpeedTime = 1f;

	public Rigidbody player;

	private Animator anim;

	void Awake(){
		anim = GetComponent<Animator> ();
		player = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		bool sneak = Input.GetButton ("Sneak");

		MovementManagement (h,v,sneak);


	}

	void MovementManagement(float horizontal, float vertical, bool sneaking){
		if (horizontal != 0f || vertical != 0f) {
			this.Rotating(horizontal,vertical);
			this.Moving(horizontal, vertical);
		}
	}

	void Rotating(float horizontal, float vertical){
		Vector3 targetDirection = new Vector3 (horizontal, 0f, vertical);
		Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp (player.rotation, targetRotation, turnSmoothing*Time.deltaTime);
		player.MoveRotation (newRotation);
	}

	void Moving(float horizontal, float vertical){
		Vector3 oldPos = player.position;
		Vector3 targetPos = new Vector3 (oldPos.x+horizontal, 0f, oldPos.z+vertical);
		Vector3 newPos = Vector3.Lerp (oldPos, targetPos, this.moveSpeedTime*Time.deltaTime);
		player.MovePosition (newPos);
	}
}
