using UnityEngine;
using System.Collections;

public class IntroSwitch : MonoBehaviour {
	public GameObject explosionPrefab;
	public GameObject[] explosionLocations;
	public GameObject animObject;
	public Animator anim;
	public float explostionDelay;
	public bool startExplosion;
	public bool startExplosionAnim;
	// Use this for initialization
	void Start () {
		anim = animObject.GetComponent<Animator>();
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
			if(!startExplosionAnim){
				anim.SetTrigger("FlipSwitch");
				startExplosionAnim = true;
			}
			explostionDelay-= Time.deltaTime;
		}
	}



	public void StartIntro(){
		Narator.playAudio("Dialogue/OpeningSwitch");
		startExplosion = true;
	}
}
