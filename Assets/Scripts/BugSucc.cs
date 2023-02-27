using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSucc : MonoBehaviour
{
    private bool suc = false;
    public GameObject vacuum;
    public BugCounter bCounter;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (suc == true)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, vacuum.transform.position, 5f * Time.deltaTime);

            Vector2 vec = new Vector2(Mathf.Clamp(this.transform.localScale.x-4f*Time.deltaTime, 2f, 6f), Mathf.Clamp(this.transform.localScale.y - 4f*Time.deltaTime, 2f, 6f));
            transform.localScale = vec;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Vacuum")
        {
            suc = true;
            sound.Play();

        }
        else if(other.gameObject.tag == "Succ")
        {
            
            Destroy(gameObject);
            bCounter.count++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        suc = false;
        sound.Stop();
        Vector2 vec = new Vector2(6f, 6f);
        transform.localScale = vec;
    }
}
