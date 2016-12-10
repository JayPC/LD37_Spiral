using UnityEngine;
using System.Collections;

public class FloorCounter : MonoBehaviour {
	public int floorCount;
	public bool positiveEnterDirection = true; //if true then the rotation was positive when entering; 
	public bool plyaerTurnDirection = true; //if true then the rotation was positive when entering; 

	public Rigidbody rigid;
	public MeshRenderer renderer;
	public Collider collider;
	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody>();
		renderer = this.GetComponent<MeshRenderer>();
		collider = this.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(floorCount == 0){
			renderer.enabled = true;
			rigid.isKinematic = false;
			collider.isTrigger = false;
		} else {
			renderer.enabled = false;
			rigid.isKinematic = true;
			collider.isTrigger = true;
		}

		if(floorCount == 5){
			floorCount = 0;
		} else if(floorCount == -1){
			floorCount = 4;
		}

		plyaerTurnDirection = CharController.positiveRotation;
	}

	public void OnTriggerExit(Collider coll)
	{
		if(coll.tag == "SpinTrigger")
		{
			if(positiveEnterDirection){
				//entering and leaving from the same direction does something
				if(CharController.positiveRotation){
					floorCount += 1;
				}
			} else if(!positiveEnterDirection){
				if(!CharController.positiveRotation){
					floorCount -= 1;
				}
			}
		}
	}

	public void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "SpinTrigger")
		{	
			if(CharController.positiveRotation){
				positiveEnterDirection = true;
			} else if(!CharController.positiveRotation){
				positiveEnterDirection = false;
			}
		}
	}
}