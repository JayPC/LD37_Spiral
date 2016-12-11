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
	public float jumpPower = 50;
	Rigidbody rigid;
	float playerRotation = 0;
	public float playerVerticalLookAngle = 60;

	public static bool blockInput = false;

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

			if(Input.GetButtonDown("Jump")){
				rigid.AddRelativeForce(new Vector3(0, jumpPower, 0));
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
