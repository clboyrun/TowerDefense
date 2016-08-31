using UnityEngine;
using System.Collections;

public class MyRadialInteractable : MonoBehaviour {

    public Action[] options;
    
    void OnMouseDown()
    {
        //tell canvas to spawn menu
        MyRadialMenuSpawner.ins.SpawnMenu(this);
    }


    [System.Serializable]
    public class Action
    {
        public Color color;
        public Sprite sprite;
        public string title;
        public string messageOnClick;
    }
}
