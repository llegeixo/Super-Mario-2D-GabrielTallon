using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{

    BoxCollider2D boxCollider;
    SFXManager sfxManager;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    // Update is called once per frame
    void Pick()
    {
         boxCollider.enabled = false;
        Destroy(this.gameObject);
        sfxManager.FlagRaised();
    }
}
