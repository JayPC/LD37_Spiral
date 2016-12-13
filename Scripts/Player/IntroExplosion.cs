using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroExplosion : MonoBehaviour {
	public GameObject telepoortPositionIntro;
	public GameObject telepoortPositionEnding;

	public Vector3 postExplosionSpawn;

	public float fadeOutSpeed = 100;
	public float fadeInSpeed = 50;

	public static bool fadeOut = false;
	public float blackAlpha = 1;
	public bool fadeIn = false;
	public bool firstTime = true;

	public Quaternion startQuaternion;
	public GameObject blackUIImage;
	public GameObject targetLookat;
	public GameObject triggeredButton;
	public bool isStarting = true;
	public static bool skipOpening;
	public float fadeInDelay = 10;
	public float playerKnockback = 0;

	public void Start(){
		Narator.playAudio("Dialogue/OpeningDialogue");
		blackUIImage.GetComponent<Image>().color = new Color(0.0f,0.0f,0.0f,blackAlpha);
	}

	public void Update(){
		if(IntroExplosion.skipOpening){
			isStarting = false;
		}
		if(isStarting){
			blackAlpha -= Time.deltaTime * 0.3f;
			Color temp = blackUIImage.GetComponent<Image>().color;
			temp.a=blackAlpha;
			//Debug.LogWarning(blackAlpha);
			blackUIImage.GetComponent<Image>().color = temp;
		} if(isStarting && blackAlpha <= 0f){
			isStarting = false;
		}

		if(IntroExplosion.fadeOut){
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

		if(IntroExplosion.fadeOut && blackAlpha >= 1.0f){
			Debug.Log("Faded out!");
			//triggeredButton.GetComponent<ButtonControls>().triggerExplosion = false;
			this.transform.rotation = Quaternion.identity;
			this.transform.position = telepoortPositionIntro.transform.position;
			Narator.playAudio("Dialogue/GarageWakeUp");
			fadeIn = true;
			IntroExplosion.fadeOut = false;
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
	public static void StartExplosion(){
		//Black out
		IntroExplosion.fadeOut = true;
	}

	public static void SkipOpening(){
		skipOpening = true;
	}
}
