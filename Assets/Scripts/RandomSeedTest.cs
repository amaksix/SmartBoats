using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSeedTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        const int initialSeed = 1234;
        Debug.Log(Random.Range(0,100));
        Debug.Log(Random.Range(0, 100));
        Debug.Log(Random.Range(0, 100));
        Debug.Log(Random.Range(0, 100));
        Debug.Log(Random.Range(0, 100));
        Debug.Log("middle");
       // Random.InitState(42);
        Debug.Log(Random.Range(0, 100));
        Debug.Log(Random.Range(0, 100));
        Debug.Log(Random.Range(0, 100));
        Debug.Log(Random.Range(0, 100));
        Debug.Log(Random.Range(0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        Debug.Log(Random.Range(0, 100));
    }
}
