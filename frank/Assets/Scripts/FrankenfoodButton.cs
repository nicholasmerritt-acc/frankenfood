using UnityEngine;
using UnityEngine.SceneManagement;

public class FrankenfoodButton : MonoBehaviour
{
    public int gruntDamage = 0;
    public int bruiserHealth = 0;
    public int gruntSpeed = 0;
    public int bruiserSpeed = 0;
    public int farmerIncome = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel()
    {
        if (gruntDamage != 0)
        {
            int newGruntDamage = PlayerPrefs.GetInt("gruntDamage", 0) + gruntDamage;
            PlayerPrefs.SetInt("gruntDamage", newGruntDamage);
        }

        if (bruiserHealth != 0)
        {
            int newBruiserHealth = PlayerPrefs.GetInt("bruiserHealth", 0) + bruiserHealth;
            PlayerPrefs.SetInt("bruiserHealth", newBruiserHealth);
        }

        if (farmerIncome != 0)
        {
            int newFarmerIncome = PlayerPrefs.GetInt("farmerIncome", 0) + farmerIncome;
            PlayerPrefs.SetInt("farmerIncome", newFarmerIncome);
        }

        //if (gruntDamage != 0)
        //{
        //    int newGruntDamage = PlayerPrefs.GetInt("GruntDamage", 0) + gruntDamage;
        //    PlayerPrefs.SetInt("GruntDamage", gruntDamage);
        //}

        //if (gruntDamage != 0)
        //{
        //    int newGruntDamage = PlayerPrefs.GetInt("GruntDamage", 0) + gruntDamage;
        //    PlayerPrefs.SetInt("GruntDamage", gruntDamage);
        //}

        SceneManager.LoadScene("Maze0");
    }
}
