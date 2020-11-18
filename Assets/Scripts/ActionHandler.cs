using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionHandler : MonoBehaviour
{
    public Animator transitionAnim;
    
    public void StartIntro()
	{
        StartCoroutine(waitLoadScene("IntroScene"));
	}

    public void StartGame() //Start game
	{
        StartCoroutine(waitLoadScene("Gameplay"));
	}

    public void RestartGame()
	{
        StartCoroutine(waitLoadScene("Gameplay"));
	}

    public void QuitGame()
	{
        StartCoroutine(waitLoadScene("MainMenu"));
	}

    public void DeadScreen()
	{
        SceneManager.LoadSceneAsync("LoseScreen");
	}

    public void Victory()
    {
        SceneManager.LoadSceneAsync("VictoryScreen");
    }

    public void ExitGame() //Exit the game
	{
        Application.Quit();
        Debug.Log("The game has quit");
	}

    

    private IEnumerator waitLoadScene(string sceneName) //a little delay for loading scenes
	{
        transitionAnim.Play("FadeIn");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadSceneAsync(sceneName);
	}
}
