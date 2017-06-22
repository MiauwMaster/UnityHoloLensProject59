using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour {

	#region Variables
	public Sound[] Sounds;
	#endregion


	#region Unity Methods
	void Awake()
	{
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


	public void Play (string name)
	{
		Sound s = Array.Find(Sounds, sound => sound.name == name);
		s.source.Play();
	}
	#endregion
}


