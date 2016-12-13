using UnityEngine;
using System.Collections;

public class EndingScript : MonoBehaviour {
	public bool spin;
	public GameObject world;
	public float teleDelay = 11;
	public GameObject playerRef;
	public GameObject telePoint;
	public bool stopTele;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(spin){
			world.transform.Rotate(Vector3.up * Time.deltaTime * 20);
			teleDelay -= Time.deltaTime;
		}

		if(teleDelay <= 0 && !stopTele){
			playerRef.transform.position = telePoint.transform.position;
			stopTele = true;
		}	
	}

	public void EndMyMisery(){
		if(CheckWinState.partCount >= 5){
			Narator.playAudio("Dialogue/Ending");
			spin = true;
		}
	}
}
