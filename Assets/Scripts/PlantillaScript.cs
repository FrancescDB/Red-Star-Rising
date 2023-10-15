using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantillaScript : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(PlantillaFlorida());
    }

    IEnumerator PlantillaFlorida()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(1);
    }
}
