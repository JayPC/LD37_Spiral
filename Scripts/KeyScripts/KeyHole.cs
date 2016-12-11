using UnityEngine;
using System.Collections;

public class KeyHole : MonoBehaviour {
	public string targetKeyName;
	public Vector3 setPositionOffset;
	public Quaternion setRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other){
		//Debug.LogWarning("BLAH" + other.name);
		if(other.tag == "PuzzlePiece"){
			if(other.gameObject.GetComponent<KeyObject>().keyName == targetKeyName){
				other.gameObject.GetComponent<Rigidbody>().isKinematic = true; //Make it so it doesn't move anymore
				other.gameObject.transform.position = this.transform.position + setPositionOffset;
				other.gameObject.transform.rotation = setRotation;
			}
		}
	}
}
