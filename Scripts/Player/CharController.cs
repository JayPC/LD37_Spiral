using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	public static float rotateCount;
	public static bool positiveRotation = false;
	public float mouseSpeedX = 10;
	public float mouseSpeedY = 3;
	public float verticalLook;
	public bool inverted = false;

	public GameObject camera;
	public Vector3 turn;
	public Vector3 move;
	public float movementSpeed = 10;
	public float maxVelocity = 20;
	public float brakeMult = 0.8f;
	public float jumpPower = 50;
	Rigidbody rigid;
	float playerRotation = 0;
	public float playerVerticalLookAngle = 60;

	public static bool blockInput = false;
	public static bool isGrounded = true;

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!blockInput){
			Vector3 movementAxis = new Vector3();
			Vector3 turnAxis = new Vector3();
			mouseSpeedX = Mathf.Clamp(mouseSpeedX, 1, 10);
			mouseSpeedY = Mathf.Clamp(mouseSpeedY, 1, 10);

			if(Input.GetAxis("Horizontal") != 0){
				movementAxis.x = Input.GetAxis("Horizontal");
			}

			if(Input.GetAxis("Vertical") != 0){
				movementAxis.z = Input.GetAxis("Vertical");
			}

			if(Input.GetButtonDown("Jump") && isGrounded){
				rigid.AddRelativeForce(new Vector3(0, jumpPower, 0));
				isGrounded = false;
			}
			// var hit = Physics.Raycast(this.transform.position, -this.transform.up, 1.1f);
			// if(Physics.Raycast(this.transform.position, -this.transform.up, 1.1f)){
			// 	Debug.DrawRay(this.transform.position, -this.transform.up * 1.1f, Color.green);
			// 	isGrounded = true;
			// } else {
			// 	isGrounded = false;
			// 	Debug.DrawRay(this.transform.position, -this.transform.up * 1.1f, Color.red);
			// }
			if(movementAxis.magnitude <= 0.2f){
				rigid.velocity = new Vector3(rigid.velocity.x * brakeMult, rigid.velocity.y, rigid.velocity.z * brakeMult);
			}

			if(rigid.velocity.x >= maxVelocity){
				rigid.velocity = new Vector3(maxVelocity, rigid.velocity.y, rigid.velocity.z);
			} else if(rigid.velocity.x <= -maxVelocity){
				rigid.velocity = new Vector3(-maxVelocity, rigid.velocity.y, rigid.velocity.z);
			}

			if(rigid.velocity.z >= maxVelocity){
				rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, maxVelocity);
			} else if(rigid.velocity.z <= -maxVelocity){
				rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, -maxVelocity);
			}

			rigid.AddRelativeForce(movementAxis.normalized * movementSpeed);

			if(Input.GetAxis("Mouse X") != 0){
				turnAxis.x = Input.GetAxis("Mouse X") * mouseSpeedX;
				playerRotation += turnAxis.x;
			}
			if(turnAxis.x > 0){
				positiveRotation = true;
			} else if(turnAxis.x < 0){
				positiveRotation = false;
			}
			this.transform.Rotate(0, turnAxis.x, 0);

			if(Input.GetAxis("Mouse Y") != 0){
				turnAxis.y = Input.GetAxis("Mouse Y");
			}
			if(inverted){
				verticalLook += turnAxis.y * mouseSpeedY;
			} else {
				verticalLook -= turnAxis.y * mouseSpeedY;
			}
			verticalLook = Mathf.Clamp(verticalLook, -playerVerticalLookAngle, playerVerticalLookAngle);

			float look = 360+verticalLook;
			this.camera.transform.eulerAngles = this.transform.eulerAngles + new Vector3(look, 0, 0);
			turn = turnAxis;
		}
	}
}
