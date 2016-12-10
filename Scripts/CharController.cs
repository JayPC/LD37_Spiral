using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	public static float rotateCount;
	public static bool positiveRotation = false;
	public float mouseSpeed;

	public GameObject camera;
	public Vector3 turn;
	public Vector3 move;
	public float movementSpeed = 10;
	public float jumpPower = 50;
	Rigidbody rigid;
	float playerRotation = 0;
	public float playerVerticalLookAngle = 60;

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movementAxis = new Vector3();
		Vector3 turnAxis = new Vector3();
		

		if(Input.GetAxis("Horizontal") != 0){
			movementAxis.x = Input.GetAxis("Horizontal");
		}

		if(Input.GetAxis("Vertical") != 0){
			movementAxis.z = Input.GetAxis("Vertical");
		}

		if(Input.GetButtonDown("Jump")){
			rigid.AddForce(new Vector3(0, jumpPower, 0));
		}

		rigid.AddRelativeForce(movementAxis.normalized * movementSpeed);

		if(Input.GetAxis("Mouse X") != 0){
			turnAxis.x = Input.GetAxis("Mouse X");
			playerRotation += turnAxis.x;
		}
		//Debug.Log(playerRotation);
		//Debug.Log(turnAxis.x);

		if(Input.GetAxis("Mouse Y") != 0){
			turnAxis.y = Input.GetAxis("Mouse Y");
		}

		this.transform.Rotate(new Vector3(0, turnAxis.x, 0));

		this.camera.transform.Rotate(new Vector3(turnAxis.y, 0, 0));
		turn = turnAxis;
	}
}
