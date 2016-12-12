using UnityEngine;
using System.Collections;

public class CaseControlScript : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenCase(){
		anim.SetTrigger("OpenCase");
	}
}
