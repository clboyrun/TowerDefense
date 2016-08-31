using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour 
{
	public void LoadLevel(int index)
	{
		Application.LoadLevel(index);
	}
	
	public void LoadLevel(string levelName)
	{
		Application.LoadLevel(levelName);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
