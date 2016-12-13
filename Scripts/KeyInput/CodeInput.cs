using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CodeInput : MonoBehaviour {
	public GameObject HoloDeviceReference;
	public string puzzleName = "";
	public string password = "";
	public string currentPassword = "";
	public bool correctPassword;
	public GameObject FloatingText;
	public GameObject nextKeypad;
	public GameObject crystalCaseRef;
	public bool isFinalCode;
	public bool audioPlayed;
	public string audioClipToPlay;


	// Use this for initialization
	void Start () {
		CheckWinState.puzzlePieces.Add(puzzleName, false);
	}
	
	// Update is called once per frame
	void Update () {
		if(CheckWinState.puzzlePieces[puzzleName] == false){
			if(currentPassword == password){
				//Display something to show you completed the puzzle
				correctPassword = true;
				CheckWinState.partCount++;
				CheckWinState.puzzlePieces[puzzleName] = true;
			} else if(currentPassword.Length > password.Length){
				//error and redset
				currentPassword = "";
			}
		}

		if(FloatingText != null){
			//Debug.Log("NotNull");
			TextMesh t = FloatingText.GetComponent<TextMesh>();
			if(t != null){
				//Debug.Log("SettingStuff");
				t.text = currentPassword;
			}
		}
		if(isFinalCode && !audioPlayed && CheckWinState.puzzlePieces[puzzleName] == true){
			Narator.playAudio(audioClipToPlay);
			crystalCaseRef.SendMessage("OpenCase", SendMessageOptions.DontRequireReceiver);
			audioPlayed = true;
		}
	}

	public void KeyInput(string input){
		if(HoloDeviceReference.GetComponent<PlanetHologramController>().isActive){
			if(CheckWinState.puzzlePieces[puzzleName] == true){
				if(nextKeypad != null){
					nextKeypad.SendMessage("KeyInput", input, SendMessageOptions.DontRequireReceiver);
				}
			} else {
				currentPassword += input;
			}
		}
	}

	public void PopKey(){
		if(HoloDeviceReference.GetComponent<PlanetHologramController>().isActive){
			if(CheckWinState.puzzlePieces[puzzleName] == true){
				if(nextKeypad != null){
					nextKeypad.SendMessage("PopKey", SendMessageOptions.DontRequireReceiver);
				}
			} else {
				currentPassword = currentPassword.Substring(0, currentPassword.Length - 1);
			}
		}
	}

	public void ResetPassword(){
		if(HoloDeviceReference.GetComponent<PlanetHologramController>().isActive){
			if(CheckWinState.puzzlePieces[puzzleName] == true){
				if(nextKeypad != null){
					nextKeypad.SendMessage("ResetPassword", SendMessageOptions.DontRequireReceiver);
				}
			} else {
				currentPassword = "";
			}
		}
	}
}
