using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;

	void Awake()
	{
		foreach (Sound sound in sounds)
		{
			sound.src = gameObject.AddComponent<AudioSource>();
			sound.src.clip = sound.clip;
			sound.src.volume = sound.volume;
			sound.src.loop = sound.loop;
		}
	}

	void Start()
	{
		PlaySound("BGM");
	}

	public void PlaySound(string name)
	{
		Sound sound = Array.Find(sounds, soundElem => soundElem.name == name);
		if (sound == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		sound.src.Play();
	}
	// To access this method, copy the given below function and paste it where you want to play the sound:
	// FindAnyObjectByType<AudioManager>().PlaySound("");
}