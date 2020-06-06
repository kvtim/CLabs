using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseCoroutines : MonoBehaviour
{
    private float waitTime1 = 20.0f;
    private float waitTime2 = 30.0f;
    private float waitTime3 = 40.0f;
    private float timer = 0.0f;
    private int score;
    public Text scoreText;
    public GameObject enemyPrefab;
    public GameObject asteroidPrefab;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(CloneEnemyPrefab());
        StartCoroutine(CloneAsteroidPrefab());

    }
    void Update()
    {
        timer += Time.deltaTime;
    }
    IEnumerator CloneEnemyPrefab()
    {
        while (true)
        {
            if (timer < waitTime1)
            {
                Instantiate(enemyPrefab, new Vector3(Random.Range(-7.3f, 7.3f), 6.7f, 0), Quaternion.identity);
                yield return new WaitForSeconds(4.0f);
            }
            else if(timer < waitTime2)
            {
                Instantiate(enemyPrefab, new Vector3(Random.Range(-7.3f, 7.3f), 6.7f, 0), Quaternion.identity);
                yield return new WaitForSeconds(3.0f);
            }
            else if (timer < waitTime3)
            {
                Instantiate(enemyPrefab, new Vector3(Random.Range(-7.3f, 7.3f), 6.7f, 0), Quaternion.identity);
                yield return new WaitForSeconds(2.0f);
            }
            else
            {
                Instantiate(enemyPrefab, new Vector3(Random.Range(-7.3f, 7.3f), 6.7f, 0), Quaternion.identity);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
    IEnumerator CloneAsteroidPrefab()
    {
        while (true)
        {
            if (timer < waitTime1)
            {
                Instantiate(asteroidPrefab, new Vector3(Random.Range(-7.3f, 7.3f), 6.7f, 0), Quaternion.identity);
                yield return new WaitForSeconds(6.0f);
            }
            else if(timer < waitTime2)
            {
                Instantiate(asteroidPrefab, new Vector3(Random.Range(-7.3f, 7.3f), 6.7f, 0), Quaternion.identity);
                yield return new WaitForSeconds(5.0f);
            }
            else if (timer < waitTime3)
            {
                Instantiate(asteroidPrefab, new Vector3(Random.Range(-7.3f, 7.3f), 6.7f, 0), Quaternion.identity);
                yield return new WaitForSeconds(3.5f);
            }
            else
            {
                Instantiate(asteroidPrefab, new Vector3(Random.Range(-7.3f, 7.3f), 6.7f, 0), Quaternion.identity);
                yield return new WaitForSeconds(2.5f);
            }
        }
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }
}
