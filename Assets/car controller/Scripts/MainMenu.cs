using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   public void PlayAgain(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
	/*public void Exit()
	{
		Application.Quit ();
	}*/
}
