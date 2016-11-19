using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTime : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public Transform groundPoint;
    public static bool usedRain = false;
    public static bool usedLightning = false;
    public float radius;
    public LayerMask groundMask;
    public GameObject graphics;
    public bool dead = false;
    public Transform target;
    public Transform target2;
    public Transform target3;

    public float timeabt = 0f;

    bool isGrounded;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        var deathstart = GameObject.Find("deathtime");
        deathstart.GetComponent<SpriteRenderer>().enabled = false;
        var raintime = GameObject.Find("raintime");
        raintime.GetComponent<SpriteRenderer>().enabled = false;
        var lightningtime = GameObject.Find("lightningtime");
        lightningtime.GetComponent<SpriteRenderer>().enabled = false;
        var electricitytime = GameObject.Find("electricitytime");
        electricitytime.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        
        timeabt += 0.5f;
        var avilities = GameObject.Find("Abilities");
        foreach (KeyValuePair<float, char> entry in avilities.GetComponent<Avilities>().abilities1)
        {
            if (timeabt == entry.Key)
            {
                useAbility(entry.Value);
            }
        }
        if (dead)
        {
            var death = GameObject.Find("deathtime");
            death.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (usedRain)
        {
            var watertime = GameObject.Find("watertime");
            watertime.transform.position = Vector3.MoveTowards(watertime.transform.position, target.position, (10 * Time.deltaTime));
        }
        if (usedLightning)
        {
            var electricitytime = GameObject.Find("electricitytime");
            electricitytime.GetComponent<SpriteRenderer>().enabled = true;
        } else
        {
            var electricitytime = GameObject.Find("electricitytime");
            electricitytime.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (!dead)
        {
            Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2d.velocity.y);
            rb2d.velocity = moveDir;

            isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                transform.localScale = new Vector3(-0.1875032f, 0.1875005f, 1);
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                transform.localScale = new Vector3(-0.1875032f, 0.1875005f, 1);
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                GetComponent<Animator>().SetBool("isMoving", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("isMoving", false);
            }


            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb2d.AddForce(new Vector2(0, jumpHeight));

            }

            if (rb2d.velocity.y > 0)
            {
                GetComponent<Animator>().SetBool("inAir", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("inAir", false);
            }

        }
    }

    IEnumerator WaitForJump()
    {
        yield return new WaitForSecondsRealtime(10);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPoint.position, radius);
    }

    public void Die()
    {
        var death = GameObject.Find("deathtime");
        death.GetComponent<SpriteRenderer>().enabled = true;
        dead = true;
    }

    public void useAbility(char ab)
    {
        if(ab == 'r')
        {
            var rbg = GameObject.Find("raintime");
            rbg.GetComponent<SpriteRenderer>().enabled = true;
            var bg = GameObject.Find("clear");
            bg.GetComponent<SpriteRenderer>().enabled = false;
            
            var bouldertime = GameObject.Find("bouldertime");
            bouldertime.GetComponent<Rigidbody2D>().isKinematic = false;
            usedRain = true;
        }
        if(ab == 'l')
        {
            if (!usedLightning)
            {
                var lbg = GameObject.Find("lightningtime");
                lbg.GetComponent<SpriteRenderer>().enabled = true;
                var rbg = GameObject.Find("raintime");
                rbg.GetComponent<SpriteRenderer>().enabled = false;
                
                usedLightning = true;
            }
            else
            {
                var lbg = GameObject.Find("lightningtime");
                lbg.GetComponent<SpriteRenderer>().enabled = false;
                var rbg = GameObject.Find("raintime");
                rbg.GetComponent<SpriteRenderer>().enabled = true;
                
                
                usedLightning = false;
            }
        }
    }


}
