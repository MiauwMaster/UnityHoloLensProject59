using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

	#region Variables
	public string name;

	public AudioClip clip;

	[Range(0f,1f)]
	public float volume;
	[Range(.1f, 3f)]
	public float pitch;
	[Range(.1f, 1f)]
	public float spatial;

	public bool looping;

	[HideInInspector]
	public AudioSource source;
	#endregion

	
	#region Unity Methods

	#endregion
}

