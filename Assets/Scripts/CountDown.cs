using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    private void awake()
    {
        StartCoroutine(Count());
    }
    IEnumerator Count()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
