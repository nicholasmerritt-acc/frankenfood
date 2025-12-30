using UnityEngine;

public class Farmer : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + (.03f * Vector3.forward));
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.money += (Time.deltaTime * 5);
    }
}
