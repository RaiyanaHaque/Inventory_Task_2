using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
	
	public void ResetBtn()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}

	public void ExitBtn()
	{
		Application.Quit();
	}
	
}
