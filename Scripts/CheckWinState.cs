using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckWinState : MonoBehaviour {
	public static bool keyboardCodePuzzleCompleted = false;
	public static Dictionary<string, bool> puzzlePieces;
	
	// Use this for initialization
	void Start () {
	
	}

	void Awake () {
		puzzlePieces = new Dictionary<string, bool>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
