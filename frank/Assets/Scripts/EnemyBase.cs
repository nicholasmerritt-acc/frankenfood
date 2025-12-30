using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnMe;
    public float startSpawn = 5.0f;
    public float repeatSpawn = 5.0f;
    public float startingHealth = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawn enemies every few seconds
        InvokeRepeating(nameof(SpawnEnemy), startSpawn, repeatSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    SpawnEnemy();
        //}
    }


    public void SpawnEnemy()
    {
        Instantiate(spawnMe, spawnPoint.position, spawnMe.transform.rotation);
    }

}
