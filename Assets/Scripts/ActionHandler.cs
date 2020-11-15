using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionHandler : MonoBehaviour
{
    //public Animator transitionAnim;
    
    public void StartGame() //Start game
	{
        StartCoroutine(waitLoadScene("Gameplay"));
	}

    public void ExitGame() //Exit the game
	{
        Application.Quit();
        Debug.Log("The game has quit");
	}

    private IEnumerator waitLoadScene(string sceneName) //a little delay for loading scenes
	{
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(sceneName);
	}
}
