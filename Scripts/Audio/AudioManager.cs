using UnityEngine.Audio;
using UnityEngine;
using System;

/*
	Class manages all audio output
*/
public class AudioManager : MonoBehaviour {

	public Sound[] sounds;
	public static AudioManager instance;

	/*
		Initialises all sounds in the sounds array before the game starts
	*/
	void Awake () {
		//makes sure there is always 1 instance of AudioManager
		if(instance == null){
			instance = this;
		}else{
			Destroy(gameObject);
			return;
		}

		foreach(Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	/*
		Plays starting sounds
	*/
	void Start(){
		Play("AchtergrondMuziek");
		Play("Welkom");
	}

	/*
		param name: name of the sound to play
		Plays a sound
	*/
	public void Play(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			return;
		}
		s.source.Play();
	}

	/*
		param name: name of the sound to stop playing
		Stops playing a sound
	*/
	public void Stop(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			return;
		}
		s.source.Stop();
	}

	/*
		param name: name of sound in sounds array
		Checks if a sound is currently being played
		return : true if the sound is currently being played
	*/
	public bool IsPlaying(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			return false;
		}
		return s.source.isPlaying;
	}
}
