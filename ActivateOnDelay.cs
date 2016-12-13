using UnityEngine;
using System.Collections;

public class ActivateOnDelay : MonoBehaviour {
	public GameObject Activate;
	public float delay = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		delay -= Time.deltaTime;

		if(delay <= 0){
			Activate.SetActive(true);
		}
	}
}
