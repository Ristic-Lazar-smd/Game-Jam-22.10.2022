using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] imgs;
    public GameObject blackScreen;
    public Sprite hands1;
    public Sprite hands2;
    public SpriteRenderer h;
    public GameObject hands;
    public Transform handPos;
    public GameObject city;
    private bool cityReady = false;
    public RawImage video1;
    public RawImage video2;
    public RawImage video3;
    public RawImage video4;
    public RawImage video5;
    public VideoPlayer vid1;
    public VideoPlayer vid2;
    public VideoPlayer vid3;
    public VideoPlayer vid4;
    public VideoPlayer vid5;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;
    public AudioClip sound7;
    public AudioSource song;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(cityReady == true)
        {
            city.transform.position = new Vector2(city.transform.position.x - 30f * Time.deltaTime, city.transform.position.y);
        }
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        blackScreen.SetActive(false);
        song.Play();
        sr.sprite = imgs[0];
        cityReady = true;
        yield return new WaitForSeconds(2);
        song.Stop();
        song.clip = sound2;
        GetComponent<SpriteRenderer>().enabled = false;
        blackScreen.SetActive(true);
        song.Play();
        cityReady = false;
        
        yield return new WaitForSeconds(1);
        song.Stop();
        song.clip = sound3;
        blackScreen.SetActive(false);


        vid1.gameObject.SetActive(true);
        video1.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        video1.gameObject.SetActive(false);
        Destroy(video1);
        Destroy(vid1);

        song.Play();
        vid2.gameObject.SetActive(true);
        video2.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        song.Stop();
        song.clip = sound4;
        video2.gameObject.SetActive(false);
        Destroy(video2);
        Destroy(vid2);
        song.Play();
        vid3.gameObject.SetActive(true);
        video3.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        song.Stop();
        song.clip = sound5;
        video3.gameObject.SetActive(false);
        Destroy(video3);
        Destroy(vid3);
        song.Play();
        vid4.gameObject.SetActive(true);
        video4.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        song.Stop();
        song.clip = sound6;
        video4.gameObject.SetActive(false);
        Destroy(video4);
        Destroy(vid4);

        //yield return new WaitForSeconds(3);
        //video[2].gameObject.SetActive(true);
        //yield return new WaitForSeconds(3);
        //video[3].gameObject.SetActive(true);
        //yield return new WaitForSeconds(3);
        //sr.sprite = imgs[5];
        GetComponent<SpriteRenderer>().enabled = true;
        song.Play();
        sr.sprite = imgs[5];
        yield return new WaitForSeconds(0.5f);
        hands.SetActive(true);
        h.sprite = hands1;
        yield return new WaitForSeconds(0.5f);
        h.sprite = hands2;
        handPos.position = new Vector2(handPos.position.x, -3.18f);
        //handPos.position.Set(handPos.position.x, -3.18f, handPos.position.z);
        yield return new WaitForSeconds(0.5f);
        h.sprite = hands1;
        handPos.position = new Vector2(handPos.position.x, -2.33f);
        //handPos.position.Set(handPos.position.x, -2.33f, handPos.position.z);
        yield return new WaitForSeconds(0.5f);
        h.sprite = hands2;
        handPos.position = new Vector2(handPos.position.x, -1.06f);
        yield return new WaitForSeconds(1f);
        song.Stop();
        song.clip = sound7;
        //GetComponent<SpriteRenderer>().enabled = false;
        blackScreen.SetActive(true);
        hands.SetActive(false);
        yield return new WaitForSeconds(2f);
        //blackScreen.SetActive(false);
        vid5.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        video5.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        //handPos.position.Set(handPos.position.x, -1.06f, handPos.position.z);
       // blackScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        video5.gameObject.SetActive(false);
        song.Play();
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
