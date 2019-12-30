using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Text scoreText;
    public TextMeshProUGUI waveText;
    public int playerScore = 0;
    private TimerEvent Timer;
    private int Wave = 0;
    private void Start()
    {
        NewWave();
        
    }

    public void NewWave()
    {
        waveText.SetText("Wave " + Wave);
        waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, 255);
        waveText.CrossFadeAlpha(0, 1, true);
        Wave++;
    }
    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
        NewWave();
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
}