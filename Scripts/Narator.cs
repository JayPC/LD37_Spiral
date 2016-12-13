using UnityEngine;
using System.Collections;

public class Narator : MonoBehaviour {
	public AudioSource audioSource;
	public static GameObject theSingleNarator;

	public void Awake(){
		audioSource = this.GetComponent<AudioSource>();
		theSingleNarator = this.gameObject;
	}


	public static void playAudio(string file){
		if(Narator.theSingleNarator.GetComponent<Narator>().audioSource != null){
			Narator.theSingleNarator.GetComponent<Narator>().audioSource.Stop();
		}
		AudioClip clip = Resources.Load<AudioClip>(file);
		Narator.theSingleNarator.GetComponent<Narator>().audioSource.PlayOneShot(clip);
	}

	public static bool isPlaying(){
		if(Narator.theSingleNarator.GetComponent<Narator>().audioSource != null){
			return Narator.theSingleNarator.GetComponent<Narator>().audioSource.isPlaying;
		}
		return false;
	}
}
