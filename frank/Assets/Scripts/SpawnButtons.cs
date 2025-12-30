using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButtons : MonoBehaviour
{
    public Button ButtonPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //make 3 buttons
        //for (int i = 1; i <= 3; i++)
        //{
        Button newGuy = Instantiate(ButtonPrefab, transform);
        newGuy.GetComponentInChildren<TMP_Text>().text = $"FrankenBerries\n\nIncrease grunt damage by 5";
        newGuy.GetComponent<FrankenfoodButton>().gruntDamage = 5;
        //}

        Button newGuy2 = Instantiate(ButtonPrefab, transform);
        newGuy2.GetComponentInChildren<TMP_Text>().text = $"FrankenOatmeal\n\nIncrease bruiser health by 100";
        newGuy2.GetComponent<FrankenfoodButton>().bruiserHealth = 100;

        Button newGuy3 = Instantiate(ButtonPrefab, transform);
        newGuy3.GetComponentInChildren<TMP_Text>().text = $"FrankenFish\n\nIncrease farmer income by a few dollars";
        newGuy3.GetComponent<FrankenfoodButton>().farmerIncome = 1;
        //set the text for the 3
        //set them to have different effects randomy chosen from list of foods
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
