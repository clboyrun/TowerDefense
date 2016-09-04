using UnityEngine;
using System.Collections;

public class MyTower : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpgradeTower()
    {
        Debug.Log("Upgrade?");
    }

    void SellTower()
    {
        Debug.Log("Sold...");
    }

    void RepairTower()
    {
        Debug.Log("Repairing!");
    }
}
