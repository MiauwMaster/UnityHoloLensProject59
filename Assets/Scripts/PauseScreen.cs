using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {
    [SerializeField]
    private Transform pausecanvas;
    Scene torestart;

    void Start()
    {
        pausecanvas.gameObject.SetActive(false);
        torestart = SceneManager.GetActiveScene();
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void Pause()
    {
        if (!pausecanvas.gameObject.activeInHierarchy)
        {
            Time.timeScale = 0;
            AudioListener.volume = 0;
            pausecanvas.gameObject.SetActive(true);
        }
    }
    public void Continue()
    {
        if (pausecanvas.gameObject.activeInHierarchy)
        {
            pausecanvas.gameObject.SetActive(false);
            AudioListener.volume = 1;
            Time.timeScale = 1;
        }
    }
    public void Restart()
    {
        if (SceneManager.GetActiveScene().name == "GameOver" || pausecanvas.gameObject.activeInHierarchy)
        {
            SceneManager.LoadScene(torestart.name);
        }
    }
}
