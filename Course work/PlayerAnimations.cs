using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("Right", true);
        }
        else
        {
            playerAnim.SetBool("Right", false);

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            playerAnim.SetBool("New Bool", true);
        }
        else
        {
            playerAnim.SetBool("New Bool", false);
        }
    }
}
