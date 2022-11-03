using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrowScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    [SerializeField] Animator animator;
    public GameObject charlie;
    public Transform teleportLocation;
    public GameObject purpleTeleporter;
    public GameObject blueTeleporter;
    public GameObject cheese;
    public Vector3 cheese1;
    public Vector3 cheese2;
    public Vector3 cheese3;
    public Vector3 cheese4;

    private float _movementSpeed = 15;
    private int cheeseLeft = 1;
    public int currentLevel = 1;

    void Start()
    {
        SceneManager.activeSceneChanged += MoveToSpawn;
    }
    void MoveToSpawn(Scene current, Scene next)
    {
        transform.position = GameObject.Find("spawn").gameObject.transform.position;
    }
    private void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        Movement();
    }
    void Respawn()
    {
        charlie.transform.position = new Vector3(teleportLocation.position.x, teleportLocation.position.y, teleportLocation.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cheese")
        {
            if(cheeseLeft == 1)
            {
                cheese1 = collision.transform.position;
            }
            if (cheeseLeft == 4)
            {
                cheese4 = collision.transform.position;
            }
            if (cheeseLeft == 3)
            {
                cheese3 = collision.transform.position;
            }
            if (cheeseLeft == 2)
            {
                cheese2 = collision.transform.position;
            }
            Destroy(collision.gameObject);
            cheeseLeft--;
            if(cheeseLeft == 0)
            {
                
                spawnPortal();
            }
        }
        else if (collision.gameObject.tag == "portal")
        {
            currentLevel++;
            cheeseUpdater();
            SceneManager.LoadScene(currentLevel);
            
        }
        else if (collision.gameObject.tag == "death")
        {
            Respawn();
            resetPortal();
            cheeseUpdater();
           
        }
    }
   
    void Movement()
    {
        //sets a max velocity for gravity and flapping wings
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 20);
        if (Input.GetButtonDown("Jump")){
            rb.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
            animator.SetTrigger("flap");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * _movementSpeed * Time.deltaTime;
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -_movementSpeed * Time.deltaTime;
            spriteRenderer.flipX = false;
        }

    }

    void spawnPortal()
    {
        GameObject purpleTeleporterClone = Instantiate(purpleTeleporter);
        purpleTeleporterClone.transform.position = GameObject.Find("UnopenedPortal").transform.position;
        Destroy(GameObject.Find("UnopenedPortal"));
    }
    void resetPortal()
    {
        GameObject blueTeleporterClone = Instantiate(blueTeleporter);
        blueTeleporterClone.transform.position = GameObject.Find("Portal").transform.position;
        Destroy(GameObject.Find("Portal"));

        GameObject cheeseClone = Instantiate(cheese);
        cheeseClone.transform.position = cheese1;
        Destroy(GameObject.Find("cheese"));
        if (!cheese2.Equals(null))
        {
            GameObject cheeseClone2 = Instantiate(cheese);
            cheeseClone.transform.position = cheese2;
        }
        if (!cheese3.Equals(null))
        {
            GameObject cheeseClone3 = Instantiate(cheese);
            cheeseClone.transform.position = cheese3;
        }
        if (!cheese4.Equals(null))
        {
            GameObject cheeseClone2 = Instantiate(cheese);
            cheeseClone.transform.position = cheese4;
        }

    }
    void cheeseUpdater()
    {
        cheeseLeft = 1;
    }
}

