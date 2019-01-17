using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DemoYieldBehaviour : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
      
        StartCoroutine(PowerReeks());

    }

    IEnumerator PowerReeks()
    {
       
        int i = 0;
        while (true)
        {
           

            Debug.Log("Coroutine: " + (i * i));
            yield return new WaitForSeconds(2);
            i++;
        }
    }

    IEnumerator WaitForSeconds()
    {
        float t = Time.realtimeSinceStartup;

        while(t+2 > Time.realtimeSinceStartup)
        {
            yield return null;

        }

    }
}
