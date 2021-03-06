﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float delayBetweenSpawns = 0.25f;
	public float spawnDelay = 5;

	[System.Serializable]
	public class WaveComponent {
		public GameObject enemyPrefab;
		public int num;
		[System.NonSerialized]
		public int spawned = 0;
	}

	public WaveComponent[] waveComps;

	
	// Update is called once per frame
	void Update () {
        DeathCheck();
		spawnDelay -= Time.deltaTime;
		if(spawnDelay < 0) {
			spawnDelay = delayBetweenSpawns;

			bool didSpawn = false;

			// Go through the wave comps until we find something to spawn;
			foreach(WaveComponent wc in waveComps) {
				if(wc.spawned < wc.num) {
					// Spawn it!
					wc.spawned++;
					Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);

					didSpawn = true;
					break;
				}
			}

			if(didSpawn == false) {
				// Wave must be complete!

				if(transform.parent.childCount > 1) {
					transform.parent.GetChild(1).gameObject.SetActive(true);
				}
				else {
					// That was the last wave -- what do we want to do?
					// What if instead of DESTROYING wave objects,
					// we just made them inactive, and then when we run
					// out of waves, we restart at the first one,
					// but double all enemy HPs or something?
				}

				Destroy(gameObject);
			}
		}
	}

    /// <summary>
    /// If the player is dead, dont spawn anymore by disabling this script
    /// </summary>
    public void DeathCheck()
    {
        if (!Camera.main.GetComponent<Player>().isAlive)
        {
            this.gameObject.SetActive(false);
        }
    }
}
