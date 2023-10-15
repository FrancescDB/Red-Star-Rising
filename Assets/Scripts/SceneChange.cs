using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private int SceneNumber;

    void Start()
    {
        SceneNumber = 2;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
