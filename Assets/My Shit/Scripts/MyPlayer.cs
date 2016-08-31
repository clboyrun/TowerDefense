using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyPlayer : MonoBehaviour
{
    public Text People = null;
    public Text Wood = null;
    public Text Rock = null;
    
    public int people = 0;
    public int wood = 0;
    public int rock = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        People.text = people.ToString();
        Wood.text = wood.ToString();
        Rock.text = rock.ToString();
    }
}