using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{ 
    private GameObject CanvaObj;
    private Animator FadeAnim;

    // Start is called before the first frame update
    void Start()
    {
        CanvaObj = GameObject.Find("BlackFade1");
        FadeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
