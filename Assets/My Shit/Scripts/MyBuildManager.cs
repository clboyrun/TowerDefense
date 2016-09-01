using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyBuildManager : MonoBehaviour
{
    public static bool isInMenu = false;
    private int menuLevel = 0;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpcontroller = null;

    void Awake()
    {
        isInMenu = false;

        fpcontroller = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    void OnUpdate()
    {
    }

    void OnGUI()
    {
        if ((isInMenu == false) && (Input.GetKeyDown(KeyCode.B)))
        {
            Debug.Log("Making menu visible");
            isInMenu = true;

            fpcontroller.m_MouseLook.SetCursorLock(!isInMenu);
            //fpcontroller.m_CharacterController.enabled = (!isInMenu);
        }
        else if ((isInMenu == true) && (menuLevel == 0) && (Input.GetMouseButtonDown(1)))
        {
            Debug.Log("Making menu invisible");
            isInMenu = false;

            fpcontroller.m_MouseLook.SetCursorLock(!isInMenu);
            //fpcontroller.m_CharacterController.enabled = (!isInMenu);
        }
    }
}
