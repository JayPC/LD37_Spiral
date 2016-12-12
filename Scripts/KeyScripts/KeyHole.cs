using UnityEngine;
using System.Collections;

public class KeyHole : MonoBehaviour {
	public string keyName = "";
	public string targetKeyName;
	public Vector3 setPositionOffset;

	public GameObject targetTrigger;
	public string message;
	public bool triggered;
	// Use this for initialization
	void Start () {
		CheckWinState.puzzlePieces.Add(keyName, false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerStay(Collider other){
		//Debug.LogWarning("BLAH" + other.name);
		if(other.tag == "PuzzlePiece" && !triggered){
			if(other.gameObject.GetComponent<KeyObject>().keyName == targetKeyName){
				other.gameObject.GetComponent<Rigidbody>().isKinematic = true; //Make it so it doesn't move anymore
				other.gameObject.transform.position = this.transform.position + setPositionOffset;
				other.gameObject.transform.rotation = this.transform.rotation;
				targetTrigger.SendMessage(message, SendMessageOptions.DontRequireReceiver);
				triggered = true;
			}
		}
	}
}
