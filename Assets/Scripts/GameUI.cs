using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Text scoreText;
    public TextMeshProUGUI waveText;
    public int playerScore = 0;
    public float fadeSpeed = 1;
    private TimerEvent Timer;
    public int Wave = 0;
    private void Start()
    {
        NewWave();
    }

    public void NewWave()
    {

        PlayerPrefs.SetInt("Wave", Wave);
        Wave++;
        waveText.SetText("WAVE " + Wave);
        StartCoroutine(TextFadeInOut(waveText, fadeSpeed));

    }
    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
    }
    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
    }
    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }
    private void UpdateScore(int theScore)
    {
        playerScore += theScore;
        scoreText.text = "SCORE: " + playerScore.ToString();
    }

    IEnumerator TextFadeInOut(TextMeshProUGUI TextToFade, float FadeSpeed)
    {

        while (TextToFade.color.a < 1f)
        {
            TextToFade.color = new Color(TextToFade.color.r, TextToFade.color.g, TextToFade.color.b, TextToFade.color.a + (Time.deltaTime) * fadeSpeed);
            yield return new WaitForSeconds(0.01f);
        }


        while (TextToFade.color.a > 0.01f)
        {
            TextToFade.color = new Color(TextToFade.color.r, TextToFade.color.g, TextToFade.color.b, TextToFade.color.a - (Time.deltaTime) * fadeSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        yield break;
    }
}