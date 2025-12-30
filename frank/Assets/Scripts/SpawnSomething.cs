using UnityEngine;
using UnityEngine.UI;

public class SpawnSomething : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnMe;
    public int cost;
    public Button button;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.money > cost)
        {
            button.interactable = true;
        } 
        else
        {
            button.interactable = false;
        }
    }

    public void SpawnClick()
    {
        if (gameManager.money > cost)
        {
            gameManager.money -= cost;
            Instantiate(spawnMe, spawnPoint.position, spawnMe.transform.rotation);
        }
    }
}
