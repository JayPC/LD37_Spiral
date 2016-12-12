using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {
	public GameObject caryPoint; //These must be linked in the Editor
	public Camera camera; //These must be linked in the Editor
	public GameObject caryObject;
	public float moveForce = 100;

	public static bool dropIt = false;
	public bool dropItTest = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//****************
		//  Mouse Cursor
		//****************
		if(Input.GetMouseButtonDown(0)){
			Cursor.lockState = CursorLockMode.Locked;
		}
		
		if (Input.GetKeyDown("escape")){
			Cursor.lockState = CursorLockMode.None;
		}

		//******************
		//  Pickup Object
		//******************
		if(Input.GetMouseButtonDown(0) && caryObject == null){
			Cursor.lockState = CursorLockMode.Locked;
			if(caryObject == null){
				//If we're not carying anything and hitting something
				var hits = Physics.RaycastAll (camera.transform.position, camera.transform.forward, 2);
				if(hits.Length > 0){
					for(var i=0;i<=hits.Length-1;i++){
						if(hits[i].transform.tag == "PuzzlePiece" || hits[i].transform.tag == "Carryable"){
							//Debug.Log("Name: " + hits[i].transform.name);
							if((hits[i].transform.gameObject.GetComponent<MeshRenderer>() != null && hits[i].transform.gameObject.GetComponent<MeshRenderer>().enabled == true) ||
								(hits[i].transform.gameObject.GetComponent<SkinnedMeshRenderer>() != null && hits[i].transform.gameObject.GetComponent<SkinnedMeshRenderer>().enabled == true)){
								caryObject = hits[i].transform.gameObject;
							}
						}
					}
				}
			}
		}

		if(caryObject != null){
			Vector3 directionVector = caryPoint.transform.position - caryObject.transform.position; //Get me the direction to move in.
			if(caryObject.GetComponent<Rigidbody>() != null){
				//Debug.Log("Rigidbody Found");
				if(Vector3.Distance(caryObject.transform.position,  caryPoint.transform.position) > 0f){
					caryObject.GetComponent<Rigidbody>().AddForce(directionVector * moveForce);
					caryObject.GetComponent<Rigidbody>().drag = 10;
				} else {
					caryObject.GetComponent<Rigidbody>().velocity = new Vector3();
				}
			}
		}

		dropItTest = ObjectInteraction.dropIt;
		if(Input.GetMouseButtonUp(0)){
			if(caryObject != null){
				if(caryObject.GetComponent<Rigidbody>() != null){
					caryObject.GetComponent<Rigidbody>().drag = 0;
				}
			}
			caryObject = null;
		}
		if(dropIt){
			if(caryObject != null){
				if(caryObject.GetComponent<Rigidbody>() != null){
					caryObject.GetComponent<Rigidbody>().drag = 0;
				}
			}
			caryObject = null;
			ObjectInteraction.dropIt = false;
		}
		
		//****************************
		//  Interact With Object
		//****************************
		// if(Input.GetMouseButtonDown(0)){
		// 	Ray ray = new Ray (camera.transform.position, (camera.transform.position) *10);
		// 	RaycastHit hit;

		// 	if(Physics.Raycast (camera.transform.position, camera.transform.forward, out hit, 10)){
		// 		Debug.DrawLine(ray.origin, hit.point, Color.red);
		// 		if(hit.transform.gameObject.tag == "InteractObject"){
		// 			Debug.Log("Interacting with: " + hit.transform.gameObject.name);
		// 			hit.transform.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
		// 		}
		// 	}
		// }

		if(Input.GetMouseButtonDown(0)){
			var hits = Physics.RaycastAll (camera.transform.position, camera.transform.forward, 6);
			if(hits.Length > 0){
				for(var i=0;i<=hits.Length-1;i++){
					hits[i].transform.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
