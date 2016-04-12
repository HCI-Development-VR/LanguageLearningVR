using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour {
	int current;

	public const string path = "items";

	ItemContainer ic;

	GameObject canvas;
	GameObject button1;
	GameObject button2;
	GameObject button3;
	GameObject character = null;

	bool isAnimating = false;

	// Use this for initialization
	void Start () {
		canvas = GameObject.FindWithTag ("Canvas");
		button1 = GameObject.FindWithTag ("Button1");
		button2 = GameObject.FindWithTag ("Button2");
		button3 = GameObject.FindWithTag ("Button3");
		character = GameObject.FindWithTag ("Gisselle");
		current = 0;
		ic = ItemContainer.Load (path);

		if (InRange ()) {
			LoadNext ();
		}
	}

	void LoadNext(){
		button1.GetComponentInChildren<Text> ().text = ic.items [current].choice1;
		button2.GetComponentInChildren<Text> ().text = ic.items [current].choice2;
		button3.GetComponentInChildren<Text> ().text = ic.items [current].choice3;
		++current;
	}

	void NextAnim(){
		character.GetComponent<ClipContainerScript> ().AnimationTrigger (ic.items [current - 1].anim);
	}

	void WhatAnim(){
		character.GetComponent<ClipContainerScript> ().WhatAnimationTrigger ();
	}

	void ResetWhatAnim(){
		character.GetComponent<ClipContainerScript> ().ResetWhatAnimation ();
	}

	public void Check(int buttonSelected){
		isAnimating = true;
		if (current - 1 >= 0 && buttonSelected == ic.items [current-1].answer || buttonSelected == -1) {
			ResetWhatAnim ();
			canvas.SetActive (false);
			print ("right answer for: " + ic.items[current-1].stage);
			// Trigger next animation
			NextAnim();
			if (InRange()) {
				LoadNext ();
				//after anim is done canvas is loaded
				canvas.SetActive (true);
			}
		} else {
			print ("wrong answer for: " + ic.items[current-1].stage);
			WhatAnim ();
			// Need to disable the button
		}
	}

	bool InRange(){
		return current >= 0 && current < ic.items.Count;
	}

	bool InRange(int value){
		return value >= 0 && value < ic.items.Count;
	}
}