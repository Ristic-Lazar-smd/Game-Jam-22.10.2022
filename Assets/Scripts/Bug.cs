using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public Transform player;
    public GameObject bug;
    private GameObject newBug;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;
    private float spawnTime;
    private bool bugSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BugSpawn", spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = Random.Range(1.0f, 3.0f);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(spawnTime);
        randomXposition = Random.Range(player.position.x - 8f, player.position.x + 8f);
        randomYposition = Random.Range(player.position.y - 4f, player.position.y + 4f);
        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        newBug = Instantiate(bug, spawnPosition, Quaternion.identity);
    }

    void BugSpawn()
    {
        StartCoroutine(ExampleCoroutine());
        Invoke("BugSpawn", spawnTime);
    }
}
