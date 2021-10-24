using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class App_Initialize : MonoBehaviour
{
    public float curvature;
    public float trimming;
    public GameObject inMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject player;
    public GameObject adButton;

    private bool hasGameStarted = false;
    private bool hasSeenRewardedAd = false;


    private void Awake()
    {
        Shader.SetGlobalFloat("_Curvature", curvature);
        Shader.SetGlobalFloat("_Trimming", trimming);
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        
        //on start, player isn't moving and the menu ui is the only ui active
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition; //freeze position along ALL axi
        inMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    private IEnumerator StartGame(float waitTime)
    {
        inMenuUI.SetActive(false);
        inGameUI.SetActive(true);
        gameOverUI.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;    //turn em all off, then turn Y back on
    }

    public void PlayButton()
    {
        if (hasGameStarted)
        {
            StartCoroutine(StartGame(2.0f));
        } else
        {
            StartCoroutine(StartGame(0.0f));
        }
        
    }

    public void PauseGame()
    {
        hasGameStarted = true;
        //reused from Start() since we want the same result;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition; //freeze position along ALL axi
        inMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        hasGameStarted = true;
        //reused from Start() since we want the same result;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition; //freeze position along ALL axi
        inMenuUI.SetActive(false);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(true);
        if (hasSeenRewardedAd)
        {
            adButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);    //making the ad button half opaque, keeping original color values
            adButton.GetComponent<Button>().enabled = false;                    //cant click on button
        } else
        {

        }
    }

    public void ShowAd()
    {
        StartCoroutine(StartGame(2.0f));
    }

   

    public void RestartGame()
    {
        SceneManager.LoadScene(0);  //load scene at index 0 in build, which is our only scene
    }
}


