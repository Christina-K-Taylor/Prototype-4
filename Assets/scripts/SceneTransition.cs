using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void GoInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void GoWin()
    {
        SceneManager.LoadScene("WinScene");
    }
}
