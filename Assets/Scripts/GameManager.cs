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

    public List<GameObject> targets;
    public TextMeshProUGUI scoreLabel;
    public GameObject gameOverText;
    public Button restartButton;
    public bool isGameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        this.isGameActive = true;
        StartCoroutine(SpawnTarget());
        this.UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
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

    public void UpdateScore(int scoreToAdd)
    {
        _scoreValue += scoreToAdd;
        this.scoreLabel.text = $"Score: {_scoreValue}";
    }

    public void GameOver()
    {
        this.isGameActive = false;
        this.restartButton.gameObject.SetActive(true);
        this.gameOverText.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
