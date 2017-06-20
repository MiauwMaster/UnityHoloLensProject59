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
            GetComponent<BuildTurrets>().turret = laserTurret;
            GetComponent<UpgradeTurrets>().enabled = false;
        });

        keywords.Add("Cannon", () =>
        {          
            GetComponent<BuildTurrets>().turret = gunTurret;
            GetComponent<UpgradeTurrets>().enabled = false;
        });

        keywords.Add("Missile", () =>
        {           
            GetComponent<BuildTurrets>().turret = missileTurret;
            GetComponent<UpgradeTurrets>().enabled = false;
        });

        keywords.Add("Upgrade", () =>
        {
            GetComponent<BuildTurrets>().turret = null;
            GetComponent<UpgradeTurrets>().enabled = true;            
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
