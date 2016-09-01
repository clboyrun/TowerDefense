using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MyRadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public MyRadialMenu myMenu;
    public Image circle;
    public Image icon;
    public Text text;
    public string onClickMessage;

    private Color defaultColor;
    private bool isSelected = false;
    private bool goingUp = true;

	// Use this for initialization
	void Start () {
        defaultColor = circle.color;
	}

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            if (goingUp)
            {
                circle.color = new Color(circle.color.r + 0.01f, circle.color.g + 0.01f, circle.color.b + 0.01f);

                if (circle.color.r >= defaultColor.r + 0.2f)
                {
                    goingUp = false;
                }
            }
            else
            {
                circle.color = new Color(circle.color.r - 0.01f, circle.color.g - 0.01f, circle.color.b - 0.01f);

                if (circle.color.r <= defaultColor.r - 0.2f)
                {
                    goingUp = true;
                }
            }
        }
        else
        {
            circle.color = defaultColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myMenu.buttonSelected = this;
        isSelected = true;
        goingUp = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myMenu.buttonSelected = null;
        isSelected = false;
    }
}
