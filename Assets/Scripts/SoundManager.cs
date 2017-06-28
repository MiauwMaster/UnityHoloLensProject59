using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour {

	#region Variables
	public Sound[] Sounds;
	#endregion

	public static SoundManager instance;

	#region Unity Methods
	void Awake()
	{
		instance = this;

		foreach(Sound s in Sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.looping;
			s.source.spatialBlend = s.spatial;
		}
	}

    /// <summary>
    /// Play sound
    /// </summary>
    /// <param name="name">Name of the sound you want to play</param>
	public void Play (string name)
	{
		Sound s = Array.Find(Sounds, sound => sound.name == name);
		s.source.Play();
	}
	#endregion
}


