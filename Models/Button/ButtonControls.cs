using UnityEngine;
using System.Collections;

public class ButtonControls : MonoBehaviour {
	public GameObject PlayerReference;
	public GameObject targetInteract;
	public GameObject nextButton;
	public GameObject buttonMesh;
	public Animator animator;
	public bool openCover;
	public bool locked;
	public bool startingMachine;
	public float machineStartupDelay = 5;
	public float buttonAnimation = 0;
	public float buttonAnimationSpeed = 10;
	public float buttonAnimationMax = 100;
	public bool buttonAnimationPlaying;
	public bool buttonAnimationReverse;

	public bool triggerExplosion;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		if(openCover){
			animator.SetTrigger("OpenCover");
			this.GetComponent<InteractWith>().interafaceSignalName = "PressButton";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(startingMachine){
			if(machineStartupDelay > 0){
				machineStartupDelay -= Time.deltaTime;
			} else if(machineStartupDelay <= 0){
				if(nextButton != null){
					nextButton.SendMessage("OpenButtonCover", SendMessageOptions.DontRequireReceiver);
				}
				if(triggerExplosion){
					PlayerReference.SendMessage("StartExplosion", SendMessageOptions.DontRequireReceiver);
				}
				startingMachine = false;
			}
		}

		if(buttonAnimationPlaying){
			if(buttonAnimation < buttonAnimationMax && !buttonAnimationReverse){
				buttonAnimation += Time.deltaTime * buttonAnimationSpeed;
			} else if(buttonAnimation > buttonAnimationMax && !buttonAnimationReverse){
				buttonAnimationReverse = true;
			} else if(buttonAnimation > 0 && buttonAnimationReverse){
				buttonAnimation -= Time.deltaTime * buttonAnimationSpeed;
			} else if(buttonAnimation < 0 && buttonAnimationReverse){
				buttonAnimationPlaying = false;
				buttonAnimationReverse = false;
				startingMachine = true;
			}
			buttonMesh.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,buttonAnimation);
		}
	}

	public void OpenButtonCover(){
		animator.SetTrigger("OpenCover");
		this.GetComponent<InteractWith>().interafaceSignalName = "PressButton";
	}

	public void PressButton(){
		buttonAnimationPlaying = true;
		//targetInteract.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
	}
}
