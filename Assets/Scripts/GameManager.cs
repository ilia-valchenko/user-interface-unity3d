using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const float SpawnRate = 1;

    private int _scoreValue = 0;
    private GameObject _startGameScreen;

    public List<GameObject> targets;
    public TextMeshProUGUI scoreLabel;
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

    public void StartGame()
    {
        this.isGameActive = true;
        StartCoroutine(SpawnTarget());
        this.UpdateScore(0);
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

    private IEnumerator SpawnTarget()
    {
        while (this.isGameActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            int randomIndex = Random.Range(0, this.targets.Count);
            Instantiate(this.targets[randomIndex]);
        }
    }
}
