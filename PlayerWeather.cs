using UnityEngine;


using System.Collections;



public class PlayerWeather : MonoBehaviour
{

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

    public float timeab = 0f;

    bool isGrounded;

    Rigidbody2D rb2d;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        var rbgstart = GameObject.Find("rain");
        rbgstart.GetComponent<SpriteRenderer>().enabled = false;
        var lbgstart = GameObject.Find("lightning");
        lbgstart.GetComponent<SpriteRenderer>().enabled = false;
        var deathstart = GameObject.Find("death");
        deathstart.GetComponent<SpriteRenderer>().enabled = false;
        var elecstart = GameObject.Find("electricity");
        elecstart.GetComponent<SpriteRenderer>().enabled = false;
    }
    
    void Update ()
    {
        timeab += 0.5f;
        if (!dead)
        {
            Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2d.velocity.y);
            rb2d.velocity = moveDir;

            isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                transform.localScale = new Vector3(6.374343f, 7.476273f, 1);
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                transform.localScale = new Vector3(6.374343f, 7.476273f, 1);
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

            if (Input.GetKeyDown(KeyCode.R) && !usedRain)
            {
                var bg = GameObject.Find("BackGround");
                bg.GetComponent<SpriteRenderer>().enabled = false;
                var rbg = GameObject.Find("rain");
                rbg.GetComponent<SpriteRenderer>().enabled = true;
                usedRain = true;
                addAbility(timeab, 'r');
            }

            if (Input.GetKeyDown(KeyCode.L) && !usedLightning && usedRain)
            {
                var rbg = GameObject.Find("rain");
                rbg.GetComponent<SpriteRenderer>().enabled = false;
                var lbg = GameObject.Find("lightning");
                lbg.GetComponent<SpriteRenderer>().enabled = true;
                var spider = GameObject.Find("spider");
                spider.GetComponent<Animator>().SetBool("spiderDead", true);
                var elec = GameObject.Find("electricity");
                elec.GetComponent<SpriteRenderer>().enabled = true;
                addAbility(timeab, 'l');
                usedLightning = true;
            }
            else if (Input.GetKeyDown(KeyCode.L) && usedLightning && usedRain)
            {
                var rbg = GameObject.Find("rain");
                rbg.GetComponent<SpriteRenderer>().enabled = true;
                var lbg = GameObject.Find("lightning");
                lbg.GetComponent<SpriteRenderer>().enabled = false;
                var elec = GameObject.Find("electricity");
                elec.GetComponent<SpriteRenderer>().enabled = false;
                addAbility(timeab, 'l');
                usedLightning = false;
            }

            if (usedRain)
            {
                var boulder = GameObject.Find("boulder");
                boulder.transform.position = Vector3.MoveTowards(boulder.transform.position, target2.position, (10 * Time.deltaTime));
                var water = GameObject.Find("water");
                water.transform.position = Vector3.MoveTowards(water.transform.position, target.position, (10 * Time.deltaTime));
                var water2 = GameObject.Find("water2");
                water2.transform.position = Vector3.MoveTowards(water2.transform.position, target3.position, (10 * Time.deltaTime));
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
        var death = GameObject.Find("death");
        death.GetComponent<SpriteRenderer>().enabled = true;
        dead = true;
    }


    void addAbility(float time, char ab)
    {
        var abilities = GameObject.Find("Abilities");
        abilities.GetComponent<Avilities>().abilities1.Add(time, ab);
    }

}