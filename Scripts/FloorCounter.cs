using UnityEngine;
using System.Collections;

public enum FloorNum{
	FLOOR_ZERO, 
	FLOOR_THREE, 
	FLOOR_ONE, 
	FLOOR_TWO, 
	FLOOR_FOUR
}

public class FloorCounter : MonoBehaviour {
	public int floorCount;
	public bool positiveEnterDirection = true; //if true then the rotation was positive when entering; 
	public bool plyaerTurnDirection = true; //if true then the rotation was positive when entering; 

	public Rigidbody rigid;
	public MeshRenderer renderer;
	public Collider collider;
	public FloorNum floorNum;
	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody>();
		renderer = this.GetComponent<MeshRenderer>();
		collider = this.GetComponent<Collider>();
		switch (floorNum) 
		{
			case FloorNum.FLOOR_ZERO:
			  floorCount = 0;
			  break;
			case FloorNum.FLOOR_THREE:
			  floorCount = 1;
			  break;
			case FloorNum.FLOOR_ONE:
			  floorCount = 2;
			  break;
			case FloorNum.FLOOR_FOUR:
			  floorCount = 3;
			  break;
			case FloorNum.FLOOR_TWO:
			  floorCount = 4;
			  break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(floorCount == 0){
			setRenderer(true);
			setKinematic(false);
			setIsTrigger(false);
		} else {
			setRenderer(false);
			setKinematic(true);
			setIsTrigger(true);
		}

		if(floorCount == 5){
			floorCount = 0;
		} else if(floorCount == -1){
			floorCount = 4;
		}
		switch (floorCount) 
		{
			case 0:
			  floorNum = FloorNum.FLOOR_ZERO;
			  break;
			case 1:
			  floorNum = FloorNum.FLOOR_THREE;
			  break;
			case 2:
			  floorNum = FloorNum.FLOOR_ONE;
			  break;
			case 3:
			  floorNum = FloorNum.FLOOR_FOUR;
			  break;
			case 4:
			  floorNum = FloorNum.FLOOR_TWO;
			  break;
		}
		plyaerTurnDirection = CharController.positiveRotation;
	}

	public void OnTriggerExit(Collider coll)
	{
		if(coll.tag == "SpinTrigger")
		{
			if(CharController.positiveRotation){
				floorCount -= 1;
			} else if(!CharController.positiveRotation){
				floorCount += 1;
			}
		}
	}

	public void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "SpinTrigger")
		{
			if(CharController.positiveRotation){
				floorCount -= 1;
			} else if(!CharController.positiveRotation){
				floorCount += 1;
			}
		}
	}


	public void setRenderer(bool state){
		if(renderer != null){
			renderer.enabled = state;
		}
	}

	public void setKinematic(bool state){
		if(rigid != null){
			rigid.isKinematic = state;
		}
	}

	public void setIsTrigger(bool state){
		if(collider != null){
			collider.isTrigger = state;
		}
	}
}