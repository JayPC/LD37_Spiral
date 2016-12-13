using UnityEngine;
using System.Collections;

public class EndingScript : MonoBehaviour {
	public bool spin;
	public GameObject world;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(spin){
			world.transform.Rotate(Vector3.up * Time.deltaTime * 20);
		}
	}

	public void EndMyMisery(){
		if(CheckWinState.partCount >= 5){
				Narator.playAudio("Dialogue/Ending");
		}
	}
}
