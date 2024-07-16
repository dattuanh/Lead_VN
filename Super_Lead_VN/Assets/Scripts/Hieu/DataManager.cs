using Assets.Scripts.Hieu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public GameData gameData = new GameData();
    public GameObject endPanel;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private float score = 0; 
    private float highScore = 0; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetFloat("highScore");
            highScoreText.text = $"High score: {Mathf.FloorToInt(highScore).ToString()}"; 
        }
        else
        {
            PlayerPrefs.SetFloat("highScore", highScore);
            highScoreText.text = $"High score: {Mathf.FloorToInt(highScore).ToString()}";
        }
    }

    private void Update()
    {
        score += Time.deltaTime;
        scoreText.text = $"Score: {Mathf.FloorToInt(score).ToString()}";
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore", score);
            highScoreText.text = $"High score: {Mathf.FloorToInt(score).ToString()}";
        }
    }

    public void showEndPanel()
    {
        endPanel.SetActive(true);
    }

    public void ReturnHome()
    {
        endPanel.SetActive(false);
        score = 0;
        Destroy(gameObject);
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        endPanel.SetActive(false);
        score = 0;
        scoreText.text = $"Score: {Mathf.FloorToInt(score).ToString()}";
        Destroy(gameObject);
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
    }

    public void SaveGame()
    {
        SaveLoadManager saveLoadManager = new SaveLoadManager();
        saveLoadManager.SaveData(gameData);
    }

    public void LoadGame()
    {
        SaveLoadManager saveLoadManager = new SaveLoadManager();
        gameData = saveLoadManager.LoadData();
    }
}
