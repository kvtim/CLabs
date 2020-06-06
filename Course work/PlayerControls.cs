using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public Text lives;
    public GameObject laserPrefab;
    public float fireRate = 0.4f;
    public float nextFire;
    [SerializeField]
    private int playerLives = 5;
    [SerializeField]
    private GameObject playerExplosionPrefab;
    [SerializeField]
    private int speed = 8;
    private AudioSource laserShot;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        laserShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SpaceMovement();

        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextFire)
            {
                laserShot.Play();
                nextFire = Time.time + fireRate;
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
            }
        }
    }
    public void LifeSubstraction()
    {
        playerLives--;
        ShowLives();
        if (playerLives < 1)
        {
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
    private void SpaceMovement()
    {
        float horizonInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizonInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * vertInput);
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.194759f)
        {
            transform.position = new Vector3(transform.position.x, -4.194759f, 0);
        }

        if (transform.position.x > 9.682281f)
        {
            transform.position = new Vector3(-9.682281f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.668443f)
        {
            transform.position = new Vector3(9.668443f, transform.position.y, 0);
        }
    }
    public void ShowLives()
    {
        lives.text = playerLives.ToString();
    }
}
