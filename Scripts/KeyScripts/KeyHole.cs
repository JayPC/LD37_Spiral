using UnityEngine;
using System.Collections;

public class KeyHole : MonoBehaviour {
	public string keyName = "";
	public string targetKeyName;
	public Vector3 setPositionOffset;

	public GameObject targetTrigger;
	public GameObject reference;
	public string message;
	public bool triggered;
	public string audioFileToPlay;
	// Use this for initialization
	void Start () {
		CheckWinState.puzzlePieces.Add(keyName, false);
	}
	
	// Update is called once per frame
	void Update () {
		if(reference != null){
			reference.transform.position = this.transform.position + setPositionOffset;
			reference.transform.rotation = this.transform.rotation;
		}
	}

	public void OnTriggerStay(Collider other){
		//Debug.LogWarning("BLAH" + other.name);
		if(other.tag == "PuzzlePiece" && !triggered){
			if(other.gameObject.GetComponent<KeyObject>().keyName == targetKeyName){
				reference = other.gameObject;
				other.gameObject.GetComponent<Rigidbody>().isKinematic = true; //Make it so it doesn't move anymore
				other.gameObject.transform.position = this.transform.position + setPositionOffset;
				other.gameObject.transform.rotation = this.transform.rotation;
				if(targetTrigger != null){
					targetTrigger.SendMessage(message, SendMessageOptions.DontRequireReceiver);
				}
				Narator.playAudio(audioFileToPlay);
				CheckWinState.partCount++;
				triggered = true;
			}
		}
	}
}
