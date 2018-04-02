using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource ambient;

	[Header("Guide Sounds")]
	public AudioSource guide1;
	public AudioSource guide2;
	public AudioSource guide3;
	public AudioSource guide4;
	public AudioSource guide5;
	public AudioSource guide6;
	public AudioSource guide7;
	public AudioSource guide8;
	public AudioSource guide9;
	public AudioSource guide10;

	[Header("Hint Sounds")] 
	//played when user is doing something out of the guided experience
	public AudioSource hint1;
	public AudioSource hint2;
	public AudioSource hint3;

	[Header("Additional Info Sounds")]
	//played after this scene ends and user wnts to lern even more
	public AudioSource info1;
	public AudioSource info2;
	public AudioSource info3;
	public AudioSource info4;
	public AudioSource info5;
	public AudioSource info6;



}
