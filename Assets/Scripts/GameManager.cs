using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int InitialScoreValue = 0;
    private const int InitialNumberOfLives = 3;

    private int _scoreValue = 0;
    private int _lives;
    private float _spawnRate = 1;
    private GameObject _startGameScreen;

    public List<GameObject> targets;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI livesLabel;
    public GameObject gameOverText;
    public Button restartButton;
    public bool isGameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        _startGameScreen = GameObject.Find("StartGameScreen");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateScore(int scoreToAdd)
    {
        _scoreValue += scoreToAdd;
        this.scoreLabel.text = $"Score: {_scoreValue}";
    }

    public void StartGame(int difficulty)
    {
        if (difficulty >= 1)
        {
            _spawnRate /= difficulty;
        }
        else
        {
            // TODO: Add logging.
            Debug.LogWarning("The difficulty value which was provided is less than 1.");
        }

        this.isGameActive = true;
        StartCoroutine(SpawnTarget());
        this.UpdateScore(InitialScoreValue);
        this.UpdateLives(InitialNumberOfLives);
        _startGameScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        this.isGameActive = false;
        this.restartButton.gameObject.SetActive(true);
        this.gameOverText.SetActive(true);
    }

    public void UpdateLives(int livesToChange)
    {
        _lives += livesToChange;
        livesLabel.text = $"Lives: {_lives}";

        if (_lives <= 0)
        {
            this.GameOver();
        }
    }

    private IEnumerator SpawnTarget()
    {
        while (this.isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int randomIndex = Random.Range(0, this.targets.Count);
            Instantiate(this.targets[randomIndex]);
        }
    }
}
