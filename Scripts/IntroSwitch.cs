using UnityEngine;
using System.Collections;

public class IntroSwitch : MonoBehaviour {
	public GameObject explosionPrefab;
	public GameObject[] explosionLocations;

	public float explostionDelay;
	public bool startExplosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(startExplosion && explostionDelay <= 0){
			foreach (GameObject go in explosionLocations) 
			{
				Instantiate(explosionPrefab, go.transform.position, Quaternion.identity);
			}
			IntroExplosion.SkipOpening();
			IntroExplosion.StartExplosion();
			startExplosion = false;
		} else if(startExplosion){
			explostionDelay-= Time.deltaTime;
		}
	}



	public void StartIntro(){
		Narator.playAudio("Dialogue/OpeningSwitch");
		startExplosion = true;
	}
}
