using UnityEngine;
using UnityEngine.UI;

public class SpawnSomething : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnMe;
    public int cost;
    public Button button;
    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        gm = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.money > cost)
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
        if (gm.money > cost)
        {
            gm.money -= cost;
            Instantiate(spawnMe, spawnPoint.position, spawnMe.transform.rotation);
        }
    }
}
