using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private const float SpawnRate = 1;

    private int _scoreValue = 0;

    public List<GameObject> targets;
    public TextMeshProUGUI scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        this.UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
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
}
