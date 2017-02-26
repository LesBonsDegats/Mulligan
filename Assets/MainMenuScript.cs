using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

	public void Load_Scene ()
    {
        Application.LoadLevel("Scene1");
	}
	
	public void Quit ()
    {
        Application.Quit();
	}
}
