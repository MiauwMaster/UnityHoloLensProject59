using UnityEngine;
using System.Collections.Generic;


public class UpgradeTurrets : MonoBehaviour {

    #region Variables

    public List<GameObject> nonUpgradedTurrets;
    public int upgradePrice = 5;
    
    #endregion


    #region Unity Methods

    private void Start()
    {
        nonUpgradedTurrets = new List<GameObject>();
    }

    public void Add(GameObject turret)
    {
        nonUpgradedTurrets.Add(turret);
    }

    public void UpgradeTurret()
    {
        nonUpgradedTurrets.AddRange(GameObject.FindGameObjectsWithTag("NonUpgradedTurret"));

        // If we have enough moneys
        if (Camera.main.GetComponent<Player>().money >= (nonUpgradedTurrets.Count * upgradePrice))
        {
            foreach (var turret in nonUpgradedTurrets)
            {
                // Set each turret upgraded bool to true
                turret.GetComponent<Turret>().upgraded = true;
                // Change tag
                turret.tag = "UpgradedTurret";
                // remove the moneys
                Camera.main.GetComponent<Player>().LoseMoney(upgradePrice);
                // and remove from the list.
                nonUpgradedTurrets.Remove(turret);
            }
        }

        // if not, clear the list
        else
        {
            nonUpgradedTurrets.Clear();
        }
    }    
    #endregion
}
