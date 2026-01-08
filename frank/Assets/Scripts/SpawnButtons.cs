using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButtons : MonoBehaviour
{
    public GameObject ButtonPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //make 3 buttons
        //for (int i = 1; i <= 3; i++)
        //{
        GameObject newGuy = Instantiate(ButtonPrefab, transform.position, transform.rotation);
        newGuy.transform.parent = this.transform;
        newGuy.GetComponentInChildren<TMP_Text>().text = $"FrankenBerries\n\nIncrease grunt damage by 5";
        newGuy.GetComponent<FrankenfoodButton>().gruntDamage = 5;
        //}

        GameObject newGuy2 = Instantiate(ButtonPrefab, transform.position, transform.rotation);
        newGuy2.transform.parent = this.transform;
        newGuy2.GetComponentInChildren<TMP_Text>().text = $"FrankenOatmeal\n\nIncrease bruiser health by 100";
        newGuy2.GetComponent<FrankenfoodButton>().bruiserHealth = 100;

        GameObject newGuy3 = Instantiate(ButtonPrefab, transform.position, transform.rotation);
        newGuy3.transform.parent = this.transform;
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
