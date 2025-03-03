using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public GameObject winUI;
    public int score;
    public Text scoreText;
    public Text WinScoreText;
    public Text inGameScoreText;
    public ParticleSystem CollectSystem;

    void Start()
    {
        loseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelEnd()
    {
        loseUI.SetActive(true);///
        scoreText.text = "Toplam Puan: " + score;
        inGameScoreText.gameObject.SetActive(false);
    }
    public void AddScore(int pointValue)
    {
        score += pointValue;
        inGameScoreText.text = "Puan: " + score;
    }
    public void StartApp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AppQuit()
    {
        Application.Quit();
    }
    public void WinLevel()
    {
        winUI.SetActive(true);
        WinScoreText.text = "Toplam Puan: " + score;
        inGameScoreText.gameObject.SetActive(false);
    }
    public void NextLevel()
    {
        winUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
