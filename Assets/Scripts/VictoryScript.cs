using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    public GameObject Puzzle3Obj;
    private GameObject PlayerObj;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Player");     
    }

    // Update is called once per frame
    void Update()
    {
        if (Puzzle3Obj.GetComponent<Puzzle3>().Win == true)
        {
            StartCoroutine(Winning());
        }
    }

    IEnumerator Winning()
    {
        PlayerObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(1);
    }
}
