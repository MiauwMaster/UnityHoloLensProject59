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

    /// <summary>
    /// Add a turret to the nonUpgradedTurrets list
    /// </summary>
    /// <param name="turret">turret to add</param>
    public void Add(GameObject turret)
    {
        nonUpgradedTurrets.Add(turret);
    }

    /// <summary>
    /// Upgrade the turret, change the tag to "UpgradedTurret" and remove it from the list of unupgraded turrets
    /// </summary>
    public void UpgradeTurret()
    {

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

    }    
    #endregion
}
