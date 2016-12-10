using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	public static float rotateCount;
	public static bool positiveRotation = false;
	public float mouseSpeed;
	public float verticalLook;

	public GameObject camera;
	public Vector3 turn;
	public Vector3 move;
	public float movementSpeed = 10;
	public float jumpPower = 50;
	Rigidbody rigid;
	float playerRotation = 0;
	public float playerVerticalLookAngle = 60;

	public bool blockInput = false;

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!blockInput){
			Vector3 movementAxis = new Vector3();
			Vector3 turnAxis = new Vector3();
			

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
				turnAxis.x = Input.GetAxis("Mouse X");
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
			verticalLook += turnAxis.y;
			verticalLook = Mathf.Clamp(verticalLook, -playerVerticalLookAngle, playerVerticalLookAngle);

			float look = 360+verticalLook;
			this.camera.transform.eulerAngles = this.transform.eulerAngles + new Vector3(look, 0, 0);
			turn = turnAxis;
		}
	}
}
