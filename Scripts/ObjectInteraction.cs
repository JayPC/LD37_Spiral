using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {
	public GameObject caryPoint; //These must be linked in the Editor
	public Camera camera; //These must be linked in the Editor
	public GameObject caryObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			Debug.Log("LockingMouse");
			Cursor.lockState = CursorLockMode.Locked;
			Ray ray = new Ray (camera.transform.position, (camera.transform.position) *10);
			RaycastHit hit;

			if(caryObject == null){
				//If we're not carying anything and hitting something
				if(Physics.Raycast (camera.transform.position, camera.transform.forward, out hit, 6)){
					Debug.DrawLine(ray.origin, hit.point, Color.blue);
					if(hit.transform.gameObject.tag == "PuzzlePiece"){
						caryObject = hit.transform.gameObject;
					}
				}
				if(Physics.Raycast (camera.transform.position, camera.transform.forward, out hit, 10)){
					Debug.DrawLine(ray.origin, hit.point, Color.red);
					if(hit.transform.gameObject.tag == "InteractObject"){
						hit.transform.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
					}
				}
			}

			if(caryObject != null){
				caryObject.transform.position = caryPoint.transform.position;
			}
		}
		if(Input.GetMouseButtonUp(0)){
			caryObject = null;
		}


		if (Input.GetKeyDown("escape")){
			Cursor.lockState = CursorLockMode.None;
		}
	}

	 void OnMouseDown() {
	}
}
