using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {
	public GameObject caryPoint; //These must be linked in the Editor
	public Camera camera; //These must be linked in the Editor
	public GameObject caryObject;
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
		if(Input.GetMouseButton(0) && caryObject == null){
			Cursor.lockState = CursorLockMode.Locked;
			if(caryObject == null){
				//If we're not carying anything and hitting something
				var hits = Physics.RaycastAll (camera.transform.position, camera.transform.forward, 6);
				if(hits.Length > 0){
					for(var i=0;i<=hits.Length-1;i++){
						if(hits[i].transform.tag=="PuzzlePiece"){
							if(hits[i].transform.gameObject.GetComponent<MeshRenderer>() != null && hits[i].transform.gameObject.GetComponent<MeshRenderer>().enabled == true){
								caryObject = hits[i].transform.gameObject;
							}
						}
					}
				}
				
			}
		}

		if(Input.GetMouseButtonUp(0)){
			caryObject = null;
		}

		if(caryObject != null){
			caryObject.transform.position = caryPoint.transform.position;
		}




		
		//****************************
		//  Interact With Object
		//****************************
		if(Input.GetMouseButtonDown(0)){
			Ray ray = new Ray (camera.transform.position, (camera.transform.position) *10);
			RaycastHit hit;

			if(Physics.Raycast (camera.transform.position, camera.transform.forward, out hit, 10)){
				Debug.DrawLine(ray.origin, hit.point, Color.red);
				if(hit.transform.gameObject.tag == "InteractObject"){
					hit.transform.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		
	}
}
