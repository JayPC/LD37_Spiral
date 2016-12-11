using UnityEngine;
using System.Collections;

public class CodeInput : MonoBehaviour {
	public string puzzleName = "";
	public string password = "";
	public string currentPassword = "";
	// Use this for initialization
	void Start () {
		CheckWinState.puzzlePieces.Add(puzzleName, false);
	}
	
	// Update is called once per frame
	void Update () {
		if(CheckWinState.keyboardCodePuzzleCompleted == false){
			if(currentPassword == password){
				//Display something to show you completed the puzzle
				CheckWinState.puzzlePieces[puzzleName] = true;
			} else if(currentPassword.Length > password.Length){
				//error and redset
				currentPassword = "";
			}
		}
	}

	public void KeyInput(string input){
		currentPassword += input;
	}

	public void PopKey(){
		currentPassword = currentPassword.Substring(currentPassword.Length - 1);
	}

	public void ResetPassword(){
		currentPassword = "";
	}
}
