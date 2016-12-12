using UnityEngine;
using System.Collections;

public class CrystalStand : MonoBehaviour {

	public GameObject point1; //points for the crystals
	public GameObject point2; //points for the crystals
	public GameObject point3; //points for the crystals

	public GameObject pointDown1; //points for the crystals
	public GameObject pointDown2; //points for the crystals
	public GameObject pointDown3; //points for the crystals

	public GameObject Crystal1; //the crystals
	public GameObject Crystal2; //the crystals
	public GameObject Crystal3; //the crystals

	public int[] crystalOrder;

	public string audioClipToPlay;
	public bool audioPlayed = false;

	public float pickupDelay = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Crystal1 != null){
			Crystal1.GetComponent<Rigidbody>().isKinematic = true; //Make it so it doesn't move anymore
			Crystal1.transform.position = point1.transform.position;
			Crystal1.transform.rotation = point1.transform.rotation;
		}
		if(Crystal2 != null){
			Crystal2.GetComponent<Rigidbody>().isKinematic = true; //Make it so it doesn't move anymore
			Crystal2.transform.position = point2.transform.position;
			Crystal2.transform.rotation = point2.transform.rotation;
		}
		if(Crystal3 != null){
			Crystal3.GetComponent<Rigidbody>().isKinematic = true; //Make it so it doesn't move anymore
			Crystal3.transform.position = point3.transform.position;
			Crystal3.transform.rotation = point3.transform.rotation;
		}

		//if we have all 3 crystals and they match in order
		if(Crystal1 != null && Crystal2 != null && Crystal3 != null &&
			Crystal1.GetComponent<CrystalInfo>().crystalNum == crystalOrder[0] &&
			Crystal2.GetComponent<CrystalInfo>().crystalNum == crystalOrder[1] &&
			Crystal3.GetComponent<CrystalInfo>().crystalNum == crystalOrder[2]){
			if(audioPlayed == false){
				Narator.playAudio(audioClipToPlay);
				audioPlayed = true;
			}

		} else if(Crystal1 != null && Crystal2 != null && Crystal3 != null) {
			//else if we have all 3 and they don't pass
			pickupDelay = 2;
			Crystal1.GetComponent<Rigidbody>().isKinematic = false;
			Crystal1.transform.position = pointDown1.transform.position;
			Crystal1.transform.rotation = pointDown1.transform.rotation;
			Crystal1 = null;

			Crystal2.GetComponent<Rigidbody>().isKinematic = false;
			Crystal2.transform.position = pointDown2.transform.position;
			Crystal2.transform.rotation = pointDown2.transform.rotation;
			Crystal2 = null;

			Crystal3.GetComponent<Rigidbody>().isKinematic = false;
			Crystal3.transform.position = pointDown3.transform.position;
			Crystal3.transform.rotation = pointDown3.transform.rotation;
			Crystal3 = null;
		}

		if(pickupDelay > 0){
			pickupDelay -= Time.deltaTime;
		}
	}

	public void OnTriggerEnter(Collider coll){
		if(pickupDelay <= 0){
			if(coll.gameObject.tag == "PuzzlePiece"){
				Debug.Log(coll.gameObject.name);
				if(coll.gameObject.GetComponent<CrystalInfo>() != null){
					if(Crystal1 == null){
						Crystal1 = coll.gameObject;
						ObjectInteraction.dropIt = true;
					} else if(Crystal2 == null){
						Crystal2 = coll.gameObject;
						ObjectInteraction.dropIt = true;
					} else if(Crystal3 == null){
						Crystal3 = coll.gameObject;
						ObjectInteraction.dropIt = true;
					}
				}
			}
		}
	}
}
