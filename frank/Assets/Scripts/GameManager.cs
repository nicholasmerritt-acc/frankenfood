using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float money = 0;
    public TMP_Text moneyText;

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
    }

    // Update is called once per frame
    void Update()
    {
        money += 5 * Time.deltaTime;
        moneyText.text = $"${money:0}";
    }
}
