using TMPro;
using UnityEngine;

public class MainMenuSetup : MonoBehaviour
{
    public TMP_Text hiscoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hiscoreText.text = $"Hiscore: {PlayerPrefs.GetInt("Hiscore", 0)}";
        PlayerPrefs.SetInt("CurrentLevel", 1);
        PlayerPrefs.SetInt("GruntDamage", 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 47 * Time.deltaTime, 0, Space.Self);
    }
}
