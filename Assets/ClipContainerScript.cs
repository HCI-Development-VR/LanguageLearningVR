using UnityEngine;
using System.Collections;

public class ClipContainerScript : MonoBehaviour {

	const string whatBool = "WhatBool";
	public AudioClip[] audioclips;
	Animator animator;
	// Use this for initialization

	void Start(){
		animator = GetComponent<Animator> ();
	}

	public void PlayMusic(int stage){
		if(stage >= 0 && stage < audioclips.Length){
			AudioSource audioSource = this.GetComponent<AudioSource> ();
			audioSource.PlayOneShot (audioclips [stage]);
		}
	}

	public void AnimationTrigger(string boolName){
		animator.SetBool (boolName, true);
	}

	public void WhatAnimationTrigger(){
		animator.SetBool (whatBool, true);
	}

	public void ResetWhatAnimation(){
		animator.SetBool (whatBool, false);
	}
}

