using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugRelease : MonoBehaviour
{
    public GameObject[] bugs;
    private static int i=0;
    public bool spawn = true;
    // Start is called before the first frame update
    void Start()
    {
            Invoke("BugSpawn", 2);              
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BugSpawn()
    {
        bugs[i].SetActive(true);
        i++;
        if (i < 15)
        {
            Invoke("BugSpawn", 2);
        }
        
    }
}
