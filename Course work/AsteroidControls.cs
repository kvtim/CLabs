using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControls : MonoBehaviour
{
    private float timer = 0.0f;
    private float waitTime = 30.0f;
    private float minSpeed = 1.2f;
    private float maxSpeed = 3.2f;
    public float volume;
    [SerializeField]
    private GameObject asteroidExplosionPrefab;
    [SerializeField]
    private AudioClip explosionSound;
    // Start is called before the first frame update
    void Start()
    {

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
            transform.Translate(Vector3.down * Random.Range(2.5f, 4.3f) * Time.deltaTime);
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
            Instantiate(asteroidExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, AudioListener.volume);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();

            if (playerControls != null)
            {
                playerControls.LifeSubstraction();
            }
            Instantiate(asteroidExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, AudioListener.volume);

            Destroy(this.gameObject);
        }
    }
    public float ExplosionSound(float value)
    {
        volume = value;
        return volume;
    }
}
