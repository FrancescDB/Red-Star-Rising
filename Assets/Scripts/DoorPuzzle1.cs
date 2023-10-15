using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle1 : MonoBehaviour
{
    public GameObject PuzzleObj;

    private Animator DoorAnim;

    // Start is called before the first frame update
    void Start()
    {
        DoorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PuzzleObj.GetComponent<Puzzle1>().Win == true)
        {
            DoorAnim.SetBool("Moving", true);
        }
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
