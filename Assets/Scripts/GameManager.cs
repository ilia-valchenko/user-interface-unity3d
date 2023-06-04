using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float SpawnRate = 1;

    public List<GameObject> targets;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
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
            int randomIndex = Random.Range(0, this.targets.Count - 1);
            Instantiate(this.targets[randomIndex]);
        }
    }
}
