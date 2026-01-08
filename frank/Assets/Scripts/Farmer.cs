using UnityEngine;

public class Farmer : MonoBehaviour
{
    public GameManager gameManager;
    int income = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + (.03f * Vector3.forward));
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        income += PlayerPrefs.GetInt("farmerIncome", 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.money += (Time.deltaTime * income);
    }
}
