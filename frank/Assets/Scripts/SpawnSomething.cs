using UnityEngine;
using UnityEngine.UI;

public class SpawnSomething : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnMe;
    public int cost;
    public Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.money > cost)
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
        if (GameManager.Instance.money > cost)
        {
            GameManager.Instance.money -= cost;
            Instantiate(spawnMe, spawnPoint.position, spawnMe.transform.rotation);
        }
    }
}
