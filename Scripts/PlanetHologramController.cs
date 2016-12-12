using UnityEngine;
using System.Collections;

public class PlanetHologramController : MonoBehaviour {
	public GameObject planetModel;
	public GameObject[] lightReferences;
	public bool isActive;
	public static bool isHologramActive;
	// Use this for initialization
	void Start () {
		//planetModel.transform.localScale = new Vector3(0.8f, 0, 0.8f);
		foreach (GameObject go in lightReferences) 
		{
			go.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		isHologramActive = isActive;
		if(isActive && planetModel.transform.localScale.y <= 1){
			foreach (GameObject go in lightReferences) 
			{
				go.SetActive(true);
			}
			planetModel.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
		}
		if(!isActive && planetModel.transform.localScale.y >= 0){
			planetModel.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
			if(planetModel.transform.localScale.y <= 0){
				foreach (GameObject go in lightReferences) 
				{
					go.SetActive(false);
				}
			}
		}
	}

	public void TriggerHologram(){
		isActive = !isActive;
	}
}
