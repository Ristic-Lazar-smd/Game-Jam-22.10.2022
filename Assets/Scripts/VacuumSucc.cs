using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumSucc : MonoBehaviour
{
    private bool suc = false;
    public Transform bug;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(suc == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, bug.position, 0.2f);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bug")
        {
            suc = true;
            
        }
    }
}
