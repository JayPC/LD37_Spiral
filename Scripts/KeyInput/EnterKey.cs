using UnityEngine;
using System.Collections;

public class EnterKey : MonoBehaviour {
	public GameObject keyEntryReference;
	public string keyValue = "";
	public bool isDeleteKey = false;
	public bool isResetKey = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Interact(){
		if(isDeleteKey){
			keyEntryReference.SendMessage("PopKey", SendMessageOptions.DontRequireReceiver);
		} else if(isResetKey){
			keyEntryReference.SendMessage("ResetPassword", SendMessageOptions.DontRequireReceiver);
		} else {
			keyEntryReference.SendMessage("KeyInput", keyValue, SendMessageOptions.DontRequireReceiver);
		}
	}
}
