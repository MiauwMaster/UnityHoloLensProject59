using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
	KeywordRecognizer keywordRecognizer = null;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public GameObject laserTurret, gunTurret, missileTurret;
    [SerializeField]
    private GUIturret guiCanon, guiMissle, guiLaser;

 //   public GUIturret guilaser;

    // Use this for initialization
    void Start()
	{
        keywords.Add("Laser", () =>
        {
            GetComponent<BuildTurrets>().turret = laserTurret;
            GetComponent<UpgradeTurrets>().enabled = false;
            guiLaser.MakeVisible();
            guiCanon.MakeInvisible();
            guiMissle.MakeInvisible();
        });

        keywords.Add("Cannon", () =>
        {
            GetComponent<BuildTurrets>().turret = gunTurret;
            guiLaser.MakeInvisible();
            guiCanon.MakeVisible();
            guiMissle.MakeInvisible();
        });

        keywords.Add("Missile", () =>
        {
            GetComponent<BuildTurrets>().turret = missileTurret;
            guiLaser.MakeInvisible();
            guiCanon.MakeInvisible();
            guiMissle.MakeVisible();
        });

        keywords.Add("Upgrade cannons", () =>
        {
            GetComponent<UpgradeTurrets>().UpgradeTurret();
            guiLaser.MakeInvisible();
            guiCanon.MakeInvisible();
            guiMissle.MakeInvisible();
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
