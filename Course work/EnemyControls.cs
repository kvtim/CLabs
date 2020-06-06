using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EnemyControls : MonoBehaviour
{
    private float timer = 0.0f;
    private float waitTime = 35.0f;
    public int scoreValue = 10;
    private float minSpeed = 2.7f;
    private float maxSpeed = 4.7f;

    private UseCoroutines gameController;
    [SerializeField]
    private GameObject enemyExplosionPrefab;
    [SerializeField]
    private AudioClip explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("Coroutines");
        if(GameControllerObject!= null)
        {
            gameController = GameControllerObject.GetComponent<UseCoroutines>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < waitTime)
        {
            transform.Translate(Vector3.down * Random.Range(minSpeed, maxSpeed) * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * Random.Range(3.5f, 5.7f) * Time.deltaTime);
        }
        if (transform.position.y < -6.7f)
        {
            transform.position = new Vector3(Random.Range(-7.3f, 7.3f), 6.7f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, AudioListener.volume);
            Destroy(this.gameObject);
            gameController.AddScore(scoreValue);
        }
        else if (collision.tag == "Player")
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();

            if (playerControls != null)
            {
                playerControls.LifeSubstraction();
            }
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, AudioListener.volume);

            Destroy(this.gameObject);
            gameController.AddScore(scoreValue);
        }
    }
}
