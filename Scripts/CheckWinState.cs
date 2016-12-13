using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckWinState : MonoBehaviour {
	public static bool keyboardCodePuzzleCompleted = false;
	public static Dictionary<string, bool> puzzlePieces;
	public static int partCount;
	public  int partCountDisplay;
	public bool playWinAudio;
	// Use this for initialization
	// 
	void Start () {
		puzzlePieces = new Dictionary<string, bool>();
	}

	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		partCountDisplay = partCount;
		if(!Narator.isPlaying() && partCount >= 5){
			Narator.playAudio("Dialogue/AllPiecesCompleted");
			playWinAudio = true;
		}
	}
}
