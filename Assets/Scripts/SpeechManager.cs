using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
	KeywordRecognizer keywordRecognizer = null;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public GameObject laserTurret;
    public GameObject gunTurret;
    public GameObject missileTurret;

    // Use this for initialization
    void Start()
	{
		keywords.Add("Laser", () =>
		{
            // Call the OnReset method on every descendant object.
            GetComponent<BuildTurrets>().turret = laserTurret;
		});

        keywords.Add("Gun", () =>
        {
            // Call the OnReset method on every descendant object.
            GetComponent<BuildTurrets>().turret = gunTurret;
        });

        keywords.Add("Missile", () =>
        {
            // Call the OnReset method on every descendant object.
            GetComponent<BuildTurrets>().turret = missileTurret;
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

		// Register a callback for the KeywordRecognizer and start recognizing!
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
	}

	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;
		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();
		}
	}
}
