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
	public float triggerExplosionDelay = 5;
	public float buttonAnimation = 0;
	public float buttonAnimationSpeed = 10;
	public float buttonAnimationMax = 100;
	public bool buttonAnimationPlaying;
	public bool buttonAnimationReverse;

	public bool triggerExplosion;

	public float redShiftTime = 0;

	public GameObject[] WarningObjects;
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
				startingMachine = false;
			}
		} else if(triggerExplosion && machineStartupDelay <= 0){
			Debug.Log("Awaiting Explosion");
			if(triggerExplosionDelay <= 0){
				SetOffAlarm();
				PlayerReference.SendMessage("StartExplosion", this.gameObject, SendMessageOptions.DontRequireReceiver);
			} else {
				triggerExplosionDelay -= Time.deltaTime;
				SetOffAlarm();
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

	private void SetOffAlarm(){
		foreach (GameObject go in WarningObjects)
		{
			if(go.tag == "WarningLight"){
				Light l = go.GetComponent<Light>();
				Color temp = l.color;
				redShiftTime += Time.deltaTime*5;
				temp.r = 1+Mathf.Sin(redShiftTime)*10;
				temp.g = 0;
				temp.b = 0;
				l.color = temp;
			}
		}
	}
}
