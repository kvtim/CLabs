using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControls : MonoBehaviour
{
    public int laserSpeed = 6;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        if(transform.position.y>= 5.15f)
        {
            Destroy(this.gameObject, 0.5f);
        }
    }
}
