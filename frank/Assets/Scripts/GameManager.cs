using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float money = 0;
    public TMP_Text moneyText;
    public TMP_Text victoryText;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<TMP_Text>();
        victoryText = GameObject.FindGameObjectWithTag("VictoryText").GetComponent<TMP_Text>();
        victoryText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        money += 5 * Time.deltaTime;
        moneyText.text = $"${money:0}";
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        victoryText.gameObject.SetActive(true);
    }

    public void Defeat()
    {
        Debug.Log("Defeat!");
        victoryText.gameObject.SetActive(true);
        victoryText.text = "Defeat!";
    }
}
