using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float money = 0;
    public float startingMoney = 0;

    public TMP_Text moneyText1;
    public TMP_Text victoryText1;
    public TMP_Text popupText1;

    public EnemyBase enemyBase;
    public AllyBase allyBase;
    public GameObject ground;

    public int currentLevel = 1;
    public int hiscore = 0;
    public bool dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        LevelReset();
        //GameObject money = GameObject.FindWithTag("MoneyText");
        //moneyText1 = money.GetComponent<TMP_Text>();
        //victoryText1 = GameObject.Find("VictoryText").GetComponent<TMP_Text>();
        //popupText1 = GameObject.Find("PopupText").GetComponent<TMP_Text>();
        //allyBase = GameObject.Find("AllyBase").GetComponent<AllyBase>();
        //enemyBase = GameObject.Find("EnemyBase").GetComponent<EnemyBase>();

    }

    // Update is called once per frame
    void Update()
    {
        money += 5 * Time.deltaTime;
        moneyText1.text = $"${money:0}";

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
        victoryText1.text = $"Victory!";
        popupText1.text = $"Level {currentLevel} complete!";
        victoryText1.gameObject.SetActive(true);
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
        victoryText1.gameObject.SetActive(true);
        victoryText1.text = "Defeat!";
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
        //foreach (GameObject fighter in GameObject.FindGameObjectsWithTag("Fighter"))
        //{
        //    Destroy(fighter);
        //}
        money = startingMoney;
        victoryText1.gameObject.SetActive(false);
        if (currentLevel > 7)
        {
            enemyBase.repeatSpawn = .5f;
        } 
        else
        {
            enemyBase.repeatSpawn = 7.0f - currentLevel;
        }
        enemyBase.GetComponent<Fighter>().health = enemyBase.startingHealth + (currentLevel * 900);
        allyBase.GetComponent<Fighter>().health = allyBase.startingHealth;

        popupText1.text = $"Level {currentLevel}: Defeat Doctors to advance";

        ground.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
