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
    private GUIturret guiCannon, guiMissile, guiLaser;
    [SerializeField]
    private PauseScreen pause;

 //   public GUIturret guilaser;

    // Use this for initialization
    void Start()
	{
        //Keyword to select the laser turret
        keywords.Add("Laser", () =>
        {
            GetComponent<BuildTurrets>().turret = laserTurret;
            GetComponent<UpgradeTurrets>().enabled = false;
            guiLaser.MakeVisible();
            guiCannon.MakeInvisible();
            guiMissile.MakeInvisible();
        });

        //Keyword to select the cannon turret
        keywords.Add("Gun", () =>
        {
            GetComponent<BuildTurrets>().turret = gunTurret;
            guiLaser.MakeInvisible();
            guiCannon.MakeVisible();
            guiMissile.MakeInvisible();
        });

        //Keyword to select the missile turret
        keywords.Add("Missile", () =>
        {
            GetComponent<BuildTurrets>().turret = missileTurret;
            guiLaser.MakeInvisible();
            guiCannon.MakeInvisible();
            guiMissile.MakeVisible();
        });

        //Keyword to upgrade the cannon turrets
        keywords.Add("Upgrade", () =>
        {
            GetComponent<UpgradeTurrets>().UpgradeTurret();
            guiLaser.MakeInvisible();
            guiCannon.MakeInvisible();
            guiMissile.MakeInvisible();
        });

        keywords.Add("Pause", () =>
        {
            pause.Pause();
        });
        keywords.Add("Continue", () =>
        {
            pause.Continue();
        });
        keywords.Add("Restart", () =>
        {
            pause.Restart();
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
