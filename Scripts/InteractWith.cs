using UnityEngine;
using System.Collections;

public class InteractWith : MonoBehaviour {
	public string interafaceSignalName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Interact(){
		Debug.Log("Interacting!");

		this.SendMessage(interafaceSignalName, SendMessageOptions.DontRequireReceiver);
		//Play Sound 
		
		//Trigger Animation
		
		//Process Event
		
	}
}
