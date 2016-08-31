using UnityEngine;
using System.Collections;

public class MyRadialMenuSpawner : MonoBehaviour {

    public static MyRadialMenuSpawner ins = null;
    public MyRadialMenu menuPrefab;

    void Awake()
    {
        if (ins == null)
        { ins = this; }
        else
        { Destroy(this); }
    }

    public void SpawnMenu(MyRadialInteractable obj)
    {
        MyRadialMenu newMenu = Instantiate(menuPrefab) as MyRadialMenu;
        newMenu.transform.SetParent(transform, false);
        newMenu.transform.position = Input.mousePosition;
        newMenu.SpawnButtons(obj);
    }
}
