using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App_Initialize : MonoBehaviour
{
    public float curvature;
    public float trimming;
    public GameObject inMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject player;

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
        StartCoroutine(StartGame(0.0f));
    }
}


