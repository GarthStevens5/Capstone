using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private CharacterController characterController;
	private Animator animator;

	[SerializeField]
	private float moveSpeed = 100;
	[SerializeField]
	private float turnSpeed = 3f;
	[SerializeField]
	private float backwardMoveSpeed = 3;

	private void Awake(){
		characterController = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator>();
	}

	private void Update () {
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");

		var movement = new Vector3(horizontal, 0, vertical);

		characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

		animator.SetFloat("Speed", vertical);
		
		transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

		if (vertical != 0)
		{
			float moveSpeedToUse = (vertical > 0) ? moveSpeed : backwardMoveSpeed;
			characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
		}
	}
}