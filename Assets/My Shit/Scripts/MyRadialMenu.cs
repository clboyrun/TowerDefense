using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyRadialMenu : MonoBehaviour {

    public MyRadialButton buttonPrefab;
    public MyRadialButton buttonSelected;

    // Use this for initialization
    public void SpawnButtons(MyRadialInteractable obj)
    {
        for (int i = 0; i < obj.options.Length; i++)
        {
            MyRadialButton newButton = Instantiate(buttonPrefab) as MyRadialButton;
            newButton.transform.SetParent(transform, false);

            float theta = (2 * Mathf.PI / obj.options.Length) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);

            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * 100f;
            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.text.text = obj.options[i].title;
            newButton.onClickMessage = obj.options[i].messageOnClick;
            newButton.myMenu = this;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (buttonSelected)
            { buttonSelected.gameObject.SendMessage(buttonSelected.onClickMessage); }

            Destroy(gameObject);
        }
    }
}
