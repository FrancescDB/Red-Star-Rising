using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject DoorObj;
    public Animator DoorAnim;

    private bool Opening;

    // Start is called before the first frame update
    void Start()
    {
        Opening = false;

        DoorAnim = DoorObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Opening == true)
        {
            StartCoroutine(StartAnim());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Opening = true;
        }
    }

    public void DestroyMe()
    {
        Destroy(DoorObj);
    }

    IEnumerator StartAnim()
    {
        DoorAnim.SetBool("A", true);

        yield return new WaitForSeconds(0.417f);

        DestroyMe();
    }
}
