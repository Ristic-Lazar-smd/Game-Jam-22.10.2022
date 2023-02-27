using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCounter : MonoBehaviour
{
    public int count;
    public GameObject bugRelease;
    public GameObject manager;
    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
       if(count == 13)
        {
            count = 14;
            bugRelease.SetActive(false);
            manager.GetComponent<File_Manager>().enabled = true;
            popup.SetActive(true);
        }
    }
}
