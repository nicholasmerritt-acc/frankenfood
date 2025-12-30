using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float money = 0;
    public float startingMoney = 0;

    [SerializeField]
    TMP_Text moneyText;

    [SerializeField]
    TMP_Text victoryText;

    [SerializeField]
    TMP_Text popupText;

    EnemyBase enemyBase;
    AllyBase allyBase;

    public int currentLevel = 1;
    public int hiscore = 0;
    public bool dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        LevelReset();
        GameObject money = GameObject.FindWithTag("MoneyText");
        moneyText = money.GetComponent<TMP_Text>();
        victoryText = GameObject.Find("VictoryText").GetComponent<TMP_Text>();
        popupText = GameObject.Find("PopupText").GetComponent<TMP_Text>();
        allyBase = GameObject.Find("AllyBase").GetComponent<AllyBase>();
        enemyBase = GameObject.Find("EnemyBase").GetComponent<EnemyBase>();

        GameObject.Find("Ground").GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        money += 5 * Time.deltaTime;
        moneyText.text = $"${money:0}";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentLevel = 1;
            SetCurrentLevel();
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Victory()
    {
        if (dead)
        {
            return;
        }

        Debug.Log("Victory!");
        victoryText.text = $"Victory!";
        popupText.text = $"Level {currentLevel} complete!";
        victoryText.gameObject.SetActive(true);
        currentLevel++;
        SetCurrentLevel(); 
        Invoke(nameof(LoadPowerupScreen), 2.5f);
    }

    public void LoadPowerupScreen()
    {
        SceneManager.LoadScene("Powerup");
    }

    public void SetCurrentLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        if (currentLevel > hiscore)
        {
            SetHiScore();
        }
    }

    public void SetHiScore()
    {
        hiscore = currentLevel;
        PlayerPrefs.SetInt("Hiscore", hiscore);
    }

    public void Defeat()
    {
        Debug.Log("Defeat!");
        victoryText.gameObject.SetActive(true);
        victoryText.text = "Defeat!";
        if (currentLevel > hiscore)
        {
            SetHiScore();
        }
        currentLevel = 1;
        SetCurrentLevel();
        Invoke(nameof(LoadMainMenu), 4.0f);
        dead = true;
    }

    public void LoadMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void LevelReset()
    {
        foreach (GameObject fighter in GameObject.FindGameObjectsWithTag("Fighter"))
        {
            Destroy(fighter);
        }
        money = startingMoney;
        victoryText.gameObject.SetActive(false);
        enemyBase.repeatSpawn = 10.0f - currentLevel;
        enemyBase.GetComponent<Fighter>().health = enemyBase.startingHealth;
        allyBase.GetComponent<Fighter>().health = allyBase.startingHealth;

        popupText.text = $"Level {currentLevel}: Defeat Doctors to advance";
    }
}
