using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroExplosion : MonoBehaviour {
	public Vector3 postExplosionSpawn;

	public float fadeOutSpeed = 100;
	public float fadeInSpeed = 50;

	public bool fadeOut = false;
	public float blackAlpha = 0;
	public bool fadeIn = false;
	public bool firstTime = true;

	public Quaternion startQuaternion;
	public GameObject blackUIImage;
	public GameObject targetLookat;
	public GameObject triggeredButton;

	public float playerKnockback = 0;
	public void Update(){
		if(fadeOut){
			CharController.blockInput = true;
			blackAlpha += Time.deltaTime  * 0.7f;
			playerKnockback -= Time.deltaTime * 60;

			if(firstTime){
				startQuaternion = this.transform.rotation;
				firstTime = false;
			}
			if(playerKnockback >= -80){
				this.transform.rotation = startQuaternion * Quaternion.AngleAxis(playerKnockback, Vector3.right);
			}

			Color temp = blackUIImage.GetComponent<Image>().color;
			temp.a=blackAlpha;
			blackUIImage.GetComponent<Image>().color = temp;
		} 

		if(fadeOut && blackAlpha >= 1.0f){
			Debug.Log("Faded out!");
			triggeredButton.GetComponent<ButtonControls>().triggerExplosion = false;
			this.transform.rotation = Quaternion.identity;
			this.transform.position = postExplosionSpawn;
			fadeIn = true;
			fadeOut = false;
		}
		if(fadeIn){
			blackAlpha -= Time.deltaTime  * 0.3f;

			Color temp = blackUIImage.GetComponent<Image>().color;
			temp.a=blackAlpha;
			blackUIImage.GetComponent<Image>().color = temp;

			this.transform.rotation = Quaternion.AngleAxis(Time.deltaTime * fadeOutSpeed, Vector3.right);;
		}

		if(fadeIn && blackAlpha <= 0.25f){
			//Tell the player they can move again
			CharController.blockInput = false;
		}

		if(fadeIn && blackAlpha <= 0.0f){
			//blackAlpha = 0;
			fadeIn = false; 
		}
	}
	public void StartExplosion(GameObject button){
		//Black out
		triggeredButton = button;
		fadeOut = true;
	}
}
