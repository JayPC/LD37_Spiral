using UnityEngine;
using System.Collections;

public class IntroExplosion : MonoBehaviour {
	public Vector3 postExplosionSpawn;

	public void StartExplosion(){
		//Black out
		this.transform.position = postExplosionSpawn;
	}
}
