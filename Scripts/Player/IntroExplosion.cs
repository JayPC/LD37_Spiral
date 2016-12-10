using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroExplosion : MonoBehaviour {
	public Vector3 postExplosionSpawn;
	public bool fadeOut = false;
	public float fadeOutSpeed = 100;
	public float fadeInSpeed = 1000;
	public float blackAlpha = 0;
	public bool fadeIn = false;

	GameObject blackUIImage;
	GameObject targetLookat;

	public float playerKnockback = 0;
	public void Update(){
		if(fadeOut){
			blackAlpha += Time.deltaTime  * fadeOutSpeed;
			this.transform.rotation = Quaternion.AngleAxis(blackAlpha, Vector3.right);;
		}

		if(blackAlpha >= 255){
			this.transform.rotation = Quaternion.identity;
			this.transform.position = postExplosionSpawn;

		}
	}
	public void StartExplosion(){
		//Black out
		fadeOut = true;
	}
}
