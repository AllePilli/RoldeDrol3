﻿using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;
	public static AudioManager instance;

	void Awake () {
		//zorgt ervoor dat er altijd maar 1 AudioManager is
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

	void Start(){
		Play("AchtergrondMuziek");
		Play("Welkom");
	}

	public void Play(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			return;
		}
		s.source.Play();
	}

	public void Stop(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			return;
		}
		s.source.Stop();
	}

	public bool IsPlaying(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			return false;
		}
		return s.source.isPlaying;
	}
}