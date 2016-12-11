using UnityEngine;
using System.Collections;

public class TextLookAtPlayer : MonoBehaviour {
	public GameObject playerReference;
	// Use this for initialization
	void Start () {
		playerReference = GameObject.Find("_PLAYER");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(playerReference.transform.position);
		//transform.rotation = Quaternion.LookRotation(transform.position - playerReference.transform.position);
	}
}
